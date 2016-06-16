using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pickup : GameManagerSearcher {


	PLAYERS Owner;
	PlayerGameData enemyData;

	[SerializeField]
	float freezeDuration = 10.0f;

	[SerializeField]
	GameObject freezePrefab;


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
		foreach(Transform tr in enemyData.unitGroups)
		{
			if(tr.childCount > 0)
				return true;
		}
		return false;
	}

	bool EnemyHasBuildings()
	{
		foreach(HexagonTile tile in enemyData.tiles)
		{
			if(tile.CurrentEnergyBuilding!=null)
				return true;
		}
		return false;
	}

	bool FreezeCondition()
	{
		
		foreach (HexagonTile tile in enemyData.tiles)
		{
			if (tile.CurrentEnergyBuilding != null && !(tile.CurrentEnergyBuilding.buffList.HasBuff(BUFF_TYPES.BUILDING_TEMPORARY_DISABLE)))
				return true;
		}

		return false;
	}

	void FreezeEffect()
	{
		List<EnergyBuilding> candidateBuildings = new List<EnergyBuilding>(6);

		foreach(HexagonTile tile in enemyData.tiles)
		{
			if(tile.CurrentEnergyBuilding!=null)
				candidateBuildings.Add(tile.CurrentEnergyBuilding);
		}



		BuildingStunBuff b = new BuildingStunBuff(999,freezeDuration);
		//Buff b = new Buff(BUFF_TYPES.BUILDING_TEMPORARY_WEAKER_UNITS
		EnergyBuilding building = candidateBuildings[Random.Range(0,candidateBuildings.Count)];
		building.buffList.AddBuff(b);
		building.GetComponent<UnitSpawner>().enabled = false;
		building.smog = (GameObject)Instantiate(freezePrefab, building.transform.position + Vector3.up * 2f - Vector3.forward * 15f, Quaternion.identity);
		building.smog.transform.parent = building.transform;
	}


	bool QuakeCondition()
	{
		return EnemyHasBuildings();
	}

	void QuakeEffect()
	{
		for(int i=0; i < enemyData.tiles.Count - 1; ++i)
		{
			enemyData.tiles[i].SwapBuilding(enemyData.tiles[Random.Range(i+1,enemyData.tiles.Count)]);
		}
			
		Camera.main.GetComponent<CameraShake>().Shake();
		enemyData.currentInputState = INPUT_STATES.FREE;
		enemyData.RefreshAllTilesHighlight();
	}

	bool DiamondCondition()
	{
		return true;
	}

	void DiamondEffect()
	{
		float maxmoney = gameManager.currentStage.forcedMaxMoney;

		if(this.Owner == PLAYERS.PLAYER1)
			gameManager.Player1Money = maxmoney;
		else
			gameManager.Player2Money = maxmoney;
	}
}
