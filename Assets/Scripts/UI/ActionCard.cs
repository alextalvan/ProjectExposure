﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ActionCard : Card
{
    protected PlayerGameData enemyData;

    protected override void Start()
    {
        base.Start();
    }

    protected bool EnemyHasUnits()
    {
        enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];
        if (enemyData.units.Count > 0)
            return true;
        return false;
    }

    protected bool EnemyHasBuildings()
    {
        enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];
        foreach (HexagonTile tile in enemyData.tiles)
        {
            if (tile.CurrentEnergyBuilding != null)
                return true;
        }
        return false;
    }

    public override void DoCardEffect()
    {
        //		if(this.Owner == PLAYERS.PLAYER1)
        //			gameManager.Player1Money -= this.MoneyCost;
        //		else
        //			gameManager.Player2Money -= this.MoneyCost;
    }

}
