using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UnitAI : GameManagerSearcher 
{
	enum AiState { Idle, Run, Fight, Wander, Cheer, Die };
	private AiState currentState = AiState.Run;

	[SerializeField]
	int unitStrength = 1;
	[SerializeField]
	float unitSpeed = 1f;
    [SerializeField]
    float waypointSwitchThreshold = 1f;
	[SerializeField]
	float rayCastDist = 1f;

	[SerializeField]
	float fightAnimTime = 1f;
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
    float speedBuffMod = 2f;
    [SerializeField]
    float speedBuffDuration = 2f;

    [SerializeField]
    GameObject model;
    private Material mat;

    private Animator anim;

	public BuffList buffList = new BuffList();

	private float fightTimer;
	private float wanderTimer;
	private float cheerTimer;
    private float deathTimer;
    
    private int currentWP = 0;
    private int pathLength;
	private bool allowCollision = true;
	private PLAYERS owner;
	public PLAYERS Owner { get { return owner; } }
    SpeedBuff speedUpBuff = null;
    bool speedUp = false;

    private List<Vector3> path;
	private CityTileTrigger cityTile = null;
	public CityTileTrigger CityTile { get { return cityTile; } set { cityTile = value; } }
    public delegate void DestructionDelegate();
    public event DestructionDelegate OnDestruction = null;

	[SerializeField]
	CoinPickup coinSpawnPrefab;

    private int fightingTargetStrength;

	void Start()
    {
        speedUpBuff = new SpeedBuff(speedBuffMod, speedBuffDuration);
        wanderTimer = wanderAnimTime;
		fightTimer = fightAnimTime;
		cheerTimer = cheerAnimTime;
        deathTimer = deathAnimTime;
        anim = transform.GetChild(0).GetComponent<Animator>();
        mat = model.GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update ()
    {
		buffList.Update ();
		Behave ();
    }

	void Behave() 
	{
		switch (currentState) {
		case AiState.Idle:
			Idle ();
			break;
		case AiState.Run:
			Run ();
			break;
		case AiState.Fight:
			Fight ();
			break;
		case AiState.Wander:
			Wander ();
			break;
		case AiState.Cheer:
			Cheer ();
			break;
        case AiState.Die:
            Die();
            break;
        }
	}

    void Idle() {
		if (!HasUnitInFront ())
            SetAiState(AiState.Run);
	}

	float CalculateSpeed()
	{
		float speed = unitSpeed;

		foreach(Buff buff in buffList.buffs)
		{
			switch(buff.type)
			{
				case BUFF_TYPES.UNIT_FREEZE:
					return 0.0f;
				
				case BUFF_TYPES.UNIT_SPEED_MODIFIER:
					speed *= ((SpeedBuff)buff).speedModifier;
					break;
					
			}
		}
		return speed;
	}

    private void Run()
	{
		if (HasUnitInFront ())
        {
            SetAiState(AiState.Idle);
            return;
		}
		if (currentWP == pathLength && !cityTile.HasHostileUnits (owner))
        {
            SetAiState(AiState.Wander);
            return;
		}
		if(currentWP == pathLength)
			return;
		
		Vector3 dirVec = path[currentWP] - transform.position;
		float distanceToNextWP = dirVec.magnitude;
		float speed = CalculateSpeed();

		transform.position += dirVec.normalized * speed;


		//orientation
		Vector3 worldUp = Physics.gravity.normalized * -1.0f;
		float heightDiff = Vector3.Dot(worldUp,path[currentWP]) - Vector3.Dot(worldUp,transform.position);
		Vector3 lookTargetPoint = path[currentWP] -  heightDiff * worldUp;

		Quaternion targetRot = Quaternion.LookRotation(lookTargetPoint - transform.position,worldUp);
		transform.rotation = Quaternion.Slerp(transform.rotation,targetRot,0.05f);

		if (distanceToNextWP <= waypointSwitchThreshold) {
			currentWP++;
		}
    }

    private void Fight() {
		fightTimer -= Time.deltaTime;
		if (fightTimer <= 0f) {
			if (this.unitStrength > fightingTargetStrength) {
				transform.GetComponent<Rigidbody> ().isKinematic = true;
                transform.GetComponent<Collider>().isTrigger = true;
                SetAiState(AiState.Cheer);
            }
            else
            {
                transform.GetComponent<Rigidbody>().isKinematic = true;
                transform.GetComponent<Collider>().isTrigger = true;
                SetAiState(AiState.Die);
            }
		}
	}

    private void Wander() {
		wanderTimer -= Time.deltaTime;
		if (wanderTimer <= 0f) {
			transform.GetComponent<Rigidbody> ().isKinematic = true;
            transform.GetComponent<Collider>().isTrigger = true;
            SetAiState(AiState.Cheer);
        } else if (cityTile.HasHostileUnits (owner)) {
			wanderTimer = wanderAnimTime;
            SetAiState(AiState.Run);
        }
	}

    private void Cheer() {
		cheerTimer -= Time.deltaTime;
        mat.SetFloat("_Visibility", Mathf.Clamp01(cheerTimer / cheerAnimTime));
        if (cheerTimer <= 0f) {
			GenerateScore ();
			//gameManager.SpawnUICoin(this.owner,this.transform.position,moneyReward);

			GameObject coin = (GameObject)Instantiate(coinSpawnPrefab.gameObject,this.transform.position,Quaternion.identity);
			CoinPickup pickupComp = coin.GetComponent<CoinPickup>();
			pickupComp.owner = this.owner;
			pickupComp.StartGlide();

			Destroy(this.gameObject);
		}
    }

    private void Die()
    {
        deathTimer -= Time.deltaTime;
        mat.SetFloat("_Visibility", Mathf.Clamp01(deathTimer/deathAnimTime));
        if (deathTimer <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void CustomDestroy()
    {
        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.GetComponent<Collider>().isTrigger = true;
        SetAiState(AiState.Die);
    }

    void OnDestroy()
	{
		if(cityTile)
			cityTile.RemoveUnit (transform, owner);
        if (OnDestruction != null)
            OnDestruction();
	}

	public void SetData(List<Vector3> unitPath, PLAYERS owner)
    {
		path = new List<Vector3>(unitPath);
        pathLength = path.Count;
		this.owner = owner;
	}

	bool HasUnitInFront() 
	{
		if(currentWP == pathLength)
			return false;

		LayerMask layer = owner == PLAYERS.PLAYER1 ? LayerMask.GetMask("UnitP1","Units_ignore_units") : LayerMask.GetMask("UnitP2","Units_ignore_units");
		return Physics.Raycast(transform.position, (path[currentWP] - transform.position).normalized, rayCastDist, layer);
	}

	void OnCollisionEnter(Collision col) 
	{
		if(!allowCollision)
			return;

		UnitAI otherAI = col.collider.gameObject.GetComponent<UnitAI> ();
		if (otherAI)
        {
            SetAiState(AiState.Fight);
            allowCollision = false;
			fightingTargetStrength = otherAI.unitStrength;
		}
	}

    void SetAiState(AiState state)
    {
        anim.SetBool(currentState.ToString(), false);
        currentState = state;
        anim.SetBool(currentState.ToString(), true);
    }

	void GenerateScore()
	{
		switch(owner)
		{
			case PLAYERS.PLAYER1:
				gameManager.Player1Score += scoreReward;
				break;
			case PLAYERS.PLAYER2:
				gameManager.Player2Score += scoreReward;
				break;
		}
	}

	//unfreeze
	#if TOUCH_INPUT
	void PenetratingTouchEnd()
	#else
	void OnMouseUp()
	#endif
	{
		buffList.RemoveBuffs(BUFF_TYPES.UNIT_FREEZE);
		GetComponent<TemporaryBlink>().Stop();

        if (!speedUp)
        {
            buffList.AddBuff(speedUpBuff);
            speedUpBuff.currentDuration = 0.0f;
            speedUp = true;
            transform.GetComponent<ParticleSystem>().Play();
            speedUpBuff.OnExpiration += () => { speedUp = false; };
        }
	}
}