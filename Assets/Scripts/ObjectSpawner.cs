using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(BoxCollider))]
public class ObjectSpawner : MonoBehaviour {

	[SerializeField]
	protected List<GameObject> prefabs = new List<GameObject>();

	protected List<GameObject> eligibleObjects;

	[SerializeField]
	float spawnInterval = 0.1f;

	[SerializeField]
	bool inheritRotation = true;

	float timeAccumulator = 0.0f;

	BoxCollider _box;

	// Use this for initialization
	void Start () 
	{
		_box = GetComponent<BoxCollider>();
		eligibleObjects = new List<GameObject>(prefabs);
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeAccumulator+= Time.deltaTime;

		if(timeAccumulator >= spawnInterval)
		{
			timeAccumulator-= spawnInterval;
			Spawn();
		}
	}

	public void Spawn()
	{
		CalculateEligibleObjects();

		Vector3 ext = _box.size * 0.5f;//local extends of the box collider
		Matrix4x4 model = this.transform.localToWorldMatrix;
		Vector3 spawnPoint = new Vector3(Random.Range(-ext.x,ext.x),Random.Range(-ext.y,ext.y),Random.Range(-ext.z,ext.z)) + _box.center;
		spawnPoint = model * new Vector4(spawnPoint.x,spawnPoint.y,spawnPoint.z,1.0f);
		Quaternion spawnRotation = (inheritRotation) ? this.transform.rotation : Quaternion.identity;

		GameObject randomPickup = (GameObject)Instantiate(eligibleObjects[Random.Range(0,eligibleObjects.Count)],spawnPoint,spawnRotation);
		OnSpawn(randomPickup);
	}

	protected virtual void CalculateEligibleObjects()
	{
		
	}

	protected virtual void OnSpawn(GameObject newObject)
	{
		
	}
}
