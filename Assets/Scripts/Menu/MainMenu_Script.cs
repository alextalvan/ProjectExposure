using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour {



	public void StartGame() 
	{
		SceneManager.LoadScene (1);

	}

	public void StopGame() 
	{
		SceneManager.LoadScene (0);

	}

}
