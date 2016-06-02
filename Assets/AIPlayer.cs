using UnityEngine;
using System.Collections;

public class AIPlayer : MonoBehaviour {

    [SerializeField]
    PLAYERS playingAs;
    GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}


}
