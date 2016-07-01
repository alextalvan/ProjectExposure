using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpeedModCard : ActionCard 
{
	[SerializeField]
	float duration = 5.0f;

	[SerializeField]
	float speedModifier = 0.5f;

	public override bool CalculatePlayCondition ()
	{
		if(!enabled)
			return false;

//		if(!CheckMoneyCost())
//			return false;

		return EnemyHasUnits();
	}

	public override void DoCardEffect ()
	{
        /*
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
			UnitAI aiComp = unit.GetComponent<UnitAI>();

			if(aiComp)
			{
				SpeedBuff buff = new SpeedBuff(speedModifier, duration);
				aiComp.buffList.AddBuff(buff);
			}
		}
        */
		Destroy(this.gameObject);
	}

}
