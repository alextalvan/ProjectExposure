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

	[SerializeField]
	List<TileType> cityTiles = new List<TileType>();

	[SerializeField]
	int cityRadius = 1;

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

		//storedTiles = new HexagonTile[rows + 4,cols + 4];

		float xAxisOffset = tileModelSizeX * 1.5f;
		float halfXSize = xAxisOffset * 0.5f;
		float zAxisOffset = tileModelSizeZ * 0.5f;

		for (int i = 1; i < rows + 2; ++i)
		{
			float hexagonOffset = (i % 2 == 0) ? halfXSize : 0.0f;

			for(int j = 0; j < cols ; ++j)
			{

				//instantiation and positioning
				GameObject newTile = Instantiate(tilePrefab);
				newTile.name = i.ToString() + "," + j.ToString();
				newTile.transform.SetParent(mapRoot.transform);

				Vector3 pos = new Vector3(j * xAxisOffset + hexagonOffset, 0 , i * zAxisOffset);
				newTile.transform.localPosition = pos;



				HexagonTile tileComp = newTile.GetComponent<HexagonTile>();
				//storedTiles[i+1,j] = tileComp;

				TileType randomType;

				if(CheckIfCityTile(i,j))
					randomType = cityTiles[Random.Range(0,cityTiles.Count)];
				else
					randomType = tileTypes[Random.Range(0,tileTypes.Count)];


				tileComp.tileType = randomType;


			}

		}


		//RecalculateTiles();
	}

	bool CheckIfCityTile(int i, int j)
	{
		if(cityRadius <= 0)//no city
			return false;

		//map central tile is always city
		int ci = mapRows/ 2 + 1;
		int cj = mapColumns/2;

		if(i == ci  && j == cj)
			return true;

		if(cityRadius >= 2)
		{
			if(i == ci + 1 && j == cj)
				return true;

			if(i == ci - 1 && j == cj)
				return true;

			if(i == ci + 2 && j == cj)
				return true;

			if(i == ci - 2 && j == cj)
				return true;

			if(i == ci + 1 && j == cj - 1)
				return true;

			if(i == ci - 1 && j == cj - 1)
				return true;
		}

		return false;
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
