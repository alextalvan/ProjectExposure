﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class BackgroundCollider : GameManagerSearcher 
{
	[SerializeField]
	PLAYERS owner;

#if TOUCH_INPUT
	public void TouchEnd()
#else
    public void OnMouseUp()
	#endif
	{
		//UIConsole.LogWithRandomColor("Background.");
		PlayerGameData pdata = gameManager.playerData[owner];

		if(pdata.currentInputState == INPUT_STATES.PICKING_BUILDING_CARD_TARGET)
		{
			pdata.RefreshAllTilesHighlight();
			pdata.currentInputState = INPUT_STATES.FREE;
		}

	}
}
