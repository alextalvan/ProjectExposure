using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class HexagonTile : MonoBehaviour 
{

	[SerializeField]
	List<TileType> tileTypes = new List<TileType>();

	[SerializeField]
	ENVIRONMENT_TYPES _environmentType;

	[SerializeField]
	GameObject outline;

	[SerializeField]
	private bool _allowBuild = true;

	public bool AllowBuild { get { return _allowBuild; } }


	void Start () 
	{
		int randomType = Random.Range(0,tileTypes.Count);

		_environmentType = tileTypes[randomType].environmentType;

		GameObject visualModel = (GameObject)Instantiate(tileTypes[randomType].visualPrefab);
		visualModel.transform.SetParent(this.transform,false);


		outline.SetActive(false);
	}


	public void SetOutline(bool active)
	{
		outline.SetActive(active);
	}
	

}
