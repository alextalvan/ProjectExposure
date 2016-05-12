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

		//visualModel.transform.localScale = this.transform.lossyScale;
		visualModel.transform.SetParent(this.transform,false);
		//visualModel.transform.localRotation = Quaternion.identity;
		//visualModel.transform.localScale = new Vector3(1,1,1);
		//visualModel.transform.localPosition = new Vector3(0,0,0);
	}
	

}
