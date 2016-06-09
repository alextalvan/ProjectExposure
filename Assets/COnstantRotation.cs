using UnityEngine;
using System.Collections;

public class COnstantRotation : MonoBehaviour {


	[SerializeField]
	Vector3 rotation;

	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(rotation);
	}
}
