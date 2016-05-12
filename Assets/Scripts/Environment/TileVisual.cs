using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//this component will wrap all the functionality for modifying the tile's appearance
public class TileVisual : MonoBehaviour 
{
	[SerializeField]
	List<GameObject> topPrefabs = new List<GameObject>();

	[SerializeField]
	List<GameObject> bottomPrefabs = new List<GameObject>();

	GameObject _bottomVisual;

	GameObject _topVisual;
	
	void Start()
	{
		_bottomVisual = (GameObject)Instantiate(bottomPrefabs[Random.Range(0,topPrefabs.Count)]);
		_bottomVisual.transform.SetParent(this.transform,false);

		_topVisual = (GameObject)Instantiate(topPrefabs[Random.Range(0,topPrefabs.Count)]);
		_topVisual.transform.SetParent(this.transform,false);
	}
}
