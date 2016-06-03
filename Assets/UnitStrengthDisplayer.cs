using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitStrengthDisplayer : MonoBehaviour {


	[SerializeField]
	GameObject hitpointPrefab;

	[SerializeField]
	float distance = 0.25f;

	[SerializeField]
	int health = 0;

	[SerializeField]
	List<GameObject> currentHitpointObjects = new List<GameObject>();

	[SerializeField]
	int startCapacity = 4;

	void Start()
	{
		for(int i=0; i < startCapacity; ++i)
		{
			GameObject hp = (GameObject)Instantiate(hitpointPrefab);
			currentHitpointObjects.Add(hp);
			hp.transform.SetParent(this.transform,false);
		}

		SetHealth(0);
	}


	public void SetHealth(int amount)
	{
		int difference = amount - currentHitpointObjects.Count;

		if(difference > 0)
		{
			for(int i = 0; i < difference; ++i)
			{
				GameObject hp = (GameObject)Instantiate(hitpointPrefab);
				currentHitpointObjects.Add(hp);
				hp.transform.SetParent(this.transform,false);
			}
		}

		health = amount;
		RepositionHitpointObjects();
	}


	void RepositionHitpointObjects()
	{
		int currentUsedIndex = health / 2 * -1;

		for(int i=0; i < currentHitpointObjects.Count; ++i)
		{

			//extra objects are just disabled
			if(i > health - 1)
			{
				currentHitpointObjects[i].SetActive(false);
			}
			else
			{
				currentHitpointObjects[i].SetActive(true);
				currentHitpointObjects[i].transform.localPosition = new Vector3(currentUsedIndex * distance + ((health % 2 == 0) ? distance * 0.5f : 0.0f),0,0);
				currentUsedIndex++;
			}

		}
	}

}
