using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SmogCard : ActionCard 
{
    [SerializeField]
    GameObject smogPrefab;

	[SerializeField]
	float effectDuration = 10.0f;

	[SerializeField]
	int tapCountToUndo = 10;


	public override bool CalculatePlayCondition ()
	{
		if(!enabled)
			return false;

        //		if(!CheckMoneyCost())
        //			return false;

        //return EnemyHasBuildings();
        enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];
        foreach (HexagonTile tile in enemyData.tiles)
        {
            if (tile.CurrentEnergyBuilding != null && !(tile.CurrentEnergyBuilding.buffList.HasBuff(BUFF_TYPES.BUILDING_TEMPORARY_DISABLE)))
                return true;
        }

        return false;
    }

	public override void DoCardEffect ()
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
        building.smog = (GameObject)Instantiate(smogPrefab, building.transform.position + Vector3.up * 2f - Vector3.forward * 15f, Quaternion.identity);
        building.smog.transform.parent = building.transform;

        //building.GetComponent<TemporaryBlink>().Begin(effectDuration);

		Destroy(this.gameObject);
	}

}

