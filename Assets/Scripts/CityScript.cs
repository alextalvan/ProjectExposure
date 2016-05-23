using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityScript : MonoBehaviour {
	
	[SerializeField]
	float buildingSpawnCoolDown = 1f;
	[SerializeField]
	float distBetweenBuldings = 1f;
	[SerializeField]
	float minRndOffset = -1.0f; //min rnd offset
	[SerializeField]
	float maxRndOffset = 1.0f; //max rnd offset
    [SerializeField]
    float minRndLineOffset = -0.5f; //min rnd line offset
    [SerializeField]
    float maxRndLineOffset = 0.5f; //max rnd line offset
    [SerializeField]
	int rndUpgradeSkipRate = 2; //rnd chanse to skip upgrade of building
	[SerializeField]
	float upgradeRange = 1.5f; //modifier of range for building upgrades
    [SerializeField]
    int upgradeRndShuffleRate = 3; //used as divider for list count when swapping items in list (lesser - farer items it might swap)

	[SerializeField]
	List<GameObject> buildingPrefabs = new List<GameObject>(); //storage for prefabs

	[SerializeField]
	Transform topDistrict;
	[SerializeField]
	Transform bottomDistrict;
	[SerializeField]
	Transform buildings;

	private List<Vector3> grid = new List<Vector3>();

	private SphereCollider cityBound; //city size
	private float spawnTimer;
	private int maxBuildingType;
	private float lastBuildingDist;

	// Use this for initialization
	void Start () {
		cityBound = GetComponent<SphereCollider> ();
		//max building type (int)
		maxBuildingType = buildingPrefabs [buildingPrefabs.Count - 1].transform.GetComponent<CityBuildingScript> ().Type;
		InitializeGrid ();
		//RandomizeGrid ();
		//sort list of points so it goes from closest points to farest
		grid.Sort((x, y) => Vector3.Distance(x, transform.position).CompareTo(Vector3.Distance(y, transform.position)));
	}

	/// <summary>
	/// Creates points for buildings and stores them into list. 
	/// Adds random offsets.
	/// </summary>
	void InitializeGrid() {
		//Get bounds of top district
		Bounds bounds = topDistrict.GetComponent<Collider> ().bounds;
		//Calculate number of columns
		int numx = (int)(bounds.size.x / distBetweenBuldings);
		//Calculate number of rows
		int numz = (int)(bounds.size.z / distBetweenBuldings);
		//Calculate starting point (1st column / 1st row cell)
		Vector3 startPnt = new Vector3 (topDistrict.position.x - bounds.extents.x + ((bounds.size.x - numx * distBetweenBuldings) * 0.5f) + distBetweenBuldings * 0.5f, topDistrict.position.y, topDistrict.position.z + - bounds.extents.z + ((bounds.size.z - numz * distBetweenBuldings) * 0.5f) + distBetweenBuldings * 0.5f);
		for (int x = 0; x < numx; ++x) {
            float lineOffset = Random.Range(minRndLineOffset, maxRndLineOffset);
            for (int z = 0; z < numz; ++z) {
				//Calculate new point and add random offset to it
				Vector3 newPnt = new Vector3 (distBetweenBuldings * x + Random.Range(minRndOffset, maxRndOffset) + lineOffset, 0,  distBetweenBuldings * z + Random.Range(minRndOffset, maxRndOffset)) + startPnt;
				//If is in city radius
				if (Vector3.Distance (newPnt, transform.position) < cityBound.radius * transform.lossyScale.x)
					grid.Add (newPnt); //Add to points list
			}
		}
		//same for bottom district
		bounds = bottomDistrict.GetComponent<Collider> ().bounds;
		numx = (int)(bounds.size.x / distBetweenBuldings);
		numz = (int)(bounds.size.z / distBetweenBuldings);
		startPnt = new Vector3 (bottomDistrict.position.x - bounds.extents.x + ((bounds.size.x - numx * distBetweenBuldings) * 0.5f) + distBetweenBuldings * 0.5f, bottomDistrict.position.y, bottomDistrict.position.z + - bounds.extents.z + ((bounds.size.z - numz * distBetweenBuldings) * 0.5f) + distBetweenBuldings * 0.5f);
		for (int x = 0; x < numx; ++x)
        {
            float lineOffset = Random.Range(minRndLineOffset, maxRndLineOffset);
            for (int z = 0; z < numz; ++z) {
				Vector3 newPnt = new Vector3 (distBetweenBuldings * x + Random.Range(minRndOffset, maxRndOffset) + lineOffset, 0,  distBetweenBuldings * z + Random.Range(minRndOffset, maxRndOffset)) + startPnt;
				if (Vector3.Distance (newPnt, transform.position) < cityBound.radius * transform.lossyScale.x)
					grid.Add (newPnt);
			}
		}
	}

	/// <summary>
	/// Randomizes the grid.
	/// </summary>
	void RandomizeGrid() {
		for (int i = 0; i < grid.Count; i++) {
			Vector3 temp = grid[i];
			int randomIndex = Random.Range(i, grid.Count);
			grid[i] = grid[randomIndex];
			grid[randomIndex] = temp;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnTimer > 0)
			spawnTimer -= Time.deltaTime;
		SpawnNewBuilding ();
		UpgradeBuildings ();
	}

	/// <summary>
	/// Spawns the new building.
	/// </summary>
	void SpawnNewBuilding() {
		if (grid.Count > 0 && spawnTimer <= 0) { //If there are free spots for buildings to spawn and no cooldown
			Vector3 pnt = grid[0]; //Get first point from the list
			float dist = Vector3.Distance (pnt, transform.position); //Calculate distance from that point to center of city
			float rnd = Random.Range(0, cityBound.radius * transform.lossyScale.x); //Randomize value in range from 0 to city bound (radius)
			if (rnd > dist) { //If random is in range of distance between center and point
				GameObject newBuilding = Instantiate (buildingPrefabs [0], pnt, Quaternion.identity) as GameObject; //Instantiate new building
				newBuilding.transform.parent = buildings; //Insert as a child into buildings
				newBuilding.transform.rotation = buildings.rotation;
				lastBuildingDist = Vector3.Distance (newBuilding.transform.position, transform.position); //Store distance from that building to city center
				grid.RemoveAt (0); //Remove used point from list
			} else {
				if (grid.Count > 1) {
					int rndId = Random.Range (1, grid.Count / upgradeRndShuffleRate); //Randomly pick point from list in range from 1 to count / upgradeRndShuffleRate
                    grid [0] = grid [rndId]; //Swap those points
					grid [rndId] = pnt;
				}
			}
			spawnTimer = buildingSpawnCoolDown; //Reset spwan timer
		}
	}

	/// <summary>
	/// Upgrades the buildings.
	/// </summary>
	void UpgradeBuildings() {
		if (buildings.childCount > 1) {
			List<GameObject> upgradedBuildings = new List<GameObject> (); //Create tmp list
			foreach (Transform building in buildings) {
				int buildingType = building.GetComponent<CityBuildingScript> ().Type; //Get current building type
				if (buildingType != maxBuildingType) { //If can be upgraded (not max type (level))
					int rnd = Random.Range (0, rndUpgradeSkipRate); //Randomize if will be upgraded now or not
					if (rnd != 0)
						return;
					if (Vector3.Distance (building.position, transform.position) < lastBuildingDist / ((buildingType + 2)) * upgradeRange) //If meets the condition (weird formula out of ass :))
						upgradedBuildings.Add (ReplaceBuilding (building)); //Upgrade
				}
			}
		}
	}

	/// <summary>
	/// Replaces the building.
	/// </summary>
	/// <returns>The building.</returns>
	/// <param name="building">Building.</param>
	GameObject ReplaceBuilding(Transform building) {
		Vector3 position = building.position; //Store current building position
        int prefabIndex = ++building.transform.GetComponent<CityBuildingScript> ().Type; //Increment current building type
        Destroy (building.gameObject); //Remove current building
		GameObject upgradedBuilding = Instantiate (buildingPrefabs [prefabIndex], position, Quaternion.identity) as GameObject; //Instantiate new building
		upgradedBuilding.transform.parent = buildings; //Set parent to buildings
		upgradedBuilding.transform.rotation = buildings.rotation;
		return upgradedBuilding; //Return it back
	}
}
