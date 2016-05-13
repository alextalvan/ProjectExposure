using UnityEngine;
using System.Collections;

public class BuildingSpawner : MonoBehaviour {

	[SerializeField]
	GameObject unit;
	[SerializeField]
	int unitsPerSpawn = 1;
	[SerializeField]
	float spawnCoolDown = 1f;
	private float spawnTimer;

	// Use this for initialization
	void Start () {
		spawnTimer = spawnCoolDown;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnTimer > 0f)
			spawnTimer -= spawnTimer * Time.deltaTime;
	}

	/// <summary>
	/// Spawns the units.
	/// </summary>
	void SpawnUnits() {
		for (int i = 0; i < unitsPerSpawn; ++i) {
			GameObject newUnit = Instantiate (unit, transform.position, Quaternion.identity) as GameObject;
		}
		spawnTimer += spawnCoolDown;
	}
}
