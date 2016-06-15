using UnityEngine;
using System.Collections.Generic;
using System;

//using System;
public class UnitAI : GameManagerSearcher
{
    enum AiState { Run, Fight, Wander, Cheer, Die };
    private AiState currentState = AiState.Run;

    public bool isActive { get { return currentState != AiState.Die && currentState != AiState.Cheer 
                && currentState != AiState.Wander || (currentState == AiState.Wander && cityTile && cityTile.HasHostileUnits(owner)); } }

    [SerializeField]
    int unitStrength = 1;
    public int GetStrength { get { return unitStrength; } }
    [SerializeField]
    float unitSpeed = 1f;
    [SerializeField]
    float rayCastDist = 1f;

    [SerializeField]
    float attackCoolDown = 1f;
    [SerializeField]
    float wanderAnimTime = 1f;
    [SerializeField]
    float cheerAnimTime = 1f;
    [SerializeField]
    float deathAnimTime = 1f;

    [SerializeField]
    int scoreReward = 10;
    [SerializeField]
    int moneyReward = 1;

    [SerializeField]
    List<GameObject> models = new List<GameObject>();
    private List<Material> materials = new List<Material>();
    private List<ParticleSystem> attackParticles = new List<ParticleSystem>();

    [SerializeField]
    GameObject projParentPrefab;
    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    float projectileFlightDuration = 1f;

    [SerializeField]
    GameObject conversionPrefab;

    public BuffList buffList = new BuffList();

    private float wanderTimer;
    private float cheerTimer;
    private float deathTimer;
    private float attackTimer;

    private PLAYERS owner;
    public PLAYERS Owner { get { return owner; } }

	public LANES lane;

    private Vector3 movementDir;
    private Transform target = null;
    private CityTileTrigger cityTile = null;
    public CityTileTrigger CityTile { get { return cityTile; } set { cityTile = value; } }
    public delegate void DestructionDelegate();
    public event DestructionDelegate OnDestruction = null;

    [SerializeField]
    TextMesh scoreGainFeedbackPrefab;

    [SerializeField]
    CoinPickup coinSpawnPrefab;

    [SerializeField]
    GameObject iceBlockPrefab;
    GameObject currentIceBlock = null;

    protected override void Awake()
    {
        base.Awake();
        wanderTimer = wanderAnimTime;
        cheerTimer = cheerAnimTime;
        deathTimer = deathAnimTime;
    }

    void Start()
    {
        foreach(GameObject model in models)
        {
            materials.Add(model.transform.GetChild(0).GetComponent<Renderer>().material);
            //attackParticles.Add(model.transform.GetChild(1).GetChild(0).GetComponent<ParticleSystem>());
            //attackParticles.Add(model.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<ParticleSystem>());
        }
        //orientation
        Vector3 worldUp = Physics.gravity.normalized * -1.0f;
        float heightDiff = Vector3.Dot(worldUp, transform.position + movementDir) - Vector3.Dot(worldUp, transform.position);
        Vector3 lookTargetPoint = transform.position + movementDir - heightDiff * worldUp;

        Quaternion targetRot = Quaternion.LookRotation(lookTargetPoint - transform.position, worldUp);
        transform.rotation = targetRot;
    }

    // Update is called once per frame
    void Update()
    {
        buffList.Update();
        Behave();
    }

    void Behave()
    {
        switch (currentState)
        {
            case AiState.Run:
                Run();
                break;
            case AiState.Fight:
                Fight();
                break;
            case AiState.Wander:
                Wander();
                break;
            case AiState.Cheer:
                Cheer();
                break;
            case AiState.Die:
                Die();
                break;
        }
    }

    float CalculateSpeed()
    {
        float speed = unitSpeed;

        foreach (Buff buff in buffList.buffs)
        {
            switch (buff.type)
            {
                case BUFF_TYPES.UNIT_FREEZE:
                    return 0.0f;
            }
        }
        return speed;
    }

    private void Run()
    {
        if (cityTile)
        {
            bool hostileUnits = cityTile.HasHostileUnits(owner);
            if (hostileUnits)
            {
                SetAiState(AiState.Fight);
                return;
            }
            else
            {
                SetAiState(AiState.Wander);
                return;
            }
        }

        float speed = CalculateSpeed();

        transform.position += movementDir * speed;

        //orientation
        Vector3 worldUp = Physics.gravity.normalized * -1.0f;
        float heightDiff = Vector3.Dot(worldUp, transform.position + movementDir) - Vector3.Dot(worldUp, transform.position);
        Vector3 lookTargetPoint = transform.position + movementDir - heightDiff * worldUp;

        Quaternion targetRot = Quaternion.LookRotation(lookTargetPoint - transform.position, worldUp);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 0.05f);
    }

    private void Fight()
    {
        attackTimer -= Time.deltaTime;
        bool hasEnemyUnits = cityTile.HasHostileUnits(owner);
        if (hasEnemyUnits)
        {
            if (!target)
            {
                target = cityTile.GetEnemyUnit(owner);
            }
            else
            {
                //orientation
                Vector3 worldUp = Physics.gravity.normalized * -1.0f;
                float heightDiff = Vector3.Dot(worldUp, target.position) - Vector3.Dot(worldUp, transform.position);
                Vector3 lookTargetPoint = target.position - heightDiff * worldUp;

                Quaternion targetRot = Quaternion.LookRotation(lookTargetPoint - transform.position, worldUp);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 0.1f);
            }

            if (target && attackTimer <= 0f)
            {
                LaunchProjectile();
                attackTimer = attackCoolDown;
            }
        }
        else
        {
            attackTimer = 0f;
            SetAiState(AiState.Wander);
        }
    }

    private void Wander()
    {
        wanderTimer -= Time.deltaTime;
        if (wanderTimer <= 0f)
        {
            transform.GetComponent<Rigidbody>().isKinematic = true;
            transform.GetComponent<Collider>().isTrigger = true;
            Instantiate(conversionPrefab, transform.position, transform.rotation);
            if (cityTile)
                cityTile.RemoveUnit(transform, owner);
            SetAiState(AiState.Cheer);
        }
        else if (cityTile.HasHostileUnits(owner))
        {
            wanderTimer = wanderAnimTime;
            SetAiState(AiState.Fight);
        }
    }

    private void Cheer()
    {
        cheerTimer -= Time.deltaTime;
        foreach (Material mat in materials)
        {
            mat.SetFloat("_Visibility", Mathf.Clamp01(cheerTimer / cheerAnimTime));
        }
        if (cheerTimer <= 0f)
        {
            GenerateScore();
            //gameManager.SpawnUICoin(this.owner,this.transform.position,moneyReward);

            GameObject scoreTextFeedback = (GameObject)Instantiate(scoreGainFeedbackPrefab.gameObject, this.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            scoreTextFeedback.GetComponent<TextMesh>().text = "+" + this.scoreReward.ToString();
            Destroy(scoreTextFeedback, 3.0f);
            Destroy(this.gameObject);

			gameManager.ChangeScore(this.scoreReward, this.Owner ,this.lane);
        }
    }

    private void Die()
    {
        deathTimer -= Time.deltaTime;
        foreach (Material mat in materials)
        {
            mat.SetFloat("_Visibility", Mathf.Clamp01(deathTimer / deathAnimTime));
        }
        if (deathTimer <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void CustomDestroy()
    {
        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.GetComponent<Collider>().isTrigger = true;
        if (cityTile)
            cityTile.RemoveUnit(transform, owner);
        SetAiState(AiState.Die);
    }

    void OnDestroy()
    {
        if (OnDestruction != null)
            OnDestruction();
    }

    public void UpdateTarget()
    {
        target = cityTile.GetEnemyUnit(owner);
    }

	public void SetData(Vector3 targetPoint, PLAYERS owner, LANES lane)
    {
        movementDir = (new Vector3(targetPoint.x, transform.position.y, transform.position.z) - transform.position).normalized;
        this.owner = owner;
		this.lane = lane;
    }

    private void LaunchProjectile()
    {
        GameObject projParent = Instantiate(projParentPrefab, transform.position, Quaternion.identity) as GameObject;
        projParent.GetComponent<ProjParentScript>().SetOwner = this;
        projParent.GetComponent<ProjParentScript>().SetLifeTime = projectileFlightDuration;
        foreach (GameObject model in models)
        {
            Vector3 launchPos = model.transform.position + (model.transform.up * model.transform.lossyScale.y);
            GameObject projectile = Instantiate(projectilePrefab, model.transform.position + (model.transform.up * model.transform.lossyScale.y), Quaternion.identity) as GameObject;
            Vector3 throwDir = CalculateProjectileDir(launchPos, target.position + (target.up * target.lossyScale.y), projectileFlightDuration);
            projectile.GetComponent<Rigidbody>().AddForce(throwDir, ForceMode.VelocityChange);
            projectile.gameObject.layer = gameObject.layer;
            projectile.gameObject.layer = owner == PLAYERS.PLAYER1 ? 16 : 17;
            projectile.transform.SetParent(projParent.transform);
        }
        /*
        foreach (ParticleSystem attackParticle in attackParticles)
        {
            attackParticle.Play();
        }
        */
    }

    private Vector3 CalculateProjectileDir(Vector3 origin, Vector3 target, float flightTime)
    {
        Vector3 diffVec = target - origin;
        Vector3 diffVecH = new Vector3(diffVec.x, 0, 0);

        // Calculate h and v
        float x = diffVecH.magnitude / flightTime;
        float y = diffVec.y / flightTime + 0.5f * -Physics.gravity.y * flightTime;
        float z = diffVec.y / flightTime + 0.5f * -Physics.gravity.z * flightTime;

        // create result vector for calculated starting speed
        Vector3 result = diffVecH.normalized;
        result *= x;
        result.y = y;
        result.z = z;

        return result;
    }

    public void DecreaseStrength()
    {
        unitStrength--;
    }

    public bool CheckDeath()
    {
        if (unitStrength <= 0)
        {
            CustomDestroy();
            return true;
        }
        return false;
    }

    void SetAiState(AiState state)
    {
        foreach (GameObject model in models)
        {
            model.GetComponent<Animator>().SetBool(currentState.ToString(), false);
            model.GetComponent<Animator>().SetBool(state.ToString(), true);
        }
        currentState = state;
    }

	void GenerateScore()
	{
		switch(owner)
		{
			case PLAYERS.PLAYER1:
				//gameManager.Player1Score += scoreReward;
				break;
			case PLAYERS.PLAYER2:
				//gameManager.Player2Score += scoreReward;
				break;
		}
	}

	public void AddFreezeBuff(Buff b)
	{
		if(currentIceBlock == null)
		{
			currentIceBlock = (GameObject)Instantiate(iceBlockPrefab);
			currentIceBlock.transform.SetParent(this.transform,false);

			float sphereSize = GetComponent<SphereCollider>().radius;
			currentIceBlock.transform.localScale = new Vector3(sphereSize,sphereSize,sphereSize);
		}

		buffList.AddBuff(b);
        foreach (GameObject model in models)
        {
            model.GetComponent<Animator>().speed = 0.0f;
        }
	}

    //unfreeze
#if TOUCH_INPUT
	public void PenetratingTouchEnd()
#else
    public void OnMouseUp()
#endif
    {
        buffList.RemoveBuffs(BUFF_TYPES.UNIT_FREEZE);

        foreach (GameObject model in models)
        {
            model.GetComponent<Animator>().speed = 1.0f;
        }

        if (currentIceBlock != null)
        {
            currentIceBlock.GetComponent<IceBlock>().Shatter();
            Destroy(currentIceBlock);
            currentIceBlock = null;
        }
    }
}