using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapBuilder : MonoBehaviour {

	[SerializeField]
	GameObject tilePrefab;

	[SerializeField]
	float tileModelSizeX;

	[SerializeField]
	float tileModelSizeZ;

	[SerializeField]
	int mapRows;

	[SerializeField]
	int mapColumns;


	//for ease of use, all the tile data should be viewable and editable from the inspector
	[SerializeField]
	List<TileType> tileTypes = new List<TileType>();

	//tile references are cached for editing them in the inspector
	//HexagonTile[,] storedTiles;


	void Start()
	{
		BuildMap(mapRows,mapColumns);
	}



	void BuildMap (int rows, int cols)
	{
		if (rows < 1 && cols < 1)
			Debug.LogError ("Attempt to build level of invalid size");

		GameObject mapRoot = new GameObject ("Hexagon_Map_Root");

		//centering the map, this is optional
		mapRoot.transform.position = new Vector3(tileModelSizeX * rows * -0.5f,0,tileModelSizeZ * cols * -0.5f);

		//storedTiles = new HexagonTile[rows,cols];

		float xAxisOffset = tileModelSizeX * 1.5f;
		float halfXSize = xAxisOffset * 0.5f;
		float zAxisOffset = tileModelSizeZ * 0.5f;

		for (int i = -1; i < rows; ++i)
		{
			float hexagonOffset = (i % 2 == 0) ? halfXSize : 0.0f;

			for(int j = 0; j < cols; ++j)
			{

				//instantiation and positioning
				GameObject newTile = Instantiate(tilePrefab);
				newTile.name = i.ToString() + "," + j.ToString();
				newTile.transform.SetParent(mapRoot.transform);

				Vector3 pos = new Vector3(j * xAxisOffset + hexagonOffset, 0 , i * zAxisOffset);
				newTile.transform.localPosition = pos;



				HexagonTile tileComp = newTile.GetComponent<HexagonTile>();
				//storedTiles[i,j] = tileComp;

				TileType randomType = tileTypes[Random.Range(0,tileTypes.Count)];
				tileComp.tileType = randomType;


				//city tile

			}

		}


		//RecalculateTiles();
	}

//	public void RecalculateTiles()
//	{
//		if(storedTiles == null)
//			return;
//
//		for (int i = 0; i < mapRows; ++i)
//			for(int j = 0; j < mapColumns; ++j)
//			{
//				TileType randomType = tileTypes[Random.Range(0,tileTypes.Count)];
//
//				storedTiles[i,j].tileType = randomType;
//			}
//
//
//	}


}
