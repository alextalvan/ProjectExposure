using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityTileTrigger : MonoBehaviour {

	private bool hasP1Units = false;
	private bool hasP2Units = false;
	List<Transform> unitsP1;
	List<Transform> unitsP2;

	// Use this for initialization
	void Start () {
		unitsP1 = new List<Transform>();
		unitsP2 = new List<Transform>();
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
			return hasP2Units;
		else
			return hasP1Units;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		AddUnit (col.transform, col.transform.GetComponent<UnitAI> ().Owner);
		col.GetComponent<UnitAI> ().CityTile = this;
	}
}
