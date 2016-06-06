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

		for(int i=0; i < currentHitpointObjects.Count; ++i)
		{
			currentHitpointObjects[i].GetComponent<SpriteFader>().Reset();
		}

		health = amount;
		RepositionHitpointObjects();


        //Debug.Log(amount.ToString() + " " + currentHitpointObjects.Count.ToString() + " " + difference.ToString());
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

	public void TakeDamage(int amount, float fadeDuration = 1.0f)
	{
		if(amount <= 0)
			return;

		if(amount > health) amount = health;

		for(int i = health - 1; i > health - amount - 1; --i)
		{
			currentHitpointObjects[i].GetComponent<SpriteFader>().StartFade(fadeDuration);
		}
	}

}
