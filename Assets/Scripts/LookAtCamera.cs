using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour 
{
	[SerializeField]
	bool onlyAtBeginning = false;

	void Start()
	{
		transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward,Vector3.up);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(onlyAtBeginning)
			return;

		transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward,Vector3.up);
	}
}
