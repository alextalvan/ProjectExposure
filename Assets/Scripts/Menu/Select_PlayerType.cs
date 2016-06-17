using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Select_PlayerType : MonoBehaviour {

	public Sprite newSprite;
	public Button button;

	public void ChangeSprite() 
	{
		button.image.sprite = newSprite;

	}

}