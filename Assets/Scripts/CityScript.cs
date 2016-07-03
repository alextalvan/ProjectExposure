using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityScript : MonoBehaviour
{
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
    Transform bounds;
    [SerializeField]
    Transform buildings;

    private List<Vector3> grid = new List<Vector3>();

    private SphereCollider cityBound; //city size
    private int maxBuildingType;
    private float lastBuildingDist;

    // Use this for initialization
    void Start()
    {
        cityBound = GetComponent<SphereCollider>();
        //max building type (int)
        maxBuildingType = buildingPrefabs[buildingPrefabs.Count - 1].transform.GetComponent<CityBuildingScript>().Type;
        InitializeGrid();
        //RandomizeGrid ();
        //sort list of points so it goes from closest points to farest
        grid.Sort((x, y) => Vector3.Distance(transform.localPosition + x, transform.localPosition).CompareTo(Vector3.Distance(transform.localPosition + y, transform.localPosition)));
    }

    /// <summary>
    /// Creates points for buildings and stores them into list. 
    /// Adds random offsets.
    /// </summary>
    void InitializeGrid()
    {
        //Get size of top city
        Vector2 size = new Vector2(Vector3.Distance(bounds.GetChild(1).localPosition, bounds.GetChild(2).localPosition) * bounds.localScale.x,
            Vector3.Distance(bounds.GetChild(0).localPosition, bounds.GetChild(3).localPosition) * bounds.localScale.z);
        //Calculate number of columns
        int numx = (int)(size.x / distBetweenBuldings);
        //Calculate number of rows
        int numz = (int)(size.y / distBetweenBuldings);
        //Calculate starting point (1st column / 1st row cell)
        Vector3 startPnt = bounds.localPosition + new Vector3(-size.x * 0.5f + distBetweenBuldings * 0.5f, 0, -size.y * 0.5f + distBetweenBuldings * 0.5f);
        for (int x = 0; x < numx; ++x)
        {
            float lineOffset = Random.Range(minRndLineOffset, maxRndLineOffset);
            for (int z = 0; z < numz; ++z)
            {
                //Calculate new point and add random offset to it
                Vector3 newPnt = new Vector3(distBetweenBuldings * x + Random.Range(minRndOffset, maxRndOffset) + lineOffset,
                    0, distBetweenBuldings * z + Random.Range(minRndOffset, maxRndOffset) + lineOffset) + startPnt;
                if (Vector3.Distance(transform.localPosition + newPnt, transform.localPosition) < cityBound.radius)
                    grid.Add(newPnt); //Add to points list
            }
        }
    }

    /// <summary>
    /// Randomizes the grid.
    /// </summary>
    void RandomizeGrid()
    {
        for (int i = 0; i < grid.Count; i++)
        {
            Vector3 temp = grid[i];
            int randomIndex = Random.Range(i, grid.Count);
            grid[i] = grid[randomIndex];
            grid[randomIndex] = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Spawns the new building.
    /// </summary>
    public void SpawnNewBuilding()
    {
        if (grid.Count > 0)
        { //If there are free spots for buildings to spawn and no cooldown
            Vector3 pnt = grid[0]; //Get first point from the list
            float dist = Vector3.Distance(transform.localPosition + pnt, transform.localPosition); //Calculate distance from that point to center of city
            float rnd = Random.Range(0, cityBound.radius); //Randomize value in range from 0 to city bound (radius)
            if (rnd > dist)
            { //If random is in range of distance between center and point
                GameObject newBuilding = Instantiate(buildingPrefabs[0], pnt, Quaternion.identity) as GameObject; //Instantiate new building
                newBuilding.transform.SetParent(buildings, false); //Insert as a child into buildings
                newBuilding.transform.Rotate(Vector3.up, Random.Range(0, 360f));
                lastBuildingDist = Vector3.Distance(transform.localPosition + newBuilding.transform.localPosition, transform.localPosition); //Store distance from that building to city center
                grid.RemoveAt(0); //Remove used point from list
            }
            else
            {
                if (grid.Count > 1)
                {
                    int rndId = Random.Range(1, grid.Count / upgradeRndShuffleRate); //Randomly pick point from list in range from 1 to count / upgradeRndShuffleRate
                    grid[0] = grid[rndId]; //Swap those points
                    grid[rndId] = pnt;
                }
            }
            int rndUpd = Random.Range(0, rndUpgradeSkipRate); //Randomize if will be upgraded now or not
            if (rndUpd == 0)
                UpgradeBuildings();
        }
    }

    /// <summary>
    /// Upgrades the buildings.
    /// </summary>
    void UpgradeBuildings()
    {
        if (buildings.childCount > 1)
        {
            List<GameObject> upgradedBuildings = new List<GameObject>(); //Create tmp list
            foreach (Transform building in buildings)
            {
                int buildingType = building.GetComponent<CityBuildingScript>().Type; //Get current building type
                if (buildingType != maxBuildingType)
                { //If can be upgraded (not max type (level))
                    if (Vector3.Distance(transform.localPosition + building.localPosition, transform.localPosition) < lastBuildingDist / ((buildingType + 2)) * upgradeRange) //If meets the condition (weird formula out of ass :))
                        upgradedBuildings.Add(ReplaceBuilding(building)); //Upgrade
                }
                return;
            }
        }
    }

    /// <summary>
    /// Replaces the building.
    /// </summary>
    /// <returns>The building.</returns>
    /// <param name="building">Building.</param>
    GameObject ReplaceBuilding(Transform building)
    {
        Vector3 position = building.localPosition; //Store current building position
        Quaternion rotation = building.rotation;
        int prefabIndex = ++building.transform.GetComponent<CityBuildingScript>().Type; //Increment current building type
        Destroy(building.gameObject); //Remove current building
        GameObject upgradedBuilding = Instantiate(buildingPrefabs[prefabIndex], position, Quaternion.identity) as GameObject; //Instantiate new building
        upgradedBuilding.transform.SetParent(buildings, false); //Insert as a child into buildings
        upgradedBuilding.transform.rotation = rotation;
        return upgradedBuilding; //Return it back
    }
}
