using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Arguments))]
public class DBconnection : MonoBehaviour {
	private Arguments argumentsScript;
	private string connectionURL;
	private string scoreURL = "insertScore.php?";

	void Awake() {
		argumentsScript = GetComponent<Arguments>();
	}
	void Start() {
		connectionURL = argumentsScript.getConURL();
	}

	public void SendScore(int score)
	{
		StartCoroutine(UploadScore(argumentsScript.getUserID(),argumentsScript.getGameID(),score));
	}

	public IEnumerator UploadScore(int userID, int gameID, int score) 
	{
		string full_url = connectionURL + scoreURL + "userID=" + userID + "&gameID=" + gameID + "&score=" + score;
		WWW post = new WWW(full_url);
		yield return post;
		//Application.Quit();
	}
}
