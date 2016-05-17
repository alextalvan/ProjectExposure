using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitSpawner : MonoBehaviour {

    [SerializeField]
    Transform pathGroup;
    [SerializeField]
    Transform spawnPoint;
	[SerializeField]
	GameObject unit;
    [SerializeField]
    Transform units;
    [SerializeField]
	int unitsPerSpawn = 1;
	[SerializeField]
	float spawnCoolDown = 1f;
	private float spawnTimer;

    private List<Vector3> unitPath = new List<Vector3>();

	// Use this for initialization
	void Start () {
        CreateUnitPath();
    }

    void CreateUnitPath()
    {
        bool start = false;
        foreach(Transform child in pathGroup)
        {
            if (start == true)
                unitPath.Add(child.position);
            else if (child == spawnPoint)
                start = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (spawnTimer > 0f)
			spawnTimer -= Time.deltaTime;
        SpawnUnits();
    }

	/// <summary>
	/// Spawns the units.
	/// </summary>
	void SpawnUnits() {
        if (spawnTimer <= 0f)
        {
            for (int i = 0; i < unitsPerSpawn; ++i)
            {
                GameObject newUnit = Instantiate(unit, spawnPoint.position, Quaternion.identity) as GameObject;
                newUnit.GetComponent<UnitAI>().SetPath(unitPath);
                //newUnit.transform.parent = units;
				newUnit.transform.rotation = transform.rotation;
            }
            spawnTimer = spawnCoolDown;
        }
	}
}
