﻿using UnityEngine;
using System.Collections;

public class TouchTest2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void TouchEnter(Touch t)
//	{
//		Renderer[] rends = GetComponentsInChildren<Renderer>();
//		foreach(Renderer r in rends)
//		{
//			r.material.color = Color.green;
//		}
//	}

	#if TOUCH_INPUT
	void TouchEnd()
	#else
	void OnMouseUp()
	#endif
	{
		//Debug.Log("test");
	}
}
