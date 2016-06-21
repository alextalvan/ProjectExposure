using UnityEngine;
using System.Collections;

public class CrateContent : MonoBehaviour {

	// Use this for initialization
	public void ActivateObject () {
		gameObject.SetActive (true);
	
	}

	public void TurnOffObject () {
		gameObject.SetActive (false);

	}

}
