using UnityEngine;
using System.Collections;
using UnityEngine.UI; // required when using UI elements in scripts

public class Interacable_Button : MonoBehaviour {

	public Select_PlayerType left;
	public Select_PlayerType right;


	void Update () 
	{
		// checks if the players are ready and if the start button is useable
		if (left.isSet && right.isSet) 
		{
			//allows the start button to be used
			GetComponent<Button>().interactable = true;
		}
	}
}