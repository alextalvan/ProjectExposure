using UnityEngine;
using System.Collections;

public class AIPlayer : MonoBehaviour {

    [SerializeField]
    PLAYERS playingAs;

    [SerializeField]
    Transform actionCardsHolder;
    [SerializeField]
    Transform greenBuildingCardsHolder;
    [SerializeField]
    Transform fossilBuildingCardsHolder;

    GameManager gm;
    PlayerGameData playerData;

	// Use this for initialization
	void Start () {
        gm = GetComponent<GameManager>();
        playerData = gm.playerData[playingAs];
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
