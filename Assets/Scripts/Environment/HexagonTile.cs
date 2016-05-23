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

	//[SerializeField]
	//ENVIRONMENT_TYPES _environmentType;

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

	//each hexagon knows its energy building
	private EnergyBuilding _energyBuilding = null;
	public EnergyBuilding CurrentEnergyBuilding { get { return _energyBuilding; } private set { _energyBuilding = value; } }

	void Start () 
	{
		int randomType = Random.Range(0,tileTypes.Count);

		//_environmentType = tileTypes[randomType].environmentType;

		GameObject visualModel = (GameObject)Instantiate(tileTypes[randomType].visualPrefab);
		visualModel.transform.SetParent(this.transform,false);
		visualObject = visualModel;


		outline.SetActive(false);
	}


	public void SetOutline(bool active)
	{
		outline.SetActive(active);
	}

	public void SwapBuilding(HexagonTile other)
	{
		EnergyBuilding myB = _energyBuilding;
		EnergyBuilding otherB = other.CurrentEnergyBuilding;

		if(myB!=null)
		{
			other.CurrentEnergyBuilding = myB;
			myB.transform.SetParent(other.transform);
			myB.transform.localPosition = Vector3.zero;
			myB.transform.localRotation = Quaternion.identity;
			myB.transform.localScale = Vector3.one;

			myB.OnDestruction -= this.CleanupAfterBuildingIsDestroyed;
			myB.OnDestruction += other.CleanupAfterBuildingIsDestroyed;

			myB.GetComponent<UnitSpawner>().SetSpawnInformation(other.aiPathRoot,other.spawnPoint,other.spawnedUnitsParent,other.owner);

			other.visualObject.GetComponent<TileVisual>().DestroyTopVisual();

			if(otherB == null)
				_allowBuild = true;
		}

		if(otherB!=null)
		{
			this.CurrentEnergyBuilding = otherB;
			otherB.transform.SetParent(this.transform);
			otherB.transform.localPosition = Vector3.zero;
			otherB.transform.localRotation = Quaternion.identity;
			otherB.transform.localScale = Vector3.one;

			otherB.OnDestruction -= other.CleanupAfterBuildingIsDestroyed;
			otherB.OnDestruction += this.CleanupAfterBuildingIsDestroyed;

			otherB.GetComponent<UnitSpawner>().SetSpawnInformation(this.aiPathRoot,this.spawnPoint,this.spawnedUnitsParent,this.owner);

			this.visualObject.GetComponent<TileVisual>().DestroyTopVisual();

			if(myB == null)
				other._allowBuild = true;
		}
		

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

					_energyBuilding = energyBuilding.GetComponent<EnergyBuilding>();
					_energyBuilding.OnDestruction += this.CleanupAfterBuildingIsDestroyed;
					_energyBuilding.Owner = this.Owner;

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


	void CleanupAfterBuildingIsDestroyed()
	{
		this._allowBuild = true; 
		this._energyBuilding = null;
	}
}
