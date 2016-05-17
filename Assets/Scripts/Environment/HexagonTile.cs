using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class HexagonTile : MonoBehaviour 
{
	[SerializeField]
	PLAYERS owner;

	[SerializeField]
	List<TileType> tileTypes = new List<TileType>();

	[SerializeField]
	ENVIRONMENT_TYPES _environmentType;

	[SerializeField]
	GameObject outline;

	[SerializeField]
	private bool _allowBuild = true;

	public bool AllowBuild { get { return _allowBuild; } }

	public PLAYERS Owner { get { return owner; } }

	GameManager _gameMng;

	//GameObject currentEnergyBuilding = null;
	GameObject visualObject = null;

	void Start () 
	{
		int randomType = Random.Range(0,tileTypes.Count);

		_environmentType = tileTypes[randomType].environmentType;

		GameObject visualModel = (GameObject)Instantiate(tileTypes[randomType].visualPrefab);
		visualModel.transform.SetParent(this.transform,false);
		visualObject = visualModel;


		outline.SetActive(false);

		_gameMng = GameObject.Find("GameManager").GetComponent<GameManager>();
	}


	public void SetOutline(bool active)
	{
		outline.SetActive(active);
	}
	

	void OnMouseUp()
	{
		//mosue fix for 2d object raycasts to supress 3d object raycasts
		if(_gameMng.raycastedOn2DObject)
			return;

		
		PlayerGameData pdata = _gameMng.playerData[this.Owner];

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

					visualObject.GetComponent<TileVisual>().DestroyTopVisual();
					Destroy(bc.gameObject);
				}
			}

			pdata.currentInputState = INPUT_STATES.FREE;
			pdata.SetAllTilesHighlight(false);

		}
	}
}
