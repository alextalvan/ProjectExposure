﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardGlide : MonoBehaviour {

	[SerializeField]
	float interpolationSpeed = 0.1f;

	[SerializeField]
	float snapThreshold = 2.0f;

	Transform _target = null;
	bool gliding = false;

	//the script will toggle these components off while gliding and turn them back on after
	[SerializeField]
	List<Behaviour> toggleList = new List<Behaviour>();

	[SerializeField]
	bool toggleRigidBody2D = true;


	public void SetTarget(Transform target)
	{
		_target = target;
		gliding = true;
		foreach(Behaviour beh in toggleList)
			beh.enabled = false;

		if(toggleRigidBody2D)
			GetComponent<Rigidbody2D>().isKinematic = true;
	}


	
	void FixedUpdate()
	{
		if(gliding)
		{
			transform.position = Vector3.Lerp(transform.position,_target.position, interpolationSpeed);
			if((transform.position - _target.transform.position).magnitude <= snapThreshold)
			{
				gliding = false;

				foreach(Behaviour beh in toggleList)
					beh.enabled = true;

				if(toggleRigidBody2D)
					GetComponent<Rigidbody2D>().isKinematic = false;

				transform.position = _target.transform.position;
			}
		}
	}
}