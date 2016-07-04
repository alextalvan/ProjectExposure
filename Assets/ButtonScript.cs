using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    [SerializeField]
    PLAYERS player = PLAYERS.PLAYER1;
    [SerializeField]
    bool ai = false;
    [SerializeField]
    GameObject glow;
    [SerializeField]
    GameObject fellowButtonGlow;
    [SerializeField]
    GameSettings gameSettings;

    // Use this for initialization
    void Start () {
        if (glow.activeSelf)
            SetPlayer();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void SetPlayer()
    {
        if (player == PLAYERS.PLAYER1)
            gameSettings.Player1AI = ai;
        else
            gameSettings.Player2AI = ai;
    }

    public void ActivateGlow()
    {
        glow.SetActive(true);
        fellowButtonGlow.SetActive(false);
    }
}
