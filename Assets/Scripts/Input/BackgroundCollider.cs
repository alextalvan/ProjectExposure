using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class BackgroundCollider : GameManagerSearcher 
{
	[SerializeField]
	PLAYERS owner;

	void OnMouseUp()
	{
		//UIConsole.LogWithRandomColor("Background.");
		PlayerGameData pdata = gameManager.playerData[owner];

		if(pdata.currentInputState == INPUT_STATES.PICKING_BUILDING_CARD_TARGET)
		{
			pdata.SetAllTilesHighlight(false);
			pdata.currentInputState = INPUT_STATES.FREE;
		}

	}
}
