using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ActionCard : Card 
{
	protected PlayerGameData enemyData;

	protected override void Start ()
	{
		base.Start ();

	}
		
	protected bool EnemyHasUnits()
	{
		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];
		foreach(Transform tr in enemyData.unitGroups)
		{
			if(tr.childCount > 0)
				return true;
		}
		return false;
	}

}
