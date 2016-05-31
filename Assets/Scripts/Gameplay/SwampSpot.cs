using UnityEngine;
using System.Collections;

public class SwampSpot : MonoBehaviour 
{
	float uptimer = 0.0f;

	public bool IsRunning { get { return uptimer > 0.0f; } }

	[SerializeField]
	TemporaryBlink tempBlink;

	[SerializeField]
	int tapCountForUndo = 1;
	int currentTapCount;

    bool used = false;

	void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<UnitAI>())
        {
            other.GetComponent<Collider>().isTrigger = true;
            Destroy(other.gameObject, 3f);
            used = true;
        }
		//Destroy(other.gameObject);
	}

	public void ToggleOn (float duration = 10.0f)
	{
		uptimer = duration;
		this.gameObject.SetActive(true);
		tempBlink.Begin(duration);
		currentTapCount = 0;
	}

	public void ToggleOff()
	{
        used = false;
        uptimer = -1.0f;
		this.gameObject.SetActive(false);
	}

	void Update()
	{
        if (used)
        {
            uptimer -= Time.deltaTime;

            if (uptimer <= 0.0f)
            {
                ToggleOff();
            }
        }
	}

	#if TOUCH_INPUT
	void PenetratingTouchEnd()
	#else
	void OnMouseUp()
	#endif
	{
		currentTapCount++;

		if(currentTapCount == tapCountForUndo)
			ToggleOff();
	}
		

}
