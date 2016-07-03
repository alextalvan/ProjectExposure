using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class CoinPickup : GameManagerSearcher
{

    public PLAYERS owner;

    [SerializeField]
    public float boostDuration = 4.0f;

    //[SerializeField]
    //GameObject UI_feedback_prefab;

    [SerializeField]
    float deletionTime = 5.0f;


    private bool used = false;

    public bool IsUsed { get { return used; } }

    public delegate void OnDestructionDelegate();
    public event OnDestructionDelegate OnDestruction = null;

    [SerializeField]
    float coinProbability = 0.7f;

    [SerializeField]
    float quakeProbability = 0.1f;

    [SerializeField]
    float fireBallProbability = 0.2f;

    [SerializeField]
    float antiUnitFbChance = 0.5f;

    [SerializeField]
    float antiBuuldingFbChance = 0.5f;

    [SerializeField]
    int quakeDestrBuildingAfterNr = 3;

    [SerializeField]
    int quakeBuildingsDestrNr = 1;

    [SerializeField]
    float openTime = 0.5f;

    [SerializeField]
    Animator boxAnimator;

    [SerializeField]
    GameObject diamondObject;

    [SerializeField]
    GameObject earthquakeObject;

    [SerializeField]
    GameObject antiUnitFireBall;

    [SerializeField]
    float destructionTimeAfterOpen = 1.0f;

    PlayerGameData enemyData;
    Transform rndTarget = null;

#if TOUCH_INPUT
	public void PenetratingTouchEnd()
#else
    public void OnMouseUp()
#endif
    {
        if (used) return;
        //StartGlide();
        used = true;
        boxAnimator.SetBool("Open", true);

        float rng = Random.value;

        if (rng <= quakeProbability)
        {
            QuakeAction();
            Destroy(this.gameObject, destructionTimeAfterOpen);
        }
        else if(rng <= quakeProbability + fireBallProbability && (enemyData.units.Count > 0 || enemyData.buildings.Count > 1))
        {
            FBAction();
            Destroy(this.gameObject, destructionTimeAfterOpen);
        }
        else
        {
            CoinAction();
            Destroy(this.gameObject, destructionTimeAfterOpen);
        }
    }

    void Start()
    {
        enemyData = gameManager.playerData[(this.owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];
        //Destroy(this.gameObject,deletionTime);
    }

    void OnDestroy()
    {
        if (OnDestruction != null)
            OnDestruction();
    }

    void CoinAction()
    {
        diamondObject.SetActive(true);

        if (owner == PLAYERS.PLAYER1)
            gameManager.player1MoneyBoostTime = boostDuration;
        else
            gameManager.player2MoneyBoostTime = boostDuration;
    }

    void FBAction()
    {
        float rng = Random.value;
        if (rng <= antiUnitFbChance && enemyData.units.Count > 0)
        {
            rndTarget = enemyData.units[Random.Range(0, enemyData.units.Count)];
        }
        else
        {
            rndTarget = enemyData.buildings[Random.Range(0, enemyData.buildings.Count)].transform.parent;
        }
        if (!rndTarget)
            CoinAction();
        else
            StartCoroutine(FireBallAction());
    }

    IEnumerator FireBallAction()
    {
        yield return new WaitForSeconds(openTime);
        antiUnitFireBall.SetActive(true);
        antiUnitFireBall.GetComponent<FireBall>().target = rndTarget;
        antiUnitFireBall.transform.parent = null;
    }

    void QuakeAction()
    {
        earthquakeObject.SetActive(true);

        bool destroyEnemyBuilding = enemyData.buildings.Count > quakeDestrBuildingAfterNr;

        //destroy one building
        if (destroyEnemyBuilding)
            for (int i = 0; i < enemyData.tiles.Count && i < quakeBuildingsDestrNr; i++)
            {
                if (enemyData.tiles[i].CurrentEnergyBuilding)
                    enemyData.tiles[i].DestroyBuilding();
            }
        /*
		for (int i=0; i < data.tiles.Count - 1; ++i)
		{
			HexagonTile tile = data.tiles[Random.Range(i + 1, data.tiles.Count)];
            
			if(data.tiles[i] != tile)//testing
			data.tiles[i].SwapBuilding(tile);
           
        }

		//foreach(HexagonTile t in data.tiles)
       //     t.StartSwap();
       */
        //data.currentInputState = INPUT_STATES.FREE;
        //data.RefreshAllTilesHighlight();

        for (int i = 0; i < enemyData.tiles.Count - 1; ++i)
        {
            HexagonTile tile = enemyData.tiles[Random.Range(i + 1, enemyData.tiles.Count)];

            if (enemyData.tiles[i] != tile)//testing
                enemyData.tiles[i].SwapBuilding(tile);

        }
        foreach (HexagonTile t in enemyData.tiles)
            t.StartSwap();


        /*
        List<HexagonTile> tiles = new List<HexagonTile>(enemyData.tiles);
        HexagonTile tile1;
        HexagonTile tile2;
        while (tiles.Count > 1)
        {
            int rnd = Random.Range(0, tiles.Count);
            tile1 = tiles[rnd];
            tiles.RemoveAt(rnd);
            rnd = Random.Range(0, tiles.Count);
            tile2 = tiles[rnd];
            tiles.RemoveAt(rnd);

            tile1.SwapBuilding(tile2);

            tile1.StartSwap();
            tile2.StartSwap();
        }
        */
        enemyData.currentInputState = INPUT_STATES.FREE;
        enemyData.RefreshAllTilesHighlight();

        //shake own buildings too

        //PlayerGameData enemyData = gameManager.playerData[(this.owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];

        Camera.main.GetComponent<CameraShake>().Shake();
    }

    //debug
    void Update()
    {
        //Destroy(this.gameObject);

        deletionTime -= Time.deltaTime;
        if (deletionTime <= 0.0f && !used)
            Destroy(this.gameObject);
    }
}
