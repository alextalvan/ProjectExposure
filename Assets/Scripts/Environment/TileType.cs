using UnityEngine;
using System.Collections;

public enum ENVIRONMENT_TYPES
{
	DESERT,
	FLATLAND,
	FOREST,
	RIVER,
	MOUNTAIN
}

[System.Serializable]
public class TileType 
{
	public ENVIRONMENT_TYPES environmentType;
	public GameObject visualPrefab;
}
