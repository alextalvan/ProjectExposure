using UnityEngine;
using System.Collections;


public class BuildingCard : Card 
{
	//for now use mouse input for testing

	[SerializeField]
	EnergyBuildingType _buildingType;

	public EnergyBuildingType BuildingType { get { return _buildingType; } }




	void OnMouseUp()
	{

		//Debug.Log("card");
		PlayerGameData pdata = gameManager.playerData[this.Owner];

		if(pdata.currentInputState != INPUT_STATES.FREE)
			return;

		bool oneFreeTile = false;

		foreach(HexagonTile t in pdata.tiles)
		if(t.AllowBuild)
		{
			oneFreeTile = true;
			break;
		}

		if(oneFreeTile)
		{
			pdata.currentSelectedCard = this;
			gameManager.StartEnergyBuildingTileSelection(this);
		}


		gameManager.raycastedOn2DObject = true;
	}
}
