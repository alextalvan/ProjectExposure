using UnityEngine;
using System.Collections.Generic;

public class EnableAfterDuration : MonoBehaviour {

	[SerializeField]
	List<GameObject> targets = new List<GameObject>();

	[SerializeField]
	float duration = 60.0f;

	bool finished = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(finished) return;

		duration -= Time.deltaTime;
		if(duration <= 0.0f)
		{
			finished  =true;
			foreach(GameObject obj in targets)
				obj.SetActive(true);
		}
	}
}
