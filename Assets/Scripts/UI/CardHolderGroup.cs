using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CardHolderGroup : MonoBehaviour {

	[SerializeField]
	int maxCardsPerGroup = 2;

	[SerializeField]
	Transform _actionCardSpawnPoint;
	public Transform ActionCardSpawnPoint { get { return _actionCardSpawnPoint; } }

	[SerializeField]
	List<Card> actionCards = new List<Card>();

	[SerializeField]
	Transform _greenBuildingCardSpawnPoint;
	public Transform GreenBuildingCardSpawnPoint { get { return _greenBuildingCardSpawnPoint; } }

	[SerializeField]
	List<Card> greenCards = new List<Card>();

	[SerializeField]
	Transform _fossilBuildingCardSpawnPoint;
	public Transform FossilBuildingCardSpawnPoint { get { return _fossilBuildingCardSpawnPoint; } }

	[SerializeField]
	List<Card> fossilCards = new List<Card>();

	void Start()
	{
		foreach(Card c in actionCards)
			c.OnDestruction += () => { actionCards.Remove(c); };

		foreach(Card c in greenCards)
			c.OnDestruction += () => { greenCards.Remove(c); };

		foreach(Card c in fossilCards)
			c.OnDestruction += () => { fossilCards.Remove(c); };
	}

	public void RegisterCard(Card c, Transform targetSpawnPoint)
	{
		if(targetSpawnPoint == _actionCardSpawnPoint)
		{
			actionCards.Add(c);
			c.OnDestruction += () => { actionCards.Remove(c); };
			if(actionCards.Count > maxCardsPerGroup)
			{
				Destroy(actionCards[0].gameObject);
				actionCards.RemoveAt(0);
			}
		}

		if(targetSpawnPoint == _greenBuildingCardSpawnPoint)
		{
			greenCards.Add(c);
			c.OnDestruction += () => { greenCards.Remove(c); };
			if(greenCards.Count > maxCardsPerGroup)
			{
				Destroy(greenCards[0].gameObject);
				greenCards.RemoveAt(0);
			}
		}

		if(targetSpawnPoint == _fossilBuildingCardSpawnPoint)
		{
			fossilCards.Add(c);
			c.OnDestruction += () => { fossilCards.Remove(c); };
			if(fossilCards.Count > maxCardsPerGroup)
			{
				Destroy(fossilCards[0].gameObject);
				fossilCards.RemoveAt(0);
			}
		}
	}
}
