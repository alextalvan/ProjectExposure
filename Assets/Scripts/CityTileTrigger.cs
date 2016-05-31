using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityTileTrigger : MonoBehaviour {

	List<Transform> unitsP1 = new List<Transform>();
	List<Transform> unitsP2 = new List<Transform>();

	// Use this for initialization
	void Start () {
		
	}

	public void AddUnit(Transform unit, PLAYERS player) {
		if (player == PLAYERS.PLAYER1)
			unitsP1.Add (unit);
		else
			unitsP2.Add (unit);
	}

	public void RemoveUnit(Transform unit, PLAYERS player) {
		if (player == PLAYERS.PLAYER1)
			unitsP1.Remove (unit);
		else
			unitsP2.Remove (unit);
	}

	public bool HasHostileUnits(PLAYERS player) {
		if (player == PLAYERS.PLAYER1)
			return unitsP2.Count > 0;
		else
			return unitsP1.Count > 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		AddUnit (col.transform, col.transform.GetComponent<UnitAI> ().Owner);
		col.GetComponent<UnitAI> ().CityTile = this;
	}
}
