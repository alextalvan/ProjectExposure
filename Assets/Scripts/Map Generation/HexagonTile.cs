using UnityEngine;
using System.Collections;

public class HexagonTile : MonoBehaviour 
{
	[SerializeField]
	GameObject _topObject = null;//caching visuals in the prefab

	[SerializeField]
	GameObject _platform = null;


	//each tile knows its type
	TileType _tileType;

	//wrapper for accessing the tile type
	public TileType tileType
	{
		get { return _tileType; }
		set 
		{ 
			_tileType = value; 

			if(_topObject!=null)
				GameObject.Destroy(_topObject);

			_topObject = Instantiate(_tileType.topObjectPrefab);
			_topObject.transform.parent = this.transform;
			_topObject.transform.localPosition = new Vector3(0,0,0);

			if(_platform!=null)
				GameObject.Destroy(_platform);

			_platform = Instantiate(_tileType.platformPrefab);
			_platform.transform.parent = this.transform;
			_platform.transform.localPosition = new Vector3(0,0,0);
		}
	}

	public void Interact()
	{
		//to be filled

		if(_topObject!=null)
			_topObject.GetComponent<Renderer>().material.color = Color.magenta;
	}
}
