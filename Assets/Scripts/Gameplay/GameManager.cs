using UnityEngine;
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
	HYDRO
}


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

	[SerializeField]
	PlayerGameDataList _playerData = new PlayerGameDataList();

	public PlayerGameDataList playerData { get { return _playerData; } }

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

	public void StartEnergyBuildingTileSelection(ActionCard card)
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
