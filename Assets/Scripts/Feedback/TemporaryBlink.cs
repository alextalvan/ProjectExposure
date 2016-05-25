using UnityEngine;
using System.Collections;

public class TemporaryBlink : MonoBehaviour 
{
	//the interval at which it switches from on to off
	[SerializeField]
	float blinkInterval = 0.25f;

	//internal members
	float totalTimer = -1.0f;
	float blinkTimer;
	bool objectIsVisible = true;


	[SerializeField]
	GameObject _targetObject;

	public void Begin(float duration = 5.0f)
	{
		totalTimer = duration;
		blinkTimer = blinkInterval;
		objectIsVisible = true;
		_targetObject.SetActive(true);
	}

	public void Stop()
	{
		totalTimer = -1.0f;
	}

	void Update()
	{
		totalTimer -= Time.deltaTime;
		blinkTimer -= Time.deltaTime;

		if(totalTimer <= 0.0f)
		{
			_targetObject.SetActive(true);
			return;
		}

		if(blinkTimer <= 0.0f)
		{
			blinkTimer = blinkInterval;
			objectIsVisible = !objectIsVisible;
			_targetObject.SetActive(objectIsVisible);
		}

	}
}
