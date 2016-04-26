using UnityEngine;
using System.Collections;

public class HexagonTile : MonoBehaviour 
{
	[SerializeField]
	Renderer _renderer;//caching renderer in the prefab


	//each tile knows its type
	TileType _tileType;

	//wrapper for accessing the tile type
	public TileType tileType
	{
		get { return _tileType; }
		set 
		{ 
			_tileType = value; 
			_renderer.sharedMaterial = _tileType.material;
		}
	}
}
