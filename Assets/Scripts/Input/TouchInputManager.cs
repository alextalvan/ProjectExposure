using UnityEngine;
using System.Collections;

public class TouchInputManager : MonoBehaviour 
{
	public delegate void TouchBeginDelegate();
	public event TouchBeginDelegate OnTouchBegin = null;

	private static TouchInputManager _instance;
	public static TouchInputManager Singleton { get { return _instance; } }

	void Update () 
	{
		int nbTouches = Input.touchCount;

		if(nbTouches > 0)
		{
			for (int i = 0; i < nbTouches; i++)
			{
				Touch touch = Input.GetTouch(i);

				TouchPhase phase = touch.phase;

				switch(phase)
				{
					case TouchPhase.Began:
						
						if(OnTouchBegin != null)
							OnTouchBegin();
						
						//UIConsole.Log("New touch detected at position " + touch.position + " , index " + touch.fingerId);
						break;
					case TouchPhase.Moved:
						//UIConsole.Log("Touch index " + touch.fingerId + " has moved by " + touch.deltaPosition);
						break;
					case TouchPhase.Stationary:
						//UIConsole.Log("Touch index " + touch.fingerId + " is stationary at position " + touch.position);
						break;
					case TouchPhase.Ended:
						//UIConsole.Log("Touch index " + touch.fingerId + " ended at position " + touch.position);
						break;
					case TouchPhase.Canceled:
						//UIConsole.Log("Touch index " + touch.fingerId + " cancelled");
						break;
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.Space))
			Test();
	}

	void Start()
	{
		_instance = this;
	}

	public void Test()
	{
		UIConsole.Log("test");
	}
}
