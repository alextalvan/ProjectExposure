using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class CoinPickup : GameManagerSearcher {

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
	float coinProbability = 0.75f;

	[SerializeField]
	float quakeProbability = 0.25f;

	//[SerializeField]
	float nukeProbability = 0f;//0.051f;

	[SerializeField]
	Animator boxAnimator;

	[SerializeField]
	GameObject diamondObject;

	[SerializeField]
	GameObject earthquakeObject;

	[SerializeField]
	GameObject nuclearObject;

	[SerializeField]
	float destructionTimeAfterOpen = 1.0f;

#if TOUCH_INPUT
	public void PenetratingTouchEnd()
#else
    public void OnMouseUp()
	#endif
	{
        if (used) return;
		//StartGlide();
        used = true;
		boxAnimator.SetBool("Open",true);
       
		float rng = Random.value;

//		if(rng <= nukeProbability)
//		{
//			NukeAction();
//			Destroy(this.gameObject);
//			return;
//		}

		if(rng <= quakeProbability + nukeProbability)
		{
			QuakeAction();
			Destroy(this.gameObject, destructionTimeAfterOpen);
			return;
		}

		if(rng <= coinProbability + nukeProbability + quakeProbability)
		{
			CoinAction();
			Destroy(this.gameObject, destructionTimeAfterOpen);
			return;
		}


			
    }

	void Start()
	{
		//Destroy(this.gameObject,deletionTime);
	}

	void OnDestroy()
	{
		if(OnDestruction != null)
			OnDestruction();
    }

	void CoinAction()
	{
		diamondObject.SetActive(true);

		if(owner == PLAYERS.PLAYER1)
			gameManager.player1MoneyBoostTime = boostDuration;
		else
			gameManager.player2MoneyBoostTime = boostDuration;
	}

	void QuakeAction()
	{
		earthquakeObject.SetActive(true);

		PlayerGameData enemyData = gameManager.playerData[(this.owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];
        //List<HexagonTile> tiles = new List<HexagonTile>(enemyData.tiles);
        //HexagonTile tile1;
        //HexagonTile tile2;
        //while(tiles.Count > 1)
        //{
        //    int rnd = Random.Range(0, tiles.Count);
        //    tile1 = tiles[rnd];
        //    tiles.RemoveAt(rnd);
        //    rnd = Random.Range(0, tiles.Count);
        //    tile2 = tiles[rnd];
        //    tiles.RemoveAt(rnd);

        //    tile1.SwapBuilding(tile2);
        //    tile1.StartSwap();
        //    tile2.StartSwap();
        //}
        
        for (int i=0; i < enemyData.tiles.Count - 1; ++i)
		{
            HexagonTile tile = enemyData.tiles[Random.Range(i + 1, enemyData.tiles.Count)];
            
            enemyData.tiles[i].SwapBuilding(tile);
           
        }

        foreach(HexagonTile t in enemyData.tiles)
        {
            t.StartSwap();
        }

        Camera.main.GetComponent<CameraShake>().Shake();
		enemyData.currentInputState = INPUT_STATES.FREE;
		enemyData.RefreshAllTilesHighlight();
	}

	void NukeAction()
	{
		nuclearObject.SetActive(true);
		
	}

	//debug
	void Update()
	{
		if(Input.GetKeyUp(KeyCode.H))
		{
			QuakeAction();
			//Destroy(this.gameObject);
		}

		deletionTime -= Time.deltaTime;
		if(deletionTime<= 0.0f && !used)
			Destroy(this.gameObject);
	}
}
