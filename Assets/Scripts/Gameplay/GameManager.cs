﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum INPUT_STATES
{
	FREE,
	PICKING_BUILDING_CARD_TARGET
}

public enum ENERGY_BUILDING_TYPES
{
	COAL,
	NUCLEAR,
	WINDMILL,
	SOLAR,
	BIO_OIL,
	GAS
}


public class GameManager : MonoBehaviour 
{
	//money updaterate in seconds
	public float MONEY_UPDATE_RATE = 2.0f;
	float timeAccumulatorMoney = 0.0f;

	//[SerializeField]
	//float waveInterval = 5.0f;

	//[SerializeField]
	//float timeAccumulatorWaves = 0.0f;

	//public delegate void WaveTriggerDelegate();
	//public event WaveTriggerDelegate OnNewWave = null;


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
	int _player1score = 0;

	public int Player1Score 
	{
		get { return _player1score; }
		set 
		{ 
			if(value < 0) value = 0;
			_player1score = value;
			player1scoreText.text = _player1score.ToString();
		}
	}

	[SerializeField]
	int _player2score = 0;

	public int Player2Score
	{
		get { return _player2score; }
		set 
		{ 
			if(value < 0) value = 0;
			_player2score = value;
			player2scoreText.text = _player2score.ToString();
		}
	}


	[SerializeField]
	int moneyRate = 0;


	[SerializeField]
	Text player1moneyText;

	[SerializeField]
	Text player2moneyText;

	[SerializeField]
	Text player1scoreText;

	[SerializeField]
	Text player2scoreText;

	[SerializeField]
	PlayerGameDataList _playerData = new PlayerGameDataList();

	public PlayerGameDataList playerData { get { return _playerData; } }

	void Start()
	{
		//forcing refresh at start because of inspector filling of starting money
		Player1Money = Player1Money;
		Player2Money = Player2Money;
	}

	void Update () 
	{
		timeAccumulatorMoney += Time.deltaTime;

		while(timeAccumulatorMoney >= MONEY_UPDATE_RATE)
		{
			timeAccumulatorMoney -= MONEY_UPDATE_RATE;
			UpdateMoney();

		}
		/*
		timeAccumulatorWaves += Time.deltaTime;

		while(timeAccumulatorWaves >= waveInterval)
		{
			timeAccumulatorWaves -= waveInterval;
			if(OnNewWave != null)
				OnNewWave();
		}	*/
	}

	void UpdateMoney()
	{
		Player1Money += moneyRate;
		Player2Money += moneyRate;
	}

	public void StartEnergyBuildingTileSelection(Card card)
	{
		PlayerGameData pdata = playerData[card.Owner];

		foreach(HexagonTile t in pdata.tiles)
		{
			if(t.AllowBuild)
				t.SetOutline(true);
		}
			
		pdata.currentInputState = INPUT_STATES.PICKING_BUILDING_CARD_TARGET;

	}



	//temp fix for using mouse, this will be useless when touch input is used
	public bool raycastedOn2DObject = false;

	void LateUpdate()
	{
		raycastedOn2DObject = false;
	}
}
