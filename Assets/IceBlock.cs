using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IceBlock : MonoBehaviour 
{
	[SerializeField]
	float shardLifetime = 2.0f;


	public void Shatter()
	{
		foreach(Transform tr in this.transform)
		{
			Rigidbody rigid = tr.GetComponent<Rigidbody>();
			rigid.isKinematic = false;
			rigid.AddRelativeForce(rigid.transform.localPosition.normalized * 500.0f);
			rigid.AddRelativeTorque(Random.insideUnitSphere * 500.0f);
			tr.SetParent(null);
			Destroy(tr.gameObject,shardLifetime);
		}

		//Destroy(this.gameObject);
	}

//	#if TOUCH_INPUT
//	void PenetratingTouchEnd()
//	#else
//	void OnMouseUp()
//	#endif
//	{
//		Shatter();
//	}

}
