using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZapCard : ActionCard 
{

	protected override bool CalculatePlayCondition ()
	{
		if(!CheckMoneyCost())
			return false;

		return EnemyHasUnits();
	}

	protected override void DoCardEffect ()
	{
		base.DoCardEffect();

		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];
		List<Transform> groupsWithUnits = new List<Transform>(enemyData.unitGroups.Count);

		foreach(Transform tr in enemyData.unitGroups)
		{
			if(tr.childCount > 0)
				groupsWithUnits.Add(tr);
		}

		Transform randomGroup = groupsWithUnits[Random.Range(0,groupsWithUnits.Count)];

		foreach(Transform unit in randomGroup)
		{
			Destroy(unit.gameObject);
		}

		Destroy(this.gameObject);
	}
}
