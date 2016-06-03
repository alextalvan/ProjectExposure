using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStartScript : MonoBehaviour {

	[SerializeField]
	List<Card> firstWaveCards = new List<Card>();
	bool firstWaveDone = false;
	int firstCount = 0;

	[SerializeField]
	List<Card> secondWaveCards = new List<Card>();
	bool secondWaveDone = false;
	int secondCount = 0;

	[SerializeField]
	List<Card> thirdWaveCards = new List<Card>();
	bool thirdWaveDone = false;
	int thirdCount = 0;

	// Use this for initialization
	void Start () 
	{
		foreach(Card c in firstWaveCards)
		{
			c.OnDestruction += () => { firstCount--; };
			c.gameObject.SetActive(true);
		}

		firstCount = firstWaveCards.Count;
		secondCount = secondWaveCards.Count;
		thirdCount = thirdWaveCards.Count;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(firstCount == 0 && !firstWaveDone)
		{
			foreach(Card c in secondWaveCards)
			{
				c.OnDestruction += () => { secondCount--; };
				c.gameObject.SetActive(true);
			}
			firstWaveDone = true;
		}

		if(secondCount == 0 && !secondWaveDone)
		{
			foreach(Card c in thirdWaveCards)
			{
				c.OnDestruction += () => { thirdCount--; };
				c.gameObject.SetActive(true);
			}

			secondWaveDone = true;
		}

		if(thirdCount == 0 && !thirdWaveDone)
		{
			thirdWaveDone = true;
			GetComponent<GameManager>().StartGame();
			this.enabled = false;
		}
	}
}
