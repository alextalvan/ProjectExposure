﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[RequireComponent(typeof(Collider))]
public enum LANES
{
    TOP,
    BOT
}

public class HexagonTile : GameManagerSearcher
{
    [SerializeField]
    PLAYERS owner;

    [SerializeField]
    LANES lane;

    [SerializeField]
    List<TileType> tileTypes = new List<TileType>();

    //[SerializeField]
    //ENVIRONMENT_TYPES _environmentType;
    //the waypoint (in the path) which this tile spawns its units at
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    float unitDirX;

    public enum OUTLINE_STATES
    {
        BASE,
        BUILD_NEW,
        BUILD_NEXT
    }

    //outline for when a building card has been selected and this tile is eligible
    [SerializeField]
    GameObject outline_build_new;

    //base outline, nothing special
    [SerializeField]
    GameObject outline_base;


    //outline that is activated when you can build on this building due to space being sufficient
    [SerializeField]
    GameObject outline_build_next;


    //this tile will only allow building if the previous tile already has one (forcing succession)
    //in case of null, it can always be built on
    [SerializeField]
    HexagonTile previousTile = null;

    [SerializeField]
    HexagonTile nextTile = null;

    public bool AllowBuild { get { return (previousTile == null || previousTile.CurrentEnergyBuilding != null) && (CurrentEnergyBuilding == null || CurrentEnergyBuilding.ConstructionTimeLeft <= 0.0f); } }

    public PLAYERS Owner { get { return owner; } }

    //GameObject currentEnergyBuilding = null;
    GameObject visualObject = null;

    //each hexagon tile knows the unit group its spawned units are parented to
    [SerializeField]
    Transform spawnedUnitsParent;

    //each hexagon knows its energy building
	[SerializeField]
    private EnergyBuilding _energyBuilding = null;
    public EnergyBuilding CurrentEnergyBuilding { get { return _energyBuilding; } private set { _energyBuilding = value; } }

    //swap
    private bool swap = false;
    private Vector3 swapCenterPos;
    private Vector3 centerToThisVec;
    private Vector3 centerToSwapVec;

    //hexagon tiles can be temporarily blocked
    //float blockTime = -1.0f;

    //[SerializeField]
    //GameObject buildingBlockedObject;
    float startTime;

    [SerializeField]
    PollutionZone pollutionZone;

    void Start()
    {
        int randomType = Random.Range(0, tileTypes.Count);
        //_environmentType = tileTypes[randomType].environmentType;

        //		GameObject visualModel = (GameObject)Instantiate(tileTypes[randomType].visualPrefab);
        //		visualModel.transform.SetParent(this.transform,false);
        //		visualObject = visualModel;


        if (previousTile == null)
            SetOutlineState(OUTLINE_STATES.BUILD_NEXT);
        else
            SetOutlineState(OUTLINE_STATES.BASE);
    }

    public void SetOutline(bool active)
    {
        //outline_build_new.SetActive(active);
    }

    void Update()
    {
        //		blockTime -= Time.deltaTime;
        //		if(blockTime <= 0.0f && buildingBlockedObject !=null)
        //		{
        //			Destroy(buildingBlockedObject.gameObject);
        //			buildingBlockedObject = null;
        //			//this.visualObject.GetComponent<TileVisual>().ToggleTopVisual(true);
        //			CalculateBaseOrNextOutline();
        //		}
        if (swap)
        {
            DoSwap();
        }
    }

    public void StartSwap()
    {
		if (!_energyBuilding || swap) return;
        startTime = Time.time;
        swapCenterPos = (_energyBuilding.transform.position + transform.position) * 0.5f;
        centerToThisVec = transform.position - swapCenterPos;
        centerToSwapVec = _energyBuilding.transform.position - swapCenterPos;
        swap = true;
    }

    private void DoSwap()
    {
        if (Vector3.Distance(_energyBuilding.transform.position, transform.position) < 0.001f)
        {
            _energyBuilding.transform.position = transform.position;
            swap = false;
        }
        else
        {
            float fracComplete = (Time.time - startTime);
            _energyBuilding.transform.position = swapCenterPos + Vector3.Slerp(centerToSwapVec, centerToThisVec, fracComplete);
        }
    }

    /// <summary>
    /// Swaps the building (if any) with the target hexagon tile
    /// </summary>
    /// <param name="other">Other.</param>
    public void SwapBuilding(HexagonTile other)
    {
        if (swap || other.swap)
            return;

        if (this == other)
            return;

		if (!this.CurrentEnergyBuilding && !other.CurrentEnergyBuilding)
            return;

        EnergyBuilding myB = _energyBuilding;
        EnergyBuilding otherB = other._energyBuilding;

        if (myB != null)
        {

            myB.transform.SetParent(other.transform);
            //myB.transform.localPosition = Vector3.zero;
            myB.transform.localRotation = Quaternion.identity;
            //myB.transform.localScale = Vector3.one;

            myB.OnDestruction -= this.CleanupAfterBuildingIsDestroyed;
            myB.OnDestruction += other.CleanupAfterBuildingIsDestroyed;

            myB.GetComponent<UnitSpawner>().SetSpawnInformation(unitDirX, other.spawnPoint, other.spawnedUnitsParent, other.owner, other.lane);

            //other.visualObject.GetComponent<TileVisual>().ToggleTopVisual(false);

            other.pollutionZone.SetGrowState(myB.IsPolluting);


        }
        else
            other.pollutionZone.SetGrowState(false);

        other.CurrentEnergyBuilding = myB;
        //other.visualObject.GetComponent<TileVisual>().ToggleTopVisual(myB == null);

		if(otherB!=null)
		{
			
			otherB.transform.SetParent(this.transform);
			//otherB.transform.localPosition = Vector3.zero;
			otherB.transform.localRotation = Quaternion.identity;
			//otherB.transform.localScale = Vector3.one;

			otherB.OnDestruction -= other.CleanupAfterBuildingIsDestroyed;
			otherB.OnDestruction += this.CleanupAfterBuildingIsDestroyed;

			otherB.GetComponent<UnitSpawner>().SetSpawnInformation(this.unitDirX, this.spawnPoint,this.spawnedUnitsParent,this.owner, this.lane);

			//this.visualObject.GetComponent<TileVisual>().ToggleTopVisual(false);
			this.pollutionZone.SetGrowState(otherB.IsPolluting);
		}
		else
			this.pollutionZone.SetGrowState(false);

		this.CurrentEnergyBuilding = otherB;
		//this.visualObject.GetComponent<TileVisual>().ToggleTopVisual(otherB == null);
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
        if (pdata.currentInputState == INPUT_STATES.PICKING_BUILDING_CARD_TARGET)
        {
            if (AllowBuild)
            {
                BuildingCard bc = pdata.currentSelectedCard as BuildingCard;
                if (bc != null)
                {
                    if (_energyBuilding != null)
                    {
						//_energyBuilding.OnDestruction -= this.CleanupAfterBuildingIsDestroyed;
                        //Destroy(_energyBuilding.gameObject);
                        DestroyBuilding();
						//CleanupAfterBuildingIsDestroyed();
                        //gameManager.playerData[this.owner].buildingCount--;
                    }


                    GameObject energyBuilding = (GameObject)Instantiate(bc.BuildingType.prefab);
                    energyBuilding.transform.SetParent(this.transform, false);
                 

                    energyBuilding.GetComponent<UnitSpawner>().SetSpawnInformation(unitDirX, spawnPoint, spawnedUnitsParent, owner, lane);

                    _energyBuilding = energyBuilding.GetComponent<EnergyBuilding>();

                    pdata.buildings.Add(_energyBuilding);

                    _energyBuilding.OnDestruction += ()=> { pdata.buildings.Remove(_energyBuilding); };
                    _energyBuilding.OnDestruction += this.CleanupAfterBuildingIsDestroyed;
                    _energyBuilding.Owner = this.Owner;

                    if (this.Owner == PLAYERS.PLAYER1)
                        gameManager.Player1Money -= pdata.currentSelectedCard.MoneyCost;
                    else
                        gameManager.Player2Money -= pdata.currentSelectedCard.MoneyCost;

                    bc.StartCooldown();

                    //gameManager.playerData[this.owner].buildingCount++;

                    //visualObject.GetComponent<TileVisual>().ToggleTopVisual(false);
                    //Destroy(bc.gameObject);

                    if (_energyBuilding.IsPolluting)
                    {
                        pollutionZone.SetGrowState(true);
                    }
                    else
                    {
                        pollutionZone.SetGrowState(false);
                    }


                    SetOutlineState(OUTLINE_STATES.BASE);
                    if (nextTile != null)
                        nextTile.SetOutlineState(OUTLINE_STATES.BUILD_NEXT);
                }
            }

            pdata.currentInputState = INPUT_STATES.FREE;
            pdata.RefreshAllTilesHighlight();

        }
    }

	/// <summary>
	/// Cleanup the after building is destroyed. Used for event callbacks on the building destruction
	/// </summary>
	void CleanupAfterBuildingIsDestroyed()
	{
		//this.visualObject.GetComponent<TileVisual>().ToggleTopVisual(this._energyBuilding.PollutionPrefab == null);
		//StartBuildBlock(this._energyBuilding);
		this._energyBuilding = null;
		CalculateBaseOrNextOutline();
		gameManager.playerData[this.Owner].RefreshAllTilesHighlight();
		this.pollutionZone.SetGrowState(false);

		//Debug.Log("cleanup");
    }


    void StartBuildBlock(EnergyBuilding building)
    {
        //if(building.PollutionPrefab==null || building.BlockTime < blockTime)
        //	return;

        //blockTime = building.BlockTime;

        //buildingBlockedObject = (GameObject)Instantiate(building.PollutionPrefab);
        //buildingBlockedObject.transform.SetParent(this.transform,false);
    }



    public void SetOutlineState(OUTLINE_STATES s)
    {
        outline_base.SetActive(s == OUTLINE_STATES.BASE);
        outline_build_new.SetActive(s == OUTLINE_STATES.BUILD_NEW);
        outline_build_next.SetActive(s == OUTLINE_STATES.BUILD_NEXT);
    }

    public void CalculateBaseOrNextOutline()
    {
        if (previousTile == null && CurrentEnergyBuilding == null)
        {
            SetOutlineState(OUTLINE_STATES.BUILD_NEXT);
            return;
        }

        if (previousTile != null && previousTile.CurrentEnergyBuilding != null && CurrentEnergyBuilding == null)
        {
            SetOutlineState(OUTLINE_STATES.BUILD_NEXT);
            return;
        }

        SetOutlineState(OUTLINE_STATES.BASE);
    }


	public void DestroyBuilding()
	{
		if (_energyBuilding != null)
		{
			//_energyBuilding.OnDestruction -= this.CleanupAfterBuildingIsDestroyed;
			Destroy(_energyBuilding.gameObject);
            _energyBuilding.OnDestruction();
			//CleanupAfterBuildingIsDestroyed();
			//gameManager.playerData[this.owner].buildingCount--;
		}
	}

}
