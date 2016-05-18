using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class CardSpawner : MonoBehaviour 
{
	[SerializeField]
	PLAYERS player;

	[SerializeField]
	float spawnInterval = 5.0f;

	[SerializeField]
	int maximumCards = 4;

	[SerializeField]
	int cardsToSpawn = 2;

	[SerializeField]
	List<GameObject> cardPrefabs = new List<GameObject>();

	[SerializeField]
	float timeAccumulator = 0.0f;

	[SerializeField]
	int cardCount = 0;

	int capturedObjectCount = 0;

	void Start()
	{
		GetComponent<Collider2D>().isTrigger = true;
	}

	void OnTriggerEnter2D()
	{
		capturedObjectCount++;
	}

	void OnTriggerExit2D()
	{
		capturedObjectCount--;
	}


	void FixedUpdate()
	{

		if(cardCount < maximumCards)
			timeAccumulator += Time.fixedDeltaTime;

		while(timeAccumulator >= spawnInterval)
		{
			timeAccumulator -= spawnInterval;
			cardsToSpawn++;
		}
			
		if(capturedObjectCount == 0 && cardsToSpawn > 0)
		{
			GameObject randomCard = cardPrefabs[Random.Range(0,cardPrefabs.Count)];
			GameObject card = (GameObject)Instantiate(randomCard);
			cardCount++;
			cardsToSpawn--;


			Card cardComp = card.GetComponent<Card>();
			card.transform.SetParent(this.transform,false);
			cardComp.Owner = player;
			cardComp.OnDestruction += () => {this.cardCount--;};
		}
	}
}
