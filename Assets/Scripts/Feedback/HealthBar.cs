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
		if(targetScale < 0.0f)
        {
            targetScale = 0.0f;
        }

		Vector3 scale = barObject.localScale;
		scale.x = Mathf.Lerp(scale.x,targetScale,interpolationSpeed);
		barObject.localScale = scale;
        if (barObject.localScale.x <= 0.01f)
        {
            gameObject.SetActive(false);
        }
	}

	public void SetLength(float normalizedLength)
	{
		targetScale = normalizedLength;
	}
}
