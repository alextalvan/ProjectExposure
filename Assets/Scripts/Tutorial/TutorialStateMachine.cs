using UnityEngine;
using System.Collections;

public class TutorialStateMachine : MonoBehaviour {

	enum TUTORIAL_STATES
	{
		start,
		wait_touch_coal_card
	}

	TUTORIAL_STATES currentState = TUTORIAL_STATES.start;

	delegate void TimedActionDelegate();


	[SerializeField]
	CardGlide startCoalCard;

	// Use this for initialization
	void Start () 
	{
		SetState(TUTORIAL_STATES.start);
	}

	void SetState(TUTORIAL_STATES s)
	{
		switch (s)
		{
			case TUTORIAL_STATES.start:
				RunDelayedFunction(5.0f, () => { SetState(TUTORIAL_STATES.wait_touch_coal_card); } );
				return;

			case TUTORIAL_STATES.wait_touch_coal_card:
				return;
		}
	}























	//to save writing time
	void RunDelayedFunction(float delay,TimedActionDelegate func)
	{
		StartCoroutine(DelayedFunctionCall(func,delay));
	}


	IEnumerator DelayedFunctionCall(TimedActionDelegate func, float delay)
	{
		if(delay < 0.0f)
			delay = 0.0f;
		yield return new WaitForSeconds(delay);
		if(func!=null)
			func();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
