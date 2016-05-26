using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Rigidbody2D))]
public class ConstantRigidbody2DForce : MonoBehaviour {

	//[SerializeField]
	Rigidbody2D _rigid;

	bool collided = false;

	void Start()
	{
		_rigid = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		//if(!collided)
			//_rigid.velocity = forceValue;
		//else
		{
			//if(_rigid!=null && _rigid.velocity.magnitude < 0.5f)
			//	Destroy(_rigid);
		}
	}

	void OnCollisionEnter2D()
	{
		if(!collided)
		{
			Destroy(_rigid,0.25f);
			collided = true;
		}
	}
		
}
