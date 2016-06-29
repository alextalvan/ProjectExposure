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
        //Destroy(GameObject.Find("GameSettings"));
		SceneManager.LoadScene (0);

	}

}
