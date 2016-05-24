using UnityEngine;
using System.Collections;

public class TemporaryBlink : MonoBehaviour 
{
	//the target gameobject that gets toggled on and off
	[SerializeField]
	GameObject target;

	//the interval at which it switches from on to off
	[SerializeField]
	float blinkInterval = 0.75f;

	//internal members
	float totalTimer = -1.0f;
	float blinkTimer;
	bool objectIsActive = true;


	public void Begin(float duration = 5.0f)
	{
		totalTimer = duration;
		blinkTimer = blinkInterval;
		objectIsActive = false;
		target.SetActive(false);
	}

	void Update()
	{
		totalTimer -= Time.deltaTime;
		blinkTimer -= Time.deltaTime;

		if(totalTimer <= 0.0f)
		{
			target.SetActive(true);
			return;
		}

		if(blinkTimer <= 0.0f)
		{
			blinkTimer = blinkInterval;
			objectIsActive = !objectIsActive;
			target.SetActive(objectIsActive);
		}

	}
}
