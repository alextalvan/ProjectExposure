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
    TouchInputManager touchInputManager;

    public TouchInputManager GetTouchInputManager { get { return touchInputManager; } }

    public bool gameStarted = false;

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

    float timeAccumulatorMoney = 0.1f;

    [SerializeField]
    float _player1money = 0;

    [SerializeField]
    Image _player1barImage;

    [SerializeField]
    float _player2money = 0;

    [SerializeField]
    Image _player2barImage;

    [SerializeField]
    CityScript city;

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
            _player1MoneyBar.SetCutout(Mathf.Clamp01(_player1money / currentStage.forcedMaxMoney));
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
            _player2MoneyBar.SetCutout(Mathf.Clamp01(_player2money / currentStage.forcedMaxMoney));
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

    [SerializeField]
    Renderer scoreRenderer1;

    float prevScoreFloat = 0.5f;
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

    //[SerializeField]
    //Text gameOverText;

    private int prevUnitsAlive = 0;

    [SerializeField]
    List<PollutionZone> redPollutionSpots;

    [SerializeField]
    List<PollutionZone> bluePollutionSpots;

    private bool battleStarted = false;


    //camera zoom variables
    bool zoomInProgress = false;

    [SerializeField]
    Camera zoomCamera;

    [SerializeField]
    float zoomOrthoDistance = 1.5f;

    [SerializeField]
    float normalOrthoDistance = 4.0f;

    [SerializeField]
    float zoomDuration = 0.5f;

    [SerializeField]
    float centralFocusDuration = 1.0f;

    bool zoomedOnce = false;

    //[SerializeField]
    //int scoreThreshold = 6;

    [SerializeField]
    GameObject gameOverRoot;

    [SerializeField]
    GameObject crownPlayer1;

    [SerializeField]
    GameObject crownPlayer2;

    [SerializeField]
    Text player1ScoreText;

    [SerializeField]
    Text player2ScoreText;

    float currentHLval = 1f;
    float targetHLval = 1f;
    [SerializeField]
    float HLval = 3f;
    [SerializeField]
    float nonHLval = 1f;

    int targetEndScreenScorePlayer1 = 0, targetEndScreenScorePlayer2 = 0, currentEndScreenScorePlayer1 = 0, currentEndScreenScorePlayer2 = 0;

    void Start()
    {
        GameSettings gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        //forcing refresh at start because of inspector filling of starting money
        Player1Money = _player1money;
        Player2Money = _player2money;

        zoomInProgress = true;
        ChangeScore(0, PLAYERS.PLAYER1, LANES.TOP);//force score refresh at start
        ChangeScore(0, PLAYERS.PLAYER1, LANES.BOT);
        zoomInProgress = false;
        SetPlayer(0, gameSettings.Player1AI);
        SetPlayer(1, gameSettings.Player2AI);
        Destroy(gameSettings.gameObject);
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(waveCoolDown);

        foreach (PollutionZone pol in redPollutionSpots)
            pol.HandleNewWave();

        foreach (PollutionZone pol in bluePollutionSpots)
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
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyUp(KeyCode.Space))
            Application.LoadLevel(0);

        UpdateEndGameScores();

        if (!battleStarted)
        {
            if (!gameStarted && (playerData[PLAYERS.PLAYER1].buildings.Count + playerData[PLAYERS.PLAYER2].buildings.Count) > 1)
                StartGame();
            if (playerData[PLAYERS.PLAYER1].ready && playerData[PLAYERS.PLAYER2].ready)
            {
                battleStarted = true;
            }
            prevUnitsAlive = 1;
        }

        while (timeAccumulatorMoney >= MONEY_UPDATE_RATE)
        {
            timeAccumulatorMoney -= MONEY_UPDATE_RATE;
            UpdateMoney();
        }

        if (!gameStarted)
            return;

        timeAccumulatorMoney += Time.deltaTime;

        if (battleStarted && playerData[PLAYERS.PLAYER1].units.Count + playerData[PLAYERS.PLAYER2].units.Count <= 0 && prevUnitsAlive > 0)
        {
            StartCoroutine(SpawnWave());
        }

        player1MoneyBoostTime -= Time.deltaTime;
        player2MoneyBoostTime -= Time.deltaTime;

        gameTimer -= Time.deltaTime;
        int seconds = ((int)gameTimer) % 60;
        int minutes = ((int)gameTimer) / 60;
        gameTimerText.text = minutes.ToString() + ":" + seconds.ToString();

        currentScoreFloat = Mathf.Lerp(currentScoreFloat, targetScoreFloat, scoreBarInterpolationSpeed);
        scoreRenderer.material.SetFloat("_CityClip", currentScoreFloat);
        scoreRenderer1.material.SetFloat("_CityClip", currentScoreFloat);
        if (Mathf.Abs(prevScoreFloat - currentScoreFloat) > 0.001f)
        {
            targetHLval = HLval;
            currentHLval = Mathf.Lerp(currentHLval, targetHLval, scoreBarInterpolationSpeed);
            scoreRenderer.material.SetFloat("_Emission_Intensity_player1", currentHLval);
            scoreRenderer.material.SetFloat("_Emission_Intensity_player2", currentHLval);
            scoreRenderer1.material.SetFloat("_Emission_Intensity_player1", currentHLval);
            scoreRenderer1.material.SetFloat("_Emission_Intensity_player2", currentHLval);
        }
        else
        {
            targetHLval = nonHLval;
            currentHLval = Mathf.Lerp(currentHLval, targetHLval, scoreBarInterpolationSpeed);
            scoreRenderer.material.SetFloat("_Emission_Intensity_player1", currentHLval);
            scoreRenderer.material.SetFloat("_Emission_Intensity_player2", currentHLval);
            scoreRenderer1.material.SetFloat("_Emission_Intensity_player1", currentHLval);
            scoreRenderer1.material.SetFloat("_Emission_Intensity_player2", currentHLval);
        }
        prevScoreFloat = currentScoreFloat;

        //		if(gameScore >= maxScore)
        //		{
        //			gameOverText.transform.parent.gameObject.SetActive(true);
        //			gameOverText.text = "Game over. Blue wins.";
        //			gameStarted = false;
        //		}
        //
        //		if(gameScore <= maxScore * -1)
        //		{
        //			gameOverText.transform.parent.gameObject.SetActive(true);
        //			gameOverText.text = "Game over. Red wins.";
        //			gameStarted = false;
        //		}

        if (gameTimer <= 0.0f)
        {
            gameOverRoot.SetActive(true);
            gameStarted = false;
            //int finalScore = Mathf.RoundToInt(topLaneScoreData.Score) + Mathf.RoundToInt(botLaneScoreData.Score);

            //if (gameScore == 0)
            //    gameOverText.text = "Game over. Draw.";

            if (gameScore > 0)
            {
                crownPlayer2.SetActive(true);
                targetEndScreenScorePlayer2 = 600 * Mathf.Abs(gameScore) / maxScore;
                targetEndScreenScorePlayer1 = 600 - targetEndScreenScorePlayer1;
                GetComponent<DBconnection>().SendScore(targetEndScreenScorePlayer1);
            }

            if (gameScore < 0)
            {
                crownPlayer1.SetActive(true);
                targetEndScreenScorePlayer1 = 600 * Mathf.Abs(gameScore) / maxScore;
                targetEndScreenScorePlayer2 = 600 - targetEndScreenScorePlayer2;
                GetComponent<DBconnection>().SendScore(targetEndScreenScorePlayer1);
            }

            if (gameScore == 0)
            {
                targetEndScreenScorePlayer1 = 300;
                targetEndScreenScorePlayer2 = 300;
                GetComponent<DBconnection>().SendScore(300);
            }

            StartCoroutine(DelayedExit());
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
        prevUnitsAlive = playerData[PLAYERS.PLAYER1].units.Count + playerData[PLAYERS.PLAYER2].units.Count;

        //if(Input.GetKeyDown(KeyCode.J))
        //	StartCoroutine(ZoomIn());
    }

    void UpdateMoney()
    {
        Player1Money += moneyRate * ((player1MoneyBoostTime > 0.0f) ? moneyBoostStrength : 1.0f);
        Player2Money += moneyRate * ((player2MoneyBoostTime > 0.0f) ? moneyBoostStrength : 1.0f);

        if (player1MoneyBoostTime > 0)
            _player1barImage.color = new Color(0f, 1.0f, 0.2f, 1f);
        else
            _player1barImage.color = Color.white;

        if (player2MoneyBoostTime > 0)
            _player2barImage.color = new Color(0f, 1.0f, 0.2f, 1f);
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


    public void SetPlayer(int index, bool aiEnabled)
    {
        playerData.data[index].AI = aiEnabled;

        if (index == 0)
        {
            if (aiEnabled)
            {
                AI1.Mod = AIPlayer.AIMod.AI;
                touchInputManager.BlockHalf(index);
            }
        }
        else
        {
            if (aiEnabled)
            {
                AI2.Mod = AIPlayer.AIMod.AI;
                touchInputManager.BlockHalf(index);
            }
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        gameTimerText.gameObject.SetActive(true);
    }

    public void ChangeScore(int score, PLAYERS owner, LANES lane)
    {
        //float scoreDelta = score * ((owner == PLAYERS.PLAYER1) ? -1.0f : 1.0f);

        if (!gameStarted) return;

        if (owner == PLAYERS.PLAYER1)
            score *= -1;

        gameScore += score;
        city.SpawnNewBuilding();

        if (!zoomedOnce)
        {
            if (gameScore != 0 /*&& Mathf.Abs(gameScore) % 3 == 0*/ && !zoomInProgress)
            {
                StartCoroutine(ZoomIn());
                zoomInProgress = true;
                zoomedOnce = true;
            }
        }
        else
        {
            targetScoreFloat = 1.0f - (((float)gameScore / (float)maxScore) * 0.5f + 0.5f);
            if (gameScore >= maxScore)
            {
                gameOverRoot.SetActive(true);
                crownPlayer2.SetActive(true);
                targetEndScreenScorePlayer2 = 600;// * Mathf.Abs(gameScore) / maxScore;
                targetEndScreenScorePlayer1 = 0;// - targetEndScreenScorePlayer2;
                gameStarted = false;
                GetComponent<DBconnection>().SendScore(0);
                StartCoroutine(DelayedExit());
            }
            else if (gameScore <= -maxScore)
            {
                gameOverRoot.SetActive(true);
                crownPlayer1.SetActive(true);
                targetEndScreenScorePlayer1 = 600;// * Mathf.Abs(gameScore) / maxScore;
                targetEndScreenScorePlayer2 = 0;// - targetEndScreenScorePlayer1;
                gameStarted = false;
                GetComponent<DBconnection>().SendScore(600);
                StartCoroutine(DelayedExit());
            }
        }
        //targetScoreFloat = 1.0f -  (((float)gameScore / (float)maxScore) * 0.5f + 0.5f); //moved this in the zoom coroutine
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

    public void LoadFirstLevel()
    {
        Application.LoadLevel(0);
    }

    IEnumerator ZoomIn()
    {
        bool zooming = true;
        //float currentZoom = normalOrthoDistance;
        float timeAccumulator = 0.0f;

        while (zooming)
        {
            zoomCamera.orthographicSize = Mathf.Lerp(normalOrthoDistance, zoomOrthoDistance, timeAccumulator / zoomDuration);
            timeAccumulator += Time.deltaTime;
            if (timeAccumulator >= zoomDuration)
                zooming = false;
            yield return null;//wait for next frame
        }

        targetScoreFloat = 1.0f - (((float)gameScore / (float)maxScore) * 0.5f + 0.5f);
        yield return new WaitForSeconds(centralFocusDuration);

        StartCoroutine(ZoomOut());
    }

    IEnumerator ZoomOut()
    {
        bool zooming = true;
        //float currentZoom = normalOrthoDistance;
        float timeAccumulator = 0.0f;

        while (zooming)
        {
            zoomCamera.orthographicSize = Mathf.Lerp(zoomOrthoDistance, normalOrthoDistance, timeAccumulator / zoomDuration);
            timeAccumulator += Time.deltaTime;
            if (timeAccumulator >= zoomDuration)
                zooming = false;
            yield return null;//wait for next frame
        }

        zoomInProgress = false;

    }

    void UpdateEndGameScores()
    {
        int speed = 2;

        currentEndScreenScorePlayer1 += speed;
        if (currentEndScreenScorePlayer1 > targetEndScreenScorePlayer1)
            currentEndScreenScorePlayer1 = targetEndScreenScorePlayer1;

        player1ScoreText.text = currentEndScreenScorePlayer1.ToString();

        currentEndScreenScorePlayer2 += speed;
        if (currentEndScreenScorePlayer2 > targetEndScreenScorePlayer2)
            currentEndScreenScorePlayer2 = targetEndScreenScorePlayer2;

        player2ScoreText.text = currentEndScreenScorePlayer2.ToString();
    }

    IEnumerator DelayedExit()
    {
        yield return new WaitForSeconds(15.0f);
        Application.Quit();
    }

    public void InterruptExit()
    {
        StopCoroutine(DelayedExit());
    }
}
