using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Select_PlayerType : MonoBehaviour {

	public Sprite playerSprite;
	public Sprite aiSprite;
	public Button button;

	public bool isSet = false;

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