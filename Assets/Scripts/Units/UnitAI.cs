using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitAI : GameManagerSearcher 
{
	enum AiState { Idle, Freeze, Run, Fight, Wander, Cheer };
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
	float freezeTime = 1f;
	[SerializeField]
	float fightAnimTime = 1f;
	[SerializeField]
	float wanderAnimTime = 1f;
	[SerializeField]
	float cheerAnimTime = 1f;

	[SerializeField]
	int scoreReward = 10;

	private float freezeTimer;
	private float fightTimer;
	private float wanderTimer;
	private float cheerTimer;

	private bool isOnCityTile = false;
    private int currentWP = 0;
    private int pathLength;
	private bool allowCollision = true;
	private PLAYERS owner;
	public PLAYERS Owner { get { return owner; } }

	private List<Vector3> path;
	private CityTileTrigger cityTile;
	public CityTileTrigger CityTile { set { cityTile = value; } }

	void Start() {
		wanderTimer = wanderAnimTime;
		fightTimer = fightAnimTime;
		cheerTimer = cheerAnimTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
		Debug.Log (currentState.ToString ());
		Behave();
    }

	void Behave() 
	{
		switch (currentState) {
		case AiState.Idle:
			Idle ();
			break;
		case AiState.Freeze:
			Freeze ();
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

	void Freeze () {
		if (freezeTimer > 0f) {
			freezeTimer -= Time.deltaTime;
			if (freezeTimer <= 0f) {
				freezeTimer = 0;
				currentState = AiState.Run;
			}
		}
	}

	void Run()
	{
		Vector3 dirVec = new Vector3(path[currentWP].x, transform.position.y, path[currentWP].z) - transform.position;

		transform.position += dirVec.normalized * unitSpeed;

		if (dirVec.magnitude <= distanceToWP) {
			currentWP++;

			if (HasUnitInFront())
				currentState = AiState.Idle;
			if (currentWP == pathLength - 1 && !cityTile.HasHostileUnits(owner))
				currentState = AiState.Wander;
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
				CustomDestroy ();
			}
		}
	}

	void Wander() {
		wanderTimer -= Time.deltaTime;
		Debug.Log(cityTile.HasHostileUnits (owner));
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
			CustomDestroy ();
		}
	}

	public void FreezeUnit() {
		currentState = AiState.Idle;
		freezeTimer = freezeTime;
	}

	void CustomDestroy() {
		cityTile.RemoveUnit (transform, owner);
		Destroy (gameObject);
	}

	public void SetData(List<Vector3> unitPath, PLAYERS owner)
    {
        path = unitPath;
        pathLength = path.Count;
		this.owner = owner;
	}

	bool HasUnitInFront() {
		RaycastHit hit;
		LayerMask layer = owner == PLAYERS.PLAYER1 ? LayerMask.GetMask("UnitP1") : LayerMask.GetMask("UnitP2");
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
}