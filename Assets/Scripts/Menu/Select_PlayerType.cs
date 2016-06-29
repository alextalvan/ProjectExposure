using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Select_PlayerType : MonoBehaviour {

    [SerializeField]
    int playerID = 1;

	public Sprite playerSprite;
	public Sprite aiSprite;
	public Button button;

	public bool isSet = false;

    [SerializeField]
    GameSettings gameSettings;

	public enum MenuPlayerPickState
	{
		player,
		ai,
		none
	}

	public MenuPlayerPickState currentState = MenuPlayerPickState.none;

	public void ChangeSprite() 
	{
		if(currentState == MenuPlayerPickState.ai)
			button.image.sprite = aiSprite;


		if(currentState == MenuPlayerPickState.player)
			button.image.sprite = playerSprite;


		isSet = true;



	}

	public void ChangeState(MenuPlayerPickState s)
	{
		currentState = s;
        if (playerID == 1)
        {
            if (currentState == MenuPlayerPickState.ai)
            {
                gameSettings.SetPlayer1AI = true;
            }
            else
            {
                gameSettings.SetPlayer1AI = false;
            }
        }
        else
        {
            if (currentState == MenuPlayerPickState.ai)
            {
                gameSettings.SetPlayer2AI = true;
            }
            else
            {
                gameSettings.SetPlayer2AI = false;
            }
        }
    }

	public void SetAI()
	{
		ChangeState (MenuPlayerPickState.ai);

	}

	public void SetPlayer()
	{
		ChangeState (MenuPlayerPickState.player);
	}

}