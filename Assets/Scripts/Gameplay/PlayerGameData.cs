﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PLAYERS
{
	PLAYER1,
	PLAYER2
}

[System.Serializable]
public class PlayerGameData 
{
	public PLAYERS player;
	public ActionCard currentSelectedCard = null;
	public INPUT_STATES currentInputState = INPUT_STATES.FREE;
	public List<HexagonTile> tiles = new List<HexagonTile>();


	public void SetAllTilesHighlight(bool show)
	{
		foreach(HexagonTile t in tiles)
			t.SetOutline(show);
	}
}


[System.Serializable]
public class PlayerGameDataList
{
	public List<PlayerGameData> data = new List<PlayerGameData>();

	public PlayerGameData this[PLAYERS pl]
	{
		get 
		{
			foreach(PlayerGameData pdata in data)
				if(pdata.player == pl)
					return pdata;

			return null;
		}
	}
}