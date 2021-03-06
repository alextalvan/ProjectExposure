﻿using UnityEngine;
using System.Collections;

public class QuakeCard : ActionCard 
{
	public override bool CalculatePlayCondition ()
	{

		if(!enabled)
			return false;

//		if(!CheckMoneyCost())
//			return false;

		return EnemyHasBuildings();
	}

	public override void DoCardEffect ()
	{
		base.DoCardEffect();

		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];

		for(int i=0; i < enemyData.tiles.Count - 1; ++i)
		{
			enemyData.tiles[i].SwapBuilding(enemyData.tiles[Random.Range(i+1,enemyData.tiles.Count)]);
		}

		Destroy(this.gameObject);
		Camera.main.GetComponent<CameraShake>().Shake();
		enemyData.currentInputState = INPUT_STATES.FREE;
		enemyData.RefreshAllTilesHighlight();
	}
}
