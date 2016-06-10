using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[RequireComponent(typeof(Collider))]
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
	private bool _hasBuildingOnTop = false;

	public bool AllowBuild { get { return !_hasBuildingOnTop && blockTime <= 0.0f; } }

	public PLAYERS Owner { get { return owner; } }

	//GameObject currentEnergyBuilding = null;
	GameObject visualObject = null;

	//each hexagon tile knows the unit group its spawned units are parented to
	[SerializeField]
	Transform spawnedUnitsParent;

	//each hexagon knows its energy building
	private EnergyBuilding _energyBuilding = null;
	public EnergyBuilding CurrentEnergyBuilding { get { return _energyBuilding; } private set { _energyBuilding = value; } }

	//hexagon tiles can be temporarily blocked
	float blockTime = -1.0f;

	[SerializeField]
	GameObject buildingBlockedObject;


	void Start () 
	{
		int randomType = Random.Range(0,tileTypes.Count);

		//_environmentType = tileTypes[randomType].environmentType;

		GameObject visualModel = (GameObject)Instantiate(tileTypes[randomType].visualPrefab);
		visualModel.transform.SetParent(this.transform,false);
		visualObject = visualModel;


		outline.SetActive(false);
	}

	/// <summary>
	/// Toggle the outline object.
	/// </summary>
	/// <param name="active">If set to <c>true</c> active.</param>
	public void SetOutline(bool active)
	{
		outline.SetActive(active);
	}

	void Update()
	{
		blockTime -= Time.deltaTime;
		if(blockTime <= 0.0f && buildingBlockedObject !=null)
		{
			Destroy(buildingBlockedObject.gameObject);
			buildingBlockedObject = null;
			this.visualObject.GetComponent<TileVisual>().ToggleTopVisual(true);
		}
			
	}
		


	/// <summary>
	/// Swaps the building (if any) with the target hexagon tile
	/// </summary>
	/// <param name="other">Other.</param>
	public void SwapBuilding(HexagonTile other)
	{
		if(this == other || this.blockTime > 0.0f || other.blockTime > 0.0f)
			return;

		if(!this._hasBuildingOnTop && !other._hasBuildingOnTop)
			return;

		EnergyBuilding myB = _energyBuilding;
		EnergyBuilding otherB = other._energyBuilding;

		if(myB!=null)
		{
			
			myB.transform.SetParent(other.transform);
			myB.transform.localPosition = Vector3.zero;
			myB.transform.localRotation = Quaternion.identity;
			//myB.transform.localScale = Vector3.one;

			myB.OnDestruction -= this.CleanupAfterBuildingIsDestroyed;
			myB.OnDestruction += other.CleanupAfterBuildingIsDestroyed;

			myB.GetComponent<UnitSpawner>().SetSpawnInformation(other.aiPathRoot,other.spawnPoint,other.spawnedUnitsParent,other.owner);

			//other.visualObject.GetComponent<TileVisual>().ToggleTopVisual(false);


		}

		other.CurrentEnergyBuilding = myB;
		other._hasBuildingOnTop = (myB != null);
		other.visualObject.GetComponent<TileVisual>().ToggleTopVisual(myB == null);

		if(otherB!=null)
		{
			
			otherB.transform.SetParent(this.transform);
			otherB.transform.localPosition = Vector3.zero;
			otherB.transform.localRotation = Quaternion.identity;
			//otherB.transform.localScale = Vector3.one;

			otherB.OnDestruction -= other.CleanupAfterBuildingIsDestroyed;
			otherB.OnDestruction += this.CleanupAfterBuildingIsDestroyed;

			otherB.GetComponent<UnitSpawner>().SetSpawnInformation(this.aiPathRoot,this.spawnPoint,this.spawnedUnitsParent,this.owner);

			//this.visualObject.GetComponent<TileVisual>().ToggleTopVisual(false);
				
		}

		this.CurrentEnergyBuilding = otherB;
		this._hasBuildingOnTop = (otherB != null);
		this.visualObject.GetComponent<TileVisual>().ToggleTopVisual(otherB == null);
	}


    /// <summary>
    /// Callback for the finger being lifted on top of this collider
    /// </summary>
#if TOUCH_INPUT
	public void PenetratingTouchEnd()
#else
    public void OnMouseUp()
	#endif
	{
		
		//mosue fix for 2d object raycasts to supress 3d object raycasts
		//if(gameManager.raycastedOn2DObject)
		//	return;

		
		PlayerGameData pdata = gameManager.playerData[this.Owner];

		//Debug.Log(pdata.currentInputState);
		if(pdata.currentInputState == INPUT_STATES.PICKING_BUILDING_CARD_TARGET)
		{
			if(AllowBuild)
			{
				BuildingCard bc = pdata.currentSelectedCard as BuildingCard;
				if(bc!=null)
				{
					GameObject energyBuilding = (GameObject)Instantiate(bc.BuildingType.prefab);
					energyBuilding.transform.SetParent(this.transform,false);
					this._hasBuildingOnTop = true;
					//currentEnergyBuilding = energyBuilding;

					energyBuilding.GetComponent<UnitSpawner>().SetSpawnInformation(aiPathRoot,spawnPoint,spawnedUnitsParent,owner);

					_energyBuilding = energyBuilding.GetComponent<EnergyBuilding>();
					_energyBuilding.OnDestruction += this.CleanupAfterBuildingIsDestroyed;
					_energyBuilding.Owner = this.Owner;

					if(this.Owner == PLAYERS.PLAYER1)
						gameManager.Player1Money -= pdata.currentSelectedCard.MoneyCost;
					else
						gameManager.Player2Money -= pdata.currentSelectedCard.MoneyCost;

					visualObject.GetComponent<TileVisual>().ToggleTopVisual(false);
					//Destroy(bc.gameObject);
				}
			}

			pdata.currentInputState = INPUT_STATES.FREE;
			pdata.SetAllTilesHighlight(false);

		}
	}


	/// <summary>
	/// Cleanup the after building is destroyed. Used for event callbacks on the building destruction
	/// </summary>
	void CleanupAfterBuildingIsDestroyed()
	{
		this.visualObject.GetComponent<TileVisual>().ToggleTopVisual(this._energyBuilding.PollutionPrefab == null);
		StartBuildBlock(this._energyBuilding);
		this._hasBuildingOnTop = false; 
		this._energyBuilding = null;

		//if(this._energyBuilding.PollutionPrefab

	}


	void StartBuildBlock(EnergyBuilding building)
	{
		if(building.PollutionPrefab==null || building.BlockTime < blockTime)
			return;

		blockTime = building.BlockTime;

		buildingBlockedObject = (GameObject)Instantiate(building.PollutionPrefab);
		buildingBlockedObject.transform.SetParent(this.transform,false);
	}
		
}
