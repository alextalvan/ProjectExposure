using UnityEngine;
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
	public Card currentSelectedCard = null;
	public INPUT_STATES currentInputState = INPUT_STATES.FREE;
	public List<HexagonTile> tiles = new List<HexagonTile>();
	public List<Transform> unitGroups = new List<Transform>();
    public List<EnergyBuilding> buildings = new List<EnergyBuilding>();
	public List<SwampSpot> swampSpots = new List<SwampSpot>();
    public GameObject pickUp = null;
    public bool AI = false;

	public int buildingCount = 0;

    public void RefreshAllTilesHighlight()
	{
		foreach(HexagonTile t in tiles)
			t.CalculateBaseOrNextOutline();
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
