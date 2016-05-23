using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SmogCard : ActionCard 
{
	[SerializeField]
	float effectDuration = 10.0f;

	[SerializeField]
	int tapCountToUndo = 10;

	protected override bool CalculatePlayCondition ()
	{

		if(!CheckMoneyCost())
			return false;

		return EnemyHasBuildings();
	}

	protected override void DoCardEffect ()
	{
		List<EnergyBuilding> candidateBuildings = new List<EnergyBuilding>();
		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];

		foreach(HexagonTile tile in enemyData.tiles)
		{
			if(tile.CurrentEnergyBuilding!=null)
				candidateBuildings.Add(tile.CurrentEnergyBuilding);
		}

		BuildingStunBuff b = new BuildingStunBuff(tapCountToUndo,effectDuration);
		candidateBuildings[Random.Range(0,candidateBuildings.Count)].buffList.AddBuff(b);
		//Destroy(this.gameObject);
	}

}

