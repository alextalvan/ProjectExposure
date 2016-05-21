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
	List<Card> cardPrefabs = new List<Card>();

	//this list is used for picking random new card that the player doesn't already have
	[SerializeField]
	List<Card> cardDrawPossibilities = new List<Card>();

	//keeping track of currently created cards
	//[SerializeField]
	List<Card> currentCardsHeld = new List<Card>();

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
			for(int i=cardDrawPossibilities.Count - 1; i > -1; --i)
			{
				if(HasCardOfType(cardDrawPossibilities[i].CardType))
					cardDrawPossibilities.RemoveAt(i);
			}

			GameObject randomCard = cardDrawPossibilities[Random.Range(0,cardDrawPossibilities.Count)].gameObject;
			GameObject card = (GameObject)Instantiate(randomCard);
			cardCount++;
			cardsToSpawn--;


			Card cardComp = card.GetComponent<Card>();
			card.transform.SetParent(this.transform,false);
			cardComp.Owner = player;
			currentCardsHeld.Add(cardComp);
			cardComp.OnDestruction += () => {this.cardCount--; currentCardsHeld.Remove(cardComp);};

			//doing this at the end to allow cards set in the inspector for starting out with
			cardDrawPossibilities.Clear();
			cardDrawPossibilities.AddRange(cardPrefabs);
		}
	}


	bool HasCardOfType(CARD_TYPES t)
	{
		foreach(Card c in currentCardsHeld)
		{
			if(c.CardType == t)
				return true;
		}

		return false;
	}
}
