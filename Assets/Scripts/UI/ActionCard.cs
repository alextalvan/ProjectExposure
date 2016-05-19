using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ActionCard : Card 
{
	PlayerGameData enemyData;


	void OnMouseUp()
	{
		PlayerGameData pdata = gameManager.playerData[this.Owner];

		if(pdata.currentInputState != INPUT_STATES.FREE)
			return;

		if(PlayCondition())
			DoCardEffect();
	}

	protected override void Start ()
	{
		base.Start ();
		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];
	}



	void DoCardEffect()
	{
		switch(this.CardType)
		{
			case CARD_TYPES.ZAP:
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
				break;
		}

	}

	
	//checks if the card is allowed to be played
	bool PlayCondition()
	{
		if(!CheckMoneyCost())
			return false;

		switch(this.CardType)
		{
			case CARD_TYPES.ZAP:
				if(!EnemyHasUnits())
					return false;

				foreach(Transform tr in enemyData.unitGroups)
				{
					if(tr.childCount > 0)
						return true;
				}

				return false;

			case CARD_TYPES.ICE:
				return false;
		}

		return false;
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

	protected override bool HighlightCondition ()
	{
		return PlayCondition();
	}

}
