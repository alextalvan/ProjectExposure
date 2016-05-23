using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitAI : GameManagerSearcher 
{
	enum AiState { Idle, Run, Fight, Wander, Cheer };
	private AiState currentState = AiState.Run;

	[SerializeField]
	int unitStrength = 1;
	[SerializeField]
	float unitSpeed = 1f;
    [SerializeField]
    float distanceToWP;
	[SerializeField]
	float rayCastDist = 1f;

	[SerializeField]
	float fightAnimTime = 1f;
	[SerializeField]
	float wanderAnimTime = 1f;
	[SerializeField]
	float cheerAnimTime = 1f;

	[SerializeField]
	int scoreReward = 10;

	public BuffList buffList = new BuffList();

	private float fightTimer;
	private float wanderTimer;
	private float cheerTimer;

	//temp for sprint meeting
	Color baseColor;

    private int currentWP = 0;
    private int pathLength;
	private bool allowCollision = true;
	private PLAYERS owner;
	public PLAYERS Owner { get { return owner; } }

	private List<Vector3> path;
	private CityTileTrigger cityTile = null;
	public CityTileTrigger CityTile { set { cityTile = value; } }

	void Start() {
		wanderTimer = wanderAnimTime;
		fightTimer = fightAnimTime;
		cheerTimer = cheerAnimTime;
		baseColor = GetComponent<Renderer>().material.color;
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
		}
	}

	void Idle() {
		if (!HasUnitInFront ())
			currentState = AiState.Run;
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


	void Run()
	{
		if (HasUnitInFront ()) {
			currentState = AiState.Idle;
			return;
		}
		if (currentWP == pathLength && !cityTile.HasHostileUnits (owner)) {
			currentState = AiState.Wander;
			return;
		}
		if(currentWP == pathLength)
			return;
		
		Vector3 dirVec = new Vector3(path[currentWP].x, transform.position.y, path[currentWP].z) - transform.position;

		float speed = CalculateSpeed();

		transform.position += dirVec.normalized * speed;

		if (dirVec.magnitude <= distanceToWP) {
			currentWP++;
		}
    }

	void Fight() {
		fightTimer -= Time.deltaTime;
		if (fightTimer <= 0f) {
			unitStrength--;
			if (unitStrength > 0) {
				transform.GetComponent<Rigidbody> ().isKinematic = true;
				transform.GetComponent<Collider> ().isTrigger = true;
				currentState = AiState.Cheer;
			} else {
				Destroy(this.gameObject);
			}
		}
	}

	void Wander() {
		wanderTimer -= Time.deltaTime;
		if (wanderTimer <= 0f) {
			transform.GetComponent<Rigidbody> ().isKinematic = true;
			transform.GetComponent<Collider> ().isTrigger = true;
			currentState = AiState.Cheer;
		} else if (cityTile.HasHostileUnits (owner)) {
			wanderTimer = wanderAnimTime;
			currentState = AiState.Run;
		}
	}

	void Cheer() {
		cheerTimer -= Time.deltaTime;
		if (cheerTimer <= 0f) {
			GenerateScore ();
			Destroy(this.gameObject);
		}
	}

	void OnDestroy()
	{
		if(cityTile)
			cityTile.RemoveUnit (transform, owner);
	}

	public void SetData(List<Vector3> unitPath, PLAYERS owner)
    {
        path = unitPath;
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
		
		if (col.collider.gameObject.GetComponent<UnitAI> ()) {
			currentState = AiState.Fight;
			allowCollision = false;
		}
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
	void OnMouseUp()
	{
		buffList.RemoveBuffs(BUFF_TYPES.UNIT_FREEZE);
		GetComponent<Renderer>().material.color = baseColor;
	}
}