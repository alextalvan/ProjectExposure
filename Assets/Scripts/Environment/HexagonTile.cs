using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexagonTile : MonoBehaviour {

	[SerializeField]
	List<TileType> tileTypes = new List<TileType>();

	[SerializeField]
	ENVIRONMENT_TYPES _environmentType;


	void Start () 
	{
		int randomType = Random.Range(0,tileTypes.Count);

		_environmentType = tileTypes[randomType].environmentType;

		GameObject visualModel = (GameObject)Instantiate(tileTypes[randomType].visualPrefab);
		visualModel.transform.parent = this.transform;
		visualModel.transform.localPosition = new Vector3(0,0,0);
	}
	

}
