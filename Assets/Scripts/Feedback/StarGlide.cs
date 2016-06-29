using UnityEngine;
using System.Collections;

public class StarGlide : MonoBehaviour {

	[SerializeField]
	float interpolationSpeed = 0.1f;

	[SerializeField]
	Vector3 targetPosition = Vector3.zero;
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Vector3.Lerp(transform.position,targetPosition,interpolationSpeed);

		if(Vector3.Distance(transform.position,targetPosition) < 0.1f)
			Destroy(this.gameObject);
	}
}
