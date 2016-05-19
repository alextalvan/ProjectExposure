using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class HexagonTile : GameManagerSearcher 
{
	[SerializeField]
	PLAYERS owner;

	[SerializeField]
	List<TileType> tileTypes = new List<TileType>();

	[SerializeField]
	ENVIRONMENT_TYPES _environmentType;

	//the root containing all the waypoints for the ai, in order
	[SerializeField]
	Transform aiPathRoot;

	//the waypoint (in the path) which this tile spawns its units at
	[SerializeField]
	Transform spawnPoint;

	[SerializeField]
	GameObject outline;

	[SerializeField]
	private bool _allowBuild = true;

	public bool AllowBuild { get { return _allowBuild; } }

	public PLAYERS Owner { get { return owner; } }

	//GameObject currentEnergyBuilding = null;
	GameObject visualObject = null;

	//each hexagon tile knows the unit group its spawned units are parented to
	[SerializeField]
	Transform spawnedUnitsParent;

	void Start () 
	{
		int randomType = Random.Range(0,tileTypes.Count);

		_environmentType = tileTypes[randomType].environmentType;

		GameObject visualModel = (GameObject)Instantiate(tileTypes[randomType].visualPrefab);
		visualModel.transform.SetParent(this.transform,false);
		visualObject = visualModel;


		outline.SetActive(false);
	}


	public void SetOutline(bool active)
	{
		outline.SetActive(active);
	}
	

	void OnMouseUp()
	{
		//mosue fix for 2d object raycasts to supress 3d object raycasts
		if(gameManager.raycastedOn2DObject)
			return;

		
		PlayerGameData pdata = gameManager.playerData[this.Owner];

		//Debug.Log(pdata.currentInputState);
		if(pdata.currentInputState == INPUT_STATES.PICKING_BUILDING_CARD_TARGET)
		{
			if(_allowBuild)
			{
				BuildingCard bc = pdata.currentSelectedCard as BuildingCard;
				if(bc!=null)
				{
					GameObject energyBuilding = (GameObject)Instantiate(bc.BuildingType.prefab);
					energyBuilding.transform.SetParent(this.transform,false);
					_allowBuild = false;
					//currentEnergyBuilding = energyBuilding;

					energyBuilding.GetComponent<UnitSpawner>().SetSpawnInformation(aiPathRoot,spawnPoint,spawnedUnitsParent,owner);

					EnergyBuilding enComp = energyBuilding.GetComponent<EnergyBuilding>();
					enComp.OnDestruction += () => {this._allowBuild = true;};
					enComp.Owner = this.Owner;

					if(this.Owner == PLAYERS.PLAYER1)
						gameManager.Player1Money -= pdata.currentSelectedCard.MoneyCost;
					else
						gameManager.Player2Money -= pdata.currentSelectedCard.MoneyCost;

					visualObject.GetComponent<TileVisual>().DestroyTopVisual();
					Destroy(bc.gameObject);
				}
			}

			pdata.currentInputState = INPUT_STATES.FREE;
			pdata.SetAllTilesHighlight(false);

		}
	}
}
