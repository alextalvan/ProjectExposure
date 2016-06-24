using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UnitAI : GameManagerSearcher
{
    public enum UnitType { Tank = 0, Melee = 1, Range = 2 };
    [SerializeField]
    private UnitType type = UnitType.Melee;
    public UnitType Type { get { return type; } }

    //temp for heim
    static public int[,] damageMatrix = { { 20, 10, 30 }, { 30, 20, 10 }, { 10, 30, 20 } };

    enum AiState { Run, Fight, Cheer, Die };
    private AiState currentState = AiState.Run;
    public bool Won { get { return currentState == AiState.Cheer; } }
    public int Health { get { return unitHealth; } }

    [SerializeField]
    int unitHealth = 1;
    [SerializeField]
    float attackRange = 1;
    [SerializeField]
    float unitSpeed = 1f;

    [SerializeField]
    float attackCoolDown = 1f;
    [SerializeField]
    float cheerAnimTime = 1f;
    [SerializeField]
    float deathAnimTime = 1f;

    [SerializeField]
    int moneyReward = 1;

    [SerializeField]
    List<GameObject> models = new List<GameObject>();
    private List<Material> materials = new List<Material>();

    [SerializeField]
    GameObject projParentPrefab;
    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    float projectileFlightDuration = 1f;

    [SerializeField]
    GameObject conversionPrefab;

    public BuffList buffList = new BuffList();

    private float cheerTimer;
    private float deathTimer;
    private float attackTimer;

    private PLAYERS owner;
    public PLAYERS Owner { get { return owner; } }

    public LANES lane;

    private Vector3 movementDir;
    private Transform target = null;
    public delegate void DestructionDelegate();
    public event DestructionDelegate OnDestruction = null;

    [SerializeField]
    CoinPickup coinSpawnPrefab;

    [SerializeField]
    GameObject iceBlockPrefab;
    GameObject currentIceBlock = null;

    [SerializeField]
    Sprite unitIcon;

    [SerializeField]
    GameObject healthBarPrefab;
    private HealthBar healthBar;
    float maxUnitHealth;

    private Transform oppositeLane = null;


    protected override void Awake()
    {
        base.Awake();
        attackTimer = attackCoolDown * 0.5f;
        cheerTimer = cheerAnimTime;
        deathTimer = deathAnimTime;
        maxUnitHealth = unitHealth;
        gameManager.UnitsAlive += 1;
    }

    void Start()
    {
        foreach (GameObject model in models)
        {
            materials.Add(model.transform.GetChild(0).GetComponent<Renderer>().material);
        }
        PLAYERS enemy = owner == PLAYERS.PLAYER1 ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1;
        oppositeLane = gameManager.playerData[enemy].unitGroups[(int)lane];
        //orientation
        Vector3 worldUp = Physics.gravity.normalized * -1.0f;
        float heightDiff = Vector3.Dot(worldUp, transform.position + movementDir) - Vector3.Dot(worldUp, transform.position);
        Vector3 lookTargetPoint = transform.position + movementDir - heightDiff * worldUp;

        Quaternion targetRot = Quaternion.LookRotation(lookTargetPoint - transform.position, worldUp);
        transform.rotation = targetRot;
        GameObject healthBarObj = Instantiate(healthBarPrefab, transform.position + (Vector3.up * models[0].transform.lossyScale.y * (float)models.Count * 0.66f) - Vector3.right * 0.2f + (-Vector3.forward), Quaternion.identity) as GameObject;
        healthBar = healthBarObj.GetComponent<HealthBar>();
        healthBar.transform.parent = transform.GetChild(0);
        healthBar.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = unitIcon;
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
        if (target = GetEnemyInRange())
        {
            SetAiState(AiState.Fight);
            return;
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

    private Transform GetEnemyInRange()
    {
        Transform targetEnemy = null;
        float minDist = Mathf.Infinity;
        foreach (Transform enemy in oppositeLane)
        {
            float dist = Vector3.Distance(enemy.position, transform.position);
            if (Vector3.Distance(enemy.position, transform.position) < attackRange && dist < minDist && !enemy.GetComponent<UnitAI>().Won)
            {
                minDist = dist;
                targetEnemy = enemy;
            }
        }
        return targetEnemy;
    }

    private void Fight()
    {
        attackTimer -= Time.deltaTime;
        if (!target)
        {
            if (!(target = GetEnemyInRange()))
            {
                SetAiState(AiState.Run);
                return;
            }
        }
        else
        {
            if (target && attackTimer <= 0f)
            {
                target = GetEnemyInRange();
                LaunchProjectile();
                attackTimer = attackCoolDown;
            }

            //orientation
            Vector3 worldUp = Physics.gravity.normalized * -1.0f;
            float heightDiff = Vector3.Dot(worldUp, target.position) - Vector3.Dot(worldUp, transform.position);
            Vector3 lookTargetPoint = target.position - heightDiff * worldUp;

            Quaternion targetRot = Quaternion.LookRotation(lookTargetPoint - transform.position, worldUp);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 0.1f);
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
            Destroy(this.gameObject);
            gameManager.ChangeScore(1, this.Owner, this.lane);
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
        SetAiState(AiState.Die);
    }

    public void StartCheer()
    {
        healthBar.gameObject.SetActive(false);
        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.GetComponent<Collider>().isTrigger = true;
        SetAiState(AiState.Cheer);
    }

    void OnDestroy()
    {
        if (OnDestruction != null)
            OnDestruction();
        gameManager.UnitsAlive -= 1;
    }

    public void NullifyTarget()
    {
        target = null;
    }

    public void SetData(float xDir, PLAYERS owner, LANES lane)
    {
        movementDir = new Vector3(xDir, 0, 0).normalized;
        this.owner = owner;
        this.lane = lane;
    }

    private void LaunchProjectile()
    {
        GameObject projParent = Instantiate(projParentPrefab, transform.position, Quaternion.identity) as GameObject;
        projParent.GetComponent<ProjParentScript>().SetOwner = this;
        foreach (GameObject model in models)
        {
            Vector3 launchPos = model.transform.position + (model.transform.up * model.transform.lossyScale.y);
            GameObject projectile = Instantiate(projectilePrefab, model.transform.position + (model.transform.up * model.transform.lossyScale.y), Quaternion.identity) as GameObject;
            Vector3 throwDir = CalculateProjectileDir(launchPos, target.position, projectileFlightDuration);
            projectile.GetComponent<Rigidbody>().AddForce(throwDir, ForceMode.VelocityChange);
            projectile.gameObject.layer = gameObject.layer;
            projectile.gameObject.layer = owner == PLAYERS.PLAYER1 ? 16 : 17;
            projectile.transform.SetParent(projParent.transform);
        }
    }

    private Vector3 CalculateProjectileDir(Vector3 origin, Vector3 target, float flightTime)
    {
        Vector3 diffVec = target - origin;
        Vector3 diffVecH = new Vector3(diffVec.x, 0, 0);

        // Calculate h and v
        float x = diffVecH.magnitude / flightTime;
        float y = diffVec.y / flightTime + 0.5f * -Physics.gravity.y * flightTime;
        float z = diffVec.z / flightTime + 0.5f * -Physics.gravity.z * flightTime;

        // create result vector for calculated starting speed
        Vector3 result = diffVecH.normalized;
        result *= x;
        result.y = y;
        result.z = z;

        return result;
    }

    public bool DecreaseHealth(int amount)
    {
        unitHealth -= amount;
        if (healthBar)
            healthBar.SetLength(unitHealth / maxUnitHealth);

        if (unitHealth <= 0)
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

    public void AddFreezeBuff(Buff b)
    {
        if (currentIceBlock == null)
        {
            currentIceBlock = (GameObject)Instantiate(iceBlockPrefab);
            currentIceBlock.transform.SetParent(this.transform, false);

            float sphereSize = GetComponent<SphereCollider>().radius;
            currentIceBlock.transform.localScale = new Vector3(sphereSize, sphereSize, sphereSize);
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