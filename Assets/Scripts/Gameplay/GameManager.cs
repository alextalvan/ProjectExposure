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
    OIL,
    NUCLEAR,
    WINDMILL,
    SOLAR,
    BIO_OIL,
    GAS
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    float waveCoolDown = 5f;
    public float WaveCooldown { get { return waveCoolDown; } }

    [SerializeField]
    int waveWinScore = 1;
    public int GetWaveWinScore { get { return waveWinScore; } }

    [SerializeField]
    TouchInputManager touchInputManager;

    public TouchInputManager GetTouchInputManager { get { return touchInputManager; } }

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

    [SerializeField]
    float _player1money = 0;

	[SerializeField]
	Image _player1barImage;

    [SerializeField]
    float _player2money = 0;

	[SerializeField]
	Image _player2barImage;

    //[SerializeField]
    //ScoreData topLaneScoreData = new ScoreData();

    //[SerializeField]
    //ScoreData botLaneScoreData = new ScoreData();



    [SerializeField]
    MoneyBar _player1MoneyBar;

    public float Player1Money
    {
        get { return _player1money; }
        set
        {

            value = Mathf.Clamp(value, 0.0f, currentStage.forcedMaxMoney);
            _player1money = value;
            _player1MoneyBar.SetCutout(Mathf.Clamp01(_player1money / 10f));
        }
    }

    [SerializeField]
    MoneyBar _player2MoneyBar;



    public float Player2Money
    {
        get { return _player2money; }
        set
        {
            value = Mathf.Clamp(value, 0.0f, currentStage.forcedMaxMoney);
            _player2money = value;
            _player2MoneyBar.SetCutout(Mathf.Clamp01(_player2money / 10f));
        }
    }

	public float player1MoneyBoostTime = -1.0f;
	public float player2MoneyBoostTime = -1.0f;

	[SerializeField]
	float moneyBoostStrength = 4.0f;

    //	[SerializeField]
    //	int _player1score = 0;
    //
    //	public int Player1Score 
    //	{
    //		get { return _player1score; }
    //		set 
    //		{ 
    //			if(value < 0) value = 0;
    //			_player1score = value;
    //			player1scoreText.text = _player1score.ToString();
    //		}
    //	}
    //
    //	[SerializeField]
    //	int _player2score = 0;
    //
    //	public int Player2Score
    //	{
    //		get { return _player2score; }
    //		set 
    //		{ 
    //			if(value < 0) value = 0;
    //			_player2score = value;
    //			player2scoreText.text = _player2score.ToString();
    //		}
    //	}

	[SerializeField]
	int gameScore = 0;

	[SerializeField]
	int maxScore = 9;

	[SerializeField]
	Renderer scoreRenderer;

	float currentScoreFloat = 0.5f;
	float targetScoreFloat = 0.5f;

	[SerializeField]
	float scoreBarInterpolationSpeed = 0.1f;


    [SerializeField]
    List<GameStage> gameStages = new List<GameStage>();
    int currentGameStageIndex = 0;
    public GameStage currentStage { get { return gameStages[currentGameStageIndex]; } }

    //	[SerializeField]
    //	Text player1scoreText;
    //
    //	[SerializeField]
    //	Text player2scoreText;

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

    [SerializeField]
    Text gameOverText;

    private int unitsAlive = 0;
    public int UnitsAlive { get { return unitsAlive; } set { unitsAlive = value; } }

	[SerializeField]
	List<PollutionZone> redPollutionSpots;

	[SerializeField]
	List<PollutionZone> bluePollutionSpots;

    void Start()
    {
        //forcing refresh at start because of inspector filling of starting money
        Player1Money = _player1money;
        Player2Money = _player2money;
        ChangeScore(0, PLAYERS.PLAYER1, LANES.TOP);//force score refresh at start
        ChangeScore(0, PLAYERS.PLAYER1, LANES.BOT);
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(waveCoolDown);

		//Debug.Log("test");

		foreach(PollutionZone pol in redPollutionSpots)
			pol.HandleNewWave();

		foreach(PollutionZone pol in bluePollutionSpots)
			pol.HandleNewWave();

        foreach (HexagonTile tile in playerData[PLAYERS.PLAYER1].tiles)
        {
			if (tile.CurrentEnergyBuilding && tile.CurrentEnergyBuilding.ConstructionTimeLeft < 0.0f)
                tile.CurrentEnergyBuilding.GetComponent<UnitSpawner>().SpawnUnits();
        }
        foreach (HexagonTile tile in playerData[PLAYERS.PLAYER2].tiles)
        {
			if (tile.CurrentEnergyBuilding && tile.CurrentEnergyBuilding.ConstructionTimeLeft < 0.0f)
                tile.CurrentEnergyBuilding.GetComponent<UnitSpawner>().SpawnUnits();
        }
        unitsAlive--;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyUp(KeyCode.Space))
            Application.LoadLevel(0);

        if (!gameStarted)
            return;

        timeAccumulatorMoney += Time.deltaTime;

        while (timeAccumulatorMoney >= MONEY_UPDATE_RATE)
        {
            timeAccumulatorMoney -= MONEY_UPDATE_RATE;
            UpdateMoney();
        }

		player1MoneyBoostTime -= Time.deltaTime;
		player2MoneyBoostTime -= Time.deltaTime;

        gameTimer -= Time.deltaTime;
        int seconds = ((int)gameTimer) % 60;
        int minutes = ((int)gameTimer) / 60;
        gameTimerText.text = minutes.ToString() + ":" + seconds.ToString();

		currentScoreFloat = Mathf.Lerp(currentScoreFloat, targetScoreFloat, scoreBarInterpolationSpeed);
		scoreRenderer.material.SetFloat("_CityClip", currentScoreFloat);


		if(gameScore >= maxScore)
		{
			gameOverText.gameObject.SetActive(true);
			gameOverText.text = "Game over. Blue wins.";
			gameStarted = false;
		}

		if(gameScore <= maxScore * -1)
		{
			gameOverText.gameObject.SetActive(true);
			gameOverText.text = "Game over. Red wins.";
			gameStarted = false;
		}

        if (gameTimer <= 0.0f)
        {
            gameOverText.gameObject.SetActive(true);
			gameStarted = false;
            //int finalScore = Mathf.RoundToInt(topLaneScoreData.Score) + Mathf.RoundToInt(botLaneScoreData.Score);

			if (gameScore == 0)
                gameOverText.text = "Game over. Draw.";

			if (gameScore > 0)
                gameOverText.text = "Game over. Blue wins.";

			if (gameScore < 0)
                gameOverText.text = "Game over. Red wins.";
        }

        if (unitsAlive <= 0)
        { 
            unitsAlive++;
            StartCoroutine(SpawnWave());
        }

        //
        //		if(gameTimer <= 0.0f)
        //			gameOverText.SetActive(true);

        UpdateGameStage();

        /*
		timeAccumulatorWaves += Time.deltaTime;

		while(timeAccumulatorWaves >= waveInterval)
		{
			timeAccumulatorWaves -= waveInterval;
			if(OnNewWave != null)
				OnNewWave();
		}	*/

        //CalculateWinCondition();

        //topLaneScoreData.Update();
        //botLaneScoreData.Update();



    }

    void UpdateMoney()
    {
		Player1Money += moneyRate * ((player1MoneyBoostTime > 0.0f) ? moneyBoostStrength : 1.0f);
		Player2Money += moneyRate * ((player2MoneyBoostTime > 0.0f) ? moneyBoostStrength : 1.0f);

		if (player1MoneyBoostTime > 0)
			_player1barImage.color = new Color(0f,0.8f,0f,1f);
		else
			_player1barImage.color = Color.white;
		
		if (player2MoneyBoostTime > 0)
			_player2barImage.color = new Color(0f,0.8f,0f,1f);
		else
			_player2barImage.color = Color.white;
    }

    void UpdateGameStage()
    {
        currentStage.duration -= Time.deltaTime;
        if (currentStage.duration <= 0.0f && currentGameStageIndex < gameStages.Count - 1)
            currentGameStageIndex++;
    }

    public void StartEnergyBuildingTileSelection(Card card)
    {
        PlayerGameData pdata = playerData[card.Owner];

        foreach (HexagonTile t in pdata.tiles)
        {
            if (t.AllowBuild)
                t.SetOutlineState(HexagonTile.OUTLINE_STATES.BUILD_NEW);
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

    public void ChangeScore(int score, PLAYERS owner, LANES lane)
    {
        //float scoreDelta = score * ((owner == PLAYERS.PLAYER1) ? -1.0f : 1.0f);

		if(owner == PLAYERS.PLAYER1)
			score *= -1;

		gameScore += score;


		targetScoreFloat = 1.0f -  (((float)gameScore / (float)maxScore) * 0.5f + 0.5f);
		//scoreRenderer.material.SetFloat("_CityClip", ((float)score / maxScore) * 0.5f + 0.5f);
    }

//    void CalculateWinCondition()
//    {
//
//		//if(gameScore == -1 * maxScore)
//
//
//        //float topRelativeScore = topLaneScoreData.Score / topLaneScoreData.MaxScore;
//        //float botRelativeScore = botLaneScoreData.Score / botLaneScoreData.MaxScore;
//
//        //if (Mathf.Abs(topRelativeScore) >= 0.9999f && Mathf.Abs(botRelativeScore) >= 0.9999f && Mathf.Sign(botRelativeScore) == Mathf.Sign(topRelativeScore))
//        //    gameTimer = -1.0f;//gameOverText.SetActive(true);
//    }
}
