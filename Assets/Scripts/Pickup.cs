using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pickup : GameManagerSearcher {


	PLAYERS Owner;
	PlayerGameData enemyData;

	[SerializeField]
	float smogDuration = 10.0f;

	[SerializeField]
	int smogTapsForUndo = 10;

	[SerializeField]
	GameObject smogPrefab;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetOwner(PLAYERS owner)
	{
		Owner = owner;
		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];
	}

	bool EnemyHasUnits()
	{
		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];
		foreach(Transform tr in enemyData.unitGroups)
		{
			if(tr.childCount > 0)
				return true;
		}
		return false;
	}

	bool EnemyHasBuildings()
	{
		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];
		foreach(HexagonTile tile in enemyData.tiles)
		{
			if(tile.CurrentEnergyBuilding!=null)
				return true;
		}
		return false;
	}

	bool SmogCondition()
	{
		
		foreach (HexagonTile tile in enemyData.tiles)
		{
			if (tile.CurrentEnergyBuilding != null && !(tile.CurrentEnergyBuilding.buffList.HasBuff(BUFF_TYPES.BUILDING_TEMPORARY_DISABLE)))
				return true;
		}

		return false;
	}

	void SmogEffect()
	{
		List<EnergyBuilding> candidateBuildings = new List<EnergyBuilding>();
		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];

		foreach(HexagonTile tile in enemyData.tiles)
		{
			if(tile.CurrentEnergyBuilding!=null)
				candidateBuildings.Add(tile.CurrentEnergyBuilding);
		}



		BuildingStunBuff b = new BuildingStunBuff(smogTapsForUndo,smogDuration);
		EnergyBuilding building = candidateBuildings[Random.Range(0,candidateBuildings.Count)];
		building.buffList.AddBuff(b);
		building.GetComponent<UnitSpawner>().enabled = false;
		building.smog = (GameObject)Instantiate(smogPrefab, building.transform.position + Vector3.up * 2f - Vector3.forward * 15f, Quaternion.identity);
		building.smog.transform.parent = building.transform;
	}
}
