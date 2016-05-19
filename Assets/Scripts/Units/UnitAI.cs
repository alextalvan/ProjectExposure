using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitAI : GameManagerSearcher 
{
	enum AiState { Idle, Run, Fight, Wander, Cheer };
	AiState currentState = AiState.Run;
	[SerializeField]
	float unitSpeed = 1f;
    [SerializeField]
    float distanceToWP;
	[SerializeField]
	float animationTime = 1f;
	[SerializeField]
	float rcDist = 1f;
    private List<Vector3> path;
	[SerializeField]
	float cheerTime = 1f;
	[SerializeField]
	float freezeTime = 1f;
	private float freezeTimer;
	[SerializeField]
	int scoreReward = 10;

    private int currentWP = 0;
    private int pathLength;
	private bool allowCollision = true;
	private PLAYERS owner;
	public PLAYERS Owner { get { return owner; } }

	private CityTileTrigger cityTile;
	public CityTileTrigger CityTile { set { cityTile = value; } }
	
	// Update is called once per frame
	void Update ()
    {
		PickState();
		Behave();
    }

	void PickState() 
	{
		bool hasUnitInFront = HasUnitInFront();
		switch (currentState) {
		case AiState.Idle:
			if (freezeTimer > 0f) {
				freezeTimer -= Time.deltaTime;
				if (freezeTimer <= 0f)
					currentState = AiState.Run;
			}
			break;
		case AiState.Run:
			if (hasUnitInFront)
				currentState = AiState.Idle;
			break;
		case AiState.Fight:
			break;
		case AiState.Wander:
			break;
		case AiState.Cheer:
			break;
		}
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
		
	}

	void Run()
    {
		Vector3 dirVec = new Vector3(path[currentWP].x, transform.position.y, path[currentWP].z) - transform.position;

		transform.position += dirVec.normalized * unitSpeed;

		if (dirVec.magnitude <= distanceToWP)
			currentWP++;
		if (pathLength <= currentWP) {
			GenerateScore ();
			CustomDestroy ();
		}
    }

	void Fight() {
		/*
			if (fighting) {
				animationTime -= Time.deltaTime;
				if (animationTime <= 0f) {
					fighting = false;
					CustomDestroy ();
				}
			} else if (cheer) {
				if (cityTile.HasHostileUnits (owner)) {
					cheer = false;
				}
			}
			*/
	}

	void Wander() {

	}

	void Cheer() {

	}

	public void Freeze() {
		currentState = AiState.Idle;
		freezeTimer = freezeTime;
	}

	void CustomDestroy() {
		Destroy (gameObject);
		cityTile.RemoveUnit (transform, owner);
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
		return Physics.Raycast(transform.position, (path[currentWP] - transform.position).normalized, rcDist, layer);
	}

	void OnCollisionEnter(Collision col) 
	{
		if(!allowCollision)
			return;

		allowCollision = false;

		//if (col.transform.GetComponent<UnitAI> ())
		//	fighting = true;
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