using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;

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
    [SerializeField]
    TouchInputManager touchInputManager;

    public TouchInputManager GetTouchInputManager {  get { return touchInputManager; } }

    [SerializeField]
	bool gameStarted = false;

    [SerializeField]
    AIPlayer AI1;

    [SerializeField]
    AIPlayer AI2;

    [SerializeField]
	float gameTimer = 300.0f;

	[SerializeField]
	Text gameTimerText;

	//money updaterate in seconds
	public float MONEY_UPDATE_RATE = 2.0f;

	[SerializeField]
	float moneyRate = 0;

	float timeAccumulatorMoney = 0.0f;

	//[SerializeField]
	//float waveInterval = 5.0f;

	//[SerializeField]
	//float timeAccumulatorWaves = 0.0f;

	//public delegate void WaveTriggerDelegate();
	//public event WaveTriggerDelegate OnNewWave = null;


	[SerializeField]
	float _player1money = 0;

	[SerializeField]
	GameObject gameOverText;

	[SerializeField]
	MoneyBar _player1MoneyBar;

	public float Player1Money 
	{
		get { return _player1money; }
		set 
		{ 
			
			value = Mathf.Clamp(value,0.0f,forcedMaxMoney);
			_player1money = value;
			_player1MoneyBar.SetCutout(Mathf.Clamp01(_player1money / forcedMaxMoney));
		}
	}

	[SerializeField]
	MoneyBar _player2MoneyBar;

	[SerializeField]
	float _player2money = 0;

	public float Player2Money 
	{
		get { return _player2money; }
		set 
		{ 
			value = Mathf.Clamp(value,0.0f,forcedMaxMoney);
			_player2money = value;
			_player2MoneyBar.SetCutout(Mathf.Clamp01(_player2money / forcedMaxMoney));
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
	float forcedMaxMoney = 10.0f;

	[SerializeField]
	Text player1scoreText;

	[SerializeField]
	Text player2scoreText;

	[SerializeField]
	PlayerGameDataList _playerData = new PlayerGameDataList();

	public PlayerGameDataList playerData { get { return _playerData; } }

	[SerializeField]
	Transform UI_root;

	[SerializeField]
	GameObject UI_moneyPrefab;

    [SerializeField]
    Dropdown player1DD;

    [SerializeField]
    Dropdown player2DD;

    void Start()
	{
		//forcing refresh at start because of inspector filling of starting money
		Player1Money = _player1money;
		Player2Money = _player2money;
	}

	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.Escape))
			Application.Quit();

		if(!gameStarted)
			return;

		timeAccumulatorMoney += Time.deltaTime;

		while(timeAccumulatorMoney >= MONEY_UPDATE_RATE)
		{
			timeAccumulatorMoney -= MONEY_UPDATE_RATE;
			UpdateMoney();
		}

		gameTimer -= Time.deltaTime;
		int seconds = ((int)gameTimer) % 60;
		int minutes = ((int)gameTimer) / 60;
		gameTimerText.text = minutes.ToString() + ":" + seconds.ToString();

		if(gameTimer <= 0.0f)
			gameOverText.SetActive(true);

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
		

    public void SetPlayer(int index)
    {
        bool aiEnabled = index == 0 ? player1DD.value == 1 : player2DD.value == 1;
        playerData.data[index].AI = aiEnabled;

        if (aiEnabled)
            touchInputManager.BlockHalf(index);
        else
            touchInputManager.EnableHalf(index);

        if (index == 0)
            AI1.enabled = aiEnabled;
        else
            AI2.enabled = aiEnabled;
    }

	public void StartGame()
	{
		gameStarted = true;
		gameTimerText.gameObject.SetActive(true);
	}
}
