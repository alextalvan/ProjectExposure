using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour 
{

	[SerializeField]
	Transform barObject;

	//[SerializeField]
	float interpolationSpeed = 0.1f;

	float targetScale = 1.0f;


	
	// Update is called once per frame
	void Update () 
	{
		Vector3 scale = barObject.localScale;
		scale.x = Mathf.Lerp(scale.x,targetScale,interpolationSpeed);
		barObject.localScale = scale;
	}

	public void SetLength(float normalizedLength)
	{
		targetScale = normalizedLength;
	}
}
