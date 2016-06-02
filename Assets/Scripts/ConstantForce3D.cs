using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ConstantForce3D : MonoBehaviour {

	[SerializeField]
	Vector3 force;

	[SerializeField]
	Vector3 torque;

	Rigidbody _rigid;

	void Start()
	{
		_rigid = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if(_rigid.isKinematic)
			return;

		_rigid.AddForce(force);
		_rigid.AddTorque(torque);
	}
}
