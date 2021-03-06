﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(EnergyBuilding))]
public class UnitSpawner : GameManagerSearcher
{
    private Transform spawnPoint;
    private Transform unitGroupParent;
    [SerializeField]
    GameObject unit;
    private float dirX;

	PLAYERS owner;
	LANES lane;
    private List<Vector3> unitPath = new List<Vector3>();

	//to check if the energy building is debuffed
	[SerializeField]
	private EnergyBuilding _energyBuilding;

	[SerializeField]
	int initialWaveDelay = 0;

	[SerializeField]
	int waveSpawnRate = 1;
	int currentWaveSpawnCounter = 0;

	//float nextEstimatedSpawnTime;
	//float spawnFeedbackTimer;
	//float spawnFeedbackTotal;

	//[SerializeField]
	//Renderer spawnFeedbackRenderer;

    void Start()
    {
		//spawnFeedbackTimer = 0.0f;
		//nextEstimatedSpawnTime = 
        //gameManager.OnNewWave += this.SpawnUnits;
    }

    void OnDestroy()
    {
        //gameManager.OnNewWave -= this.SpawnUnits;
    }

    // Update is called once per frame
    void Update()
    {
		//spawnFeedbackRenderer.material.SetFloat("_Clip",
    }

    /// <summary>
    /// Spawns the units.
    /// </summary>
    public void SpawnUnits()
    {
		initialWaveDelay--;
		if(initialWaveDelay>-1)
			return;

		currentWaveSpawnCounter++;
		if(currentWaveSpawnCounter>=waveSpawnRate)
		{
			currentWaveSpawnCounter = 0;
	        GameObject newUnit = Instantiate(unit, spawnPoint.position, Quaternion.identity) as GameObject;
	        newUnit.GetComponent<UnitAI>().SetData(dirX, owner, lane);
	        newUnit.gameObject.layer = owner == PLAYERS.PLAYER1 ? 10 : 11;
	        newUnit.transform.parent = unitGroupParent;
	        newUnit.transform.rotation = transform.rotation;

			//spawnFeedbackTimer = gameManager.WaveCooldown * waveSpawnRate;
		}
    }

    /// <summary>
    /// Sets the spawn information depending on the hexagon tile this building was put on.
    /// Will be called by the tile on instantiation.
    /// </summary>
    /// <param name="pathRoot">Path root.</param>
    /// <param name="spawnPoint">Spawn point.</param>
    /// <param name="owner">Player owner.</param>
    public void SetSpawnInformation(float dirX, Transform spawnPt, Transform unitGroupParent, PLAYERS powner, LANES plane)
    {
        this.dirX = dirX;
        spawnPoint = spawnPt;
        owner = powner;
        lane = plane;
        this.unitGroupParent = unitGroupParent;
    }
}
