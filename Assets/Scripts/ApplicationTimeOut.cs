using UnityEngine;
using System.Collections;

public class ApplicationTimeOut : MonoBehaviour {

	[SerializeField]
	float timeOutDuration = 300.0f;

	[SerializeField]
	float currentTimer = 0.0f;

	// Update is called once per frame
	void Update () {
		currentTimer += Time.deltaTime;
		if(currentTimer >= timeOutDuration)
			Application.Quit();
	}

	public void Reset()
	{
		currentTimer = 0.0f;
	}
}
