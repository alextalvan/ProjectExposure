using UnityEngine;
using System.Collections;

public class SwampSpot : MonoBehaviour 
{
	float uptimer = 0.0f;

	public bool IsRunning { get { return uptimer > 0.0f; } }

	[SerializeField]
	TemporaryBlink tempBlink;

	void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<UnitAI>())
			Destroy(other.gameObject);
	}
		

	public void ToggleOn (float duration = 10.0f)
	{
		uptimer = duration;
		this.gameObject.SetActive(true);
		tempBlink.Begin(duration);
	}

	public void ToggleOff()
	{
		uptimer = -1.0f;
		this.gameObject.SetActive(false);
	}


	void Update()
	{
		uptimer -= Time.deltaTime;

		if(uptimer <= 0.0f)
			this.gameObject.SetActive(false);
	}

	#if TOUCH_INPUT
	void TouchEnd()
	#else
	void OnMouseUp()
	#endif
	{
		ToggleOff();
	}
		

}
