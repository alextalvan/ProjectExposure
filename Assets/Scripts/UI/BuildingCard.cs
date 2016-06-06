using UnityEngine;
using System.Collections;


public class BuildingCard : Card 
{
	//for now use mouse input for testing

	[SerializeField]
	EnergyBuildingType _buildingType;

	public EnergyBuildingType BuildingType { get { return _buildingType; } }

    protected override void DoCardEffect ()
	{
		
		PlayerGameData pdata = gameManager.playerData[this.Owner];
		pdata.currentSelectedCard = this;
		gameManager.StartEnergyBuildingTileSelection(this);

		gameManager.raycastedOn2DObject = true;
	}

	protected override bool CalculatePlayCondition ()
	{

		if(!enabled)
			return false;

//		if(!CheckMoneyCost())
//			return false;

		PlayerGameData pdata = gameManager.playerData[this.Owner];

		if(pdata.currentInputState != INPUT_STATES.FREE)
			return false;

		bool oneFreeTile = false;

		foreach(HexagonTile t in pdata.tiles)
		if(t.AllowBuild)
		{
			oneFreeTile = true;
			break;
		}

		if(!oneFreeTile)
			return false;

		return true;
	}
}
