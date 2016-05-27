using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NeutralCardSpawner : GameManagerSearcher 
{
	[SerializeField]
	List<GameObject> cardList = new List<GameObject>();

	List<GameObject> spawnPossibilities;

	[SerializeField]
	GameObject currentCard = null;
	GameObject lastPrefabUsed = null;

	[SerializeField]
	float switchCooldown = 5.0f;

	[SerializeField]
	float switchTimerAccumulator = 0.0f;

	[SerializeField]
	List<CARD_TYPES> actionCardTypes =  new List<CARD_TYPES>();
	[SerializeField]
	List<CARD_TYPES> greenBuildingCardTypes = new List<CARD_TYPES>();
	[SerializeField]
	List<CARD_TYPES> fossilBuildingactionCardTypes = new List<CARD_TYPES>();

	[SerializeField]
	float blockDuration = 4.5f;

	[SerializeField]
	float player1BlockTime = 10.0f;

	[SerializeField]
	float player2BlockTime = 10.0f;

	[SerializeField]
	Image player1ButtonImage;

	[SerializeField]
	Image player2ButtonImage;

	void Start()
	{
		spawnPossibilities = new List<GameObject>(cardList);
	}

	void Update()
	{
		switchTimerAccumulator += Time.deltaTime;
		if(switchTimerAccumulator >= switchCooldown)
		{
			if(currentCard != null)
			{
				Destroy(currentCard);
				currentCard = null;
			}

			SpawnCard();


			switchTimerAccumulator = 0;
			//currentCard = (GameObject)Instantiate
		}

		HandlePlayerBlock();

	}

	void HandlePlayerBlock()
	{
		player1BlockTime -= Time.deltaTime;
		if(player1BlockTime <= 0.0f && currentCard != null && currentCard.GetComponent<Card>().MoneyCost <= gameManager.Player1Money)
			player1ButtonImage.color = Color.green;
		else
			player1ButtonImage.color = Color.red;

		player2BlockTime -= Time.deltaTime;
		if(player2BlockTime <= 0.0f && currentCard != null && currentCard.GetComponent<Card>().MoneyCost <= gameManager.Player2Money)
			player2ButtonImage.color = Color.green;
		else
			player2ButtonImage.color = Color.red;
	}

	public void BuyCardAttempt(PLAYERS player, CardHolderGroup holderGroup)
	{

		if(currentCard == null)
			return;

		Card cardComp = currentCard.GetComponent<Card>();
		int cardCost = cardComp.MoneyCost;


		if(player == PLAYERS.PLAYER1 && player1BlockTime <= 0.0f && gameManager.Player1Money >= cardCost)
		{
			gameManager.Player1Money -= cardCost;
			//currentCard.GetComponent<CardGlide>().SetTarget(targetHolder);
			cardComp.Owner = PLAYERS.PLAYER1;

			if(actionCardTypes.Contains(cardComp.CardType))
			{
				currentCard.GetComponent<CardGlide>().SetTarget(holderGroup.ActionCardSpawnPoint);
				holderGroup.RegisterCard(cardComp,holderGroup.ActionCardSpawnPoint);
				currentCard.transform.parent = holderGroup.ActionCardSpawnPoint;
			}

			if(greenBuildingCardTypes.Contains(cardComp.CardType))
			{
				currentCard.GetComponent<CardGlide>().SetTarget(holderGroup.GreenBuildingCardSpawnPoint);
				holderGroup.RegisterCard(cardComp,holderGroup.GreenBuildingCardSpawnPoint);
				currentCard.transform.parent = holderGroup.GreenBuildingCardSpawnPoint;
			}

			if(fossilBuildingactionCardTypes.Contains(cardComp.CardType))
			{
				currentCard.GetComponent<CardGlide>().SetTarget(holderGroup.FossilBuildingCardSpawnPoint);
				holderGroup.RegisterCard(cardComp,holderGroup.FossilBuildingCardSpawnPoint);
				currentCard.transform.parent = holderGroup.FossilBuildingCardSpawnPoint;
			}


			player1BlockTime = blockDuration;

			currentCard = null;
			return;
		}

		if(player == PLAYERS.PLAYER2 && player2BlockTime <= 0.0f && gameManager.Player2Money >= cardCost)
		{
			gameManager.Player2Money -= cardCost;
			//currentCard.GetComponent<CardGlide>().SetTarget(targetHolder);
			currentCard.GetComponent<Card>().Owner = PLAYERS.PLAYER2;

			if(actionCardTypes.Contains(cardComp.CardType))
			{
				currentCard.GetComponent<CardGlide>().SetTarget(holderGroup.ActionCardSpawnPoint);
				holderGroup.RegisterCard(cardComp,holderGroup.ActionCardSpawnPoint);
				currentCard.transform.parent = holderGroup.ActionCardSpawnPoint;
			}

			if(greenBuildingCardTypes.Contains(cardComp.CardType))
			{
				currentCard.GetComponent<CardGlide>().SetTarget(holderGroup.GreenBuildingCardSpawnPoint);
				holderGroup.RegisterCard(cardComp,holderGroup.GreenBuildingCardSpawnPoint);
				currentCard.transform.parent = holderGroup.GreenBuildingCardSpawnPoint;
			}

			if(fossilBuildingactionCardTypes.Contains(cardComp.CardType))
			{
				currentCard.GetComponent<CardGlide>().SetTarget(holderGroup.FossilBuildingCardSpawnPoint);
				holderGroup.RegisterCard(cardComp,holderGroup.FossilBuildingCardSpawnPoint);
				currentCard.transform.parent = holderGroup.FossilBuildingCardSpawnPoint;
			}

			player2BlockTime = blockDuration;

			currentCard = null;
			return;
		}
	}


	void SpawnCard()
	{
		GameObject newPrefabUsed = spawnPossibilities[Random.Range(0,spawnPossibilities.Count)];
		if(lastPrefabUsed !=null)
			spawnPossibilities.Add(lastPrefabUsed);
		spawnPossibilities.Remove(newPrefabUsed);

		lastPrefabUsed = newPrefabUsed;


		currentCard = (GameObject)Instantiate(newPrefabUsed);
		currentCard.transform.SetParent(this.transform,false);

	}
}
