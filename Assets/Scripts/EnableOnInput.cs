using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnableOnInput : MonoBehaviour {

	[SerializeField]
	List<GameObject> targets = new List<GameObject>();

	[SerializeField]
	bool initiallyEnabled = true;

	bool objectsEnabled = true;

	[SerializeField]
	KeyCode inputKey = KeyCode.Alpha1;

	void Awake()
	{
		//foreach(GameObject g in targets)
		//	g.SetActive(initiallyEnabled);

		objectsEnabled = initiallyEnabled;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyUp(inputKey))
		{
			objectsEnabled = !objectsEnabled;

			foreach(GameObject g in targets)
				g.SetActive(objectsEnabled);
		}
	}
}
