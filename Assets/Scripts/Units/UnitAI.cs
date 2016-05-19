using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitAI : GameManagerSearcher 
{
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
	int scoreReward = 10;

    private int currentWP = 0;
    private int pathLength;
	private bool fighting = false;
	private bool allowCollision = true;
	private PLAYERS owner;

	
	// Update is called once per frame
	void Update ()
    {
        Move ();
		Fight ();
    }

	void Move()
    {
		if (!fighting && pathLength > currentWP && !HasUnitInFront())
        {
			Vector3 dirVec = new Vector3(path[currentWP].x, transform.position.y, path[currentWP].z) - transform.position;

			transform.position += dirVec.normalized * unitSpeed;

			if (dirVec.magnitude <= distanceToWP)
            {
                currentWP++;
				if (pathLength <= currentWP && !fighting)
                {
					GenerateScore();
					Destroy (gameObject);
                }
            }
        }
    }

	bool HasUnitInFront() {
		RaycastHit hit;
		LayerMask layer = owner == PLAYERS.PLAYER1 ? LayerMask.GetMask("UnitP1") : LayerMask.GetMask("UnitP2");
		return Physics.Raycast(transform.position, (path[currentWP] - transform.position).normalized, rcDist, layer);
	}

	void Fight() {
		if (fighting) {
			animationTime -= Time.deltaTime;
			if (animationTime <= 0f) {
				fighting = false;
				Destroy (gameObject);
			}
		}
	}

	public void SetData(List<Vector3> unitPath, PLAYERS owner)
    {
        path = unitPath;
        pathLength = path.Count;
		this.owner = owner;
    }

	void OnCollisionEnter(Collision col) 
	{
		if(!allowCollision)
			return;

		allowCollision = false;

		if (col.transform.GetComponent<UnitAI> ())
			fighting = true;
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
