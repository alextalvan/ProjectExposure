using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	//global game logic updaterate in seconds
	public const float UPDATE_RATE = 1.0f;

	float timeAccumulator = 0.0f;

	[SerializeField]
	int _player1money = 0;

	public int Player1Money 
	{
		get { return _player1money; }
		set 
		{ 
			if(value < 0) value = 0;
			_player1money = value;
			player1moneyText.text = _player1money.ToString();
		}
	}

	[SerializeField]
	int _player2money = 0;

	public int Player2Money 
	{
		get { return _player2money; }
		set 
		{ 
			if(value < 0) value = 0;
			_player2money = value;
			player2moneyText.text = _player2money.ToString();
		}
	}

	[SerializeField]
	int moneyRate = 1;


	[SerializeField]
	Text player1moneyText;

	[SerializeField]
	Text player2moneyText;

	void Update () 
	{
		timeAccumulator += Time.deltaTime;

		while(timeAccumulator >= UPDATE_RATE)
		{
			timeAccumulator -= UPDATE_RATE;
			UpdateMoney();

		}
	}

	void UpdateMoney()
	{
		Player1Money += moneyRate;
		Player2Money += moneyRate;
	}

}
