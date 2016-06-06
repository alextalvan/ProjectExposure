using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwampCard : ActionCard 
{
    [SerializeField]
    float afterUseDur = 3f;

	protected override bool CalculatePlayCondition ()
	{
		if(!enabled)
			return false;

//		if(!CheckMoneyCost())
//			return false;

		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];

		//int inactiveSwamps = 0;

		foreach(SwampSpot s in enemyData.swampSpots)
			if(!s.IsRunning)
				return true;

		return false;
	}

    protected override void DoCardEffect ()
	{
		base.DoCardEffect();

		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];

		List<SwampSpot> inactiveSpots = new List<SwampSpot>();

		foreach(SwampSpot s in enemyData.swampSpots)
			if(!s.IsRunning)
				inactiveSpots.Add(s);

        foreach(SwampSpot s in inactiveSpots)
            s.ToggleOn(afterUseDur);
		//inactiveSpots[Random.Range(0,inactiveSpots.Count)].ToggleOn();
		Destroy(this.gameObject);

	}
}
