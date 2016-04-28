using UnityEngine;
using System.Collections;

//this class is a helper used to describe all the properties that each tile type can have in game
[System.Serializable]
public class TileType
{
	//public string description = "unknown";
	//public Material material;
	public GameObject topObjectPrefab;
	public GameObject platformPrefab;
	public float coalEfficiency;
	public float windEfficiency;
	public float solarEfficiency;
	public float hydroEfficiency;
	public bool allowBuildOver;
}
