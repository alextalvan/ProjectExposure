using UnityEngine;
using System.Collections;


public class BuildingCard : ActionCard 
{
	//for now use mouse input for testing

	[SerializeField]
	EnergyBuildingType _buildingType;

	public EnergyBuildingType BuildingType { get { return _buildingType; } }


	private GameManager _gameMng;

	void Start()
	{
		_gameMng = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void OnMouseUp()
	{

		//Debug.Log("card");
		PlayerGameData pdata = _gameMng.playerData[this.Owner];

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
			_gameMng.StartEnergyBuildingTileSelection(this);
		}


		_gameMng.raycastedOn2DObject = true;
	}
}
