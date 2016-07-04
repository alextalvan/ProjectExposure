using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

    private bool player1IsAI = false;
    private bool player2IsAI = false;

    public bool Player1AI { set { player1IsAI = value; } get { return player1IsAI; } }
    public bool Player2AI { set { player2IsAI = value; } get { return player2IsAI; } }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
