using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SmogCard : ActionCard 
{
	[SerializeField]
	float effectDuration = 10.0f;

	[SerializeField]
	int tapCountToUndo = 10;

	[SerializeField]
	Color materialTint = Color.red;

	protected override bool CalculatePlayCondition ()
	{
		if(!enabled)
			return false;

//		if(!CheckMoneyCost())
//			return false;

		return EnemyHasBuildings();
	}

	protected override void DoCardEffect ()
	{
		base.DoCardEffect();

		List<EnergyBuilding> candidateBuildings = new List<EnergyBuilding>();
		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];

		foreach(HexagonTile tile in enemyData.tiles)
		{
			if(tile.CurrentEnergyBuilding!=null)
				candidateBuildings.Add(tile.CurrentEnergyBuilding);
		}

		BuildingStunBuff b = new BuildingStunBuff(tapCountToUndo,effectDuration);
		EnergyBuilding building = candidateBuildings[Random.Range(0,candidateBuildings.Count)];
		building.buffList.AddBuff(b);
		building.GetComponent<UnitSpawner>().enabled = false;

		building.GetComponent<TemporaryBlink>().Begin(effectDuration);

		Destroy(this.gameObject);
	}

}

