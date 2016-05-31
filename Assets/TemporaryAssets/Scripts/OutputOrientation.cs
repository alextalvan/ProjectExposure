using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class OutputOrientation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnEnable () 
	{
		Debug.Log(transform.up);
	}
}
