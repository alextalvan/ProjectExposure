﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitSpawner : MonoBehaviour {
	
	private Transform pathGroup;
	private Transform spawnPoint;
	private Transform unitGroupParent;
	[SerializeField]
	GameObject unit;
    [SerializeField]
	int unitsPerSpawn = 1;
	[SerializeField]
	float spawnCoolDown = 1f;
	private float spawnTimer;
	Transform activeUnit;

	PLAYERS owner;
    private List<Vector3> unitPath = new List<Vector3>();


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
	void Update () 
	{
		if (spawnTimer > 0f)
			spawnTimer -= Time.deltaTime;
        SpawnUnits();
    }

	/// <summary>
	/// Spawns the units.
	/// </summary>
	void SpawnUnits() 
	{
		if (spawnTimer <= 0f && !activeUnit)
        {
            for (int i = 0; i < unitsPerSpawn; ++i)
            {
                GameObject newUnit = Instantiate(unit, spawnPoint.position, Quaternion.identity) as GameObject;
				newUnit.GetComponent<UnitAI>().SetData(unitPath, owner, this);
				newUnit.gameObject.layer = owner == PLAYERS.PLAYER1 ? 10 : 11;
				newUnit.transform.parent = unitGroupParent;
				newUnit.transform.rotation = transform.rotation;
				activeUnit = newUnit.transform;
            }
        }
	}

	public void ResetTimer() {
		spawnTimer = spawnCoolDown;
	}


	/// <summary>
	/// Sets the spawn information depending on the hexagon tile this building was put on.
	/// Will be called by the tile on instantiation.
	/// </summary>
	/// <param name="pathRoot">Path root.</param>
	/// <param name="spawnPoint">Spawn point.</param>
	/// <param name="owner">Player owner.</param>
	public void SetSpawnInformation(Transform pathRoot, Transform spawnPt, Transform unitGroupParent, PLAYERS powner)
	{
		pathGroup = pathRoot;
		spawnPoint = spawnPt;
		owner = powner;
		this.unitGroupParent = unitGroupParent;
		CreateUnitPath ();
	}
}
