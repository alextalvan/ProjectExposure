using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityTileTrigger : GameManagerSearcher {

	List<Transform> unitsP1 = new List<Transform>();
	List<Transform> unitsP2 = new List<Transform>();
    bool rewarded = false;

	// Use this for initialization
	void Start () {
		
	}

	public void AddUnit(Transform unit, PLAYERS player) {
		if (player == PLAYERS.PLAYER1)
			unitsP1.Add (unit);
		else
			unitsP2.Add (unit);
        if (rewarded)
            rewarded = false;
    }

	public void RemoveUnit(Transform unit, PLAYERS player) {
        UnitAI unitAi = unit.GetComponent<UnitAI>();
        if (player == PLAYERS.PLAYER1)
        {
            unitsP1.Remove(unit);
        }
		else
        {
            unitsP2.Remove(unit);
        }
        if (!rewarded && unitAi.Won && unitsP1.Count == 0 && unitsP2.Count == 0)
        {
            gameManager.ChangeScore(gameManager.GetWaveWinScore, unitAi.Owner, unitAi.lane);
            rewarded = true;
        }
    }

    public bool HasHostileUnits(PLAYERS player) {
		if (player == PLAYERS.PLAYER1)
			return unitsP2.Count > 0;
		else
			return unitsP1.Count > 0;
	}

    public Transform GetEnemyUnit(PLAYERS player)
    {
        if (player == PLAYERS.PLAYER1)
        {
            if (unitsP2.Count > 0)
                return unitsP2[Random.Range(0, unitsP2.Count)];
            else
                return null;
        }
        else
        {
            if (unitsP1.Count > 0)
                return unitsP1[Random.Range(0, unitsP1.Count)];
            else
                return null;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {

		UnitAI unitComp = col.gameObject.GetComponent<UnitAI>();

		if(unitComp)
		{
			AddUnit (col.transform, unitComp.Owner);
			unitComp.CityTile = this;
		}
	}
}
