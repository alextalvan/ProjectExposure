using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ConstantRigidbody2DForce : MonoBehaviour {

	[SerializeField]
	Vector2 forceValue = Vector2.zero;

	//[SerializeField]
	Rigidbody2D _rigid;

	void Start()
	{
		_rigid = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		_rigid.velocity = forceValue;
	}
}
