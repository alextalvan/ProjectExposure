using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInputManager : MonoBehaviour 
{
	public delegate void TouchBeginDelegate(Touch t);

	/// <summary>
	/// Callback for any touch beginning
	/// </summary>
	public event TouchBeginDelegate OnTouchBegin = null;

	/// <summary>
	/// Callback for any touch end
	/// </summary>
	public event TouchBeginDelegate OnTouchEnd = null;
//	public event TouchBeginDelegate OnTouchMoved = null;

	private static TouchInputManager _instance;
	public static TouchInputManager Singleton { get { return _instance; } }


	//used to keep track of the object each touch is locked to
	//null value means the touch is not locked to any object
	private Dictionary<int,GameObject> lockedObjects = new Dictionary<int, GameObject>();

	//used to keep track of the last 2D object under each touch
	private Dictionary<int,GameObject> focusedObjects = new Dictionary<int, GameObject>();


	void Update () 
	{
		HandleTouchInput();
			
	}

	void Awake()
	{
		_instance = this;
	}


	void HandleTouchInput()
	{
		int nbTouches = Input.touchCount;

		for (int i = 0; i < nbTouches; i++)
		{
			Touch touch = Input.GetTouch(i);
			TouchPhase phase = touch.phase;

			Collider2D col2d = Get2DColliderUnderTouch(touch);
			Collider   col3d = Get3DColliderUnderTouch(touch);


			GameObject targetObject = null;

			//2d colliders have priority over 3d ones
			if(col2d != null)
				targetObject = col2d.gameObject;
			else
				if(col3d !=null)
					targetObject = col3d.gameObject;

			switch(phase)
			{
				case TouchPhase.Began:

					//UIConsole.Log("<color=yellow>TouchInputManager: New touch (begin phase) detected</color>");

					InitializeNewTouch(touch);


					bool beginCondition2D = (targetObject != null) && CanInteractWithObject(touch,targetObject);


					if(beginCondition2D)
					{
						targetObject.SendMessage("TouchEnter",touch);
						focusedObjects[touch.fingerId] = targetObject;
					}

					if(OnTouchBegin != null)
						OnTouchBegin(touch);

					//UIConsole.Log("New touch detected at position " + touch.position + " , index " + touch.fingerId);
					break;
				case TouchPhase.Moved:
					
					GameObject oldFocusedObj = focusedObjects[touch.fingerId];


					//first check if we exited something
					bool exitCondition = oldFocusedObj != null && 
										 CanInteractWithObject(touch,oldFocusedObj) && 
										 (targetObject == null || oldFocusedObj != targetObject);

					if(exitCondition)
					{
						

						if(targetObject == null)
							focusedObjects[touch.fingerId] = null;
						//else
						//	focusedObjects2D[touch.fingerId] = col2d.gameObject;

						oldFocusedObj.SendMessage("TouchExit",touch);
					}

					oldFocusedObj = focusedObjects[touch.fingerId];


					bool enterCondition = (targetObject != null) && 
										  CanInteractWithObject(touch,targetObject) && 
										  (oldFocusedObj == null || oldFocusedObj != targetObject);

					if(enterCondition)
					{
						//update focused object at end
						focusedObjects[touch.fingerId] = targetObject;

						targetObject.SendMessage("TouchEnter",touch);
					}





					//touchEnter and touchExit overrides touchMove
					if(enterCondition || exitCondition)
						break;

					bool moveCondition = (oldFocusedObj !=null) &&
										 CanInteractWithObject(touch,oldFocusedObj);

					if(moveCondition)
					{
						focusedObjects[touch.fingerId].SendMessage("TouchMove",touch);
					}


					//UIConsole.Log("Touch index " + touch.fingerId + " has moved by " + touch.deltaPosition);
					break;
				case TouchPhase.Stationary:

					bool stayCondition = (targetObject != null) && 
										 CanInteractWithObject(touch,targetObject);

					if(stayCondition)
					{
						focusedObjects[touch.fingerId].SendMessage("TouchStay",touch);
					}

					//UIConsole.Log("Touch index " + touch.fingerId + " is stationary at position " + touch.position);
					break;
				case TouchPhase.Ended:

					//current object test
					if(targetObject!= null && CanInteractWithObject(touch,targetObject))
						targetObject.SendMessage("TouchEnd",touch);

					
					//focusedObjects2D[touch.fingerId] = null;

					if(OnTouchEnd != null)
						OnTouchEnd(touch);
					//UIConsole.Log("Touch index " + touch.fingerId + " ended at position " + touch.position);

					DisposeTouch(touch);
					break;
				case TouchPhase.Canceled:
					//UIConsole.Log("Touch index " + touch.fingerId + " cancelled");

					DisposeTouch(touch);
					break;
			}
		}
	}


	void InitializeNewTouch(Touch t)
	{
		lockedObjects[t.fingerId] = null;
		focusedObjects[t.fingerId] = null;
	}


	void DisposeTouch(Touch t)
	{
		lockedObjects.Remove(t.fingerId);
		focusedObjects.Remove(t.fingerId);
	}






	Collider2D Get2DColliderUnderTouch(Touch t)
	{
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(t.position.x,t.position.y,0));

		RaycastHit2D hitinfo = Physics2D.GetRayIntersection(ray);
		//RaycastHit2D hitinfo = Physics2D.Raycast(t.position,Vector2.zero);

		return hitinfo.collider;
	}

	Collider Get3DColliderUnderTouch(Touch t)
	{
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(t.position.x,t.position.y,0));

		RaycastHit hitinfo;
		if(Physics.Raycast(ray,out hitinfo))
			return hitinfo.collider;
		else
			return null;
	}


	/// <summary>
	/// Forces the touch to only send callbacks to this GameObject. Use UnlockTouchObject() to undo this.
	/// </summary>
	public void LockObject(Touch touch, GameObject target)
	{
		if(target == null)
			return;
		
		lockedObjects[touch.fingerId] = target;
	}

	/// <summary>
	/// If the touch is locked onto a specific GameObject, it becomes unlocked.
	/// </summary>
	public void UnlockObject(Touch touch)
	{
		lockedObjects[touch.fingerId] = null;
	}


	/// <summary>
	/// Determines whether the touch's lock state allows interaction with the gameobject
	/// </summary>
	bool CanInteractWithObject(Touch touch, GameObject target)
	{
		if(lockedObjects[touch.fingerId] == null)
			return true;
		else
			return lockedObjects[touch.fingerId] == target;
	}
		

	public GameObject GetLockedObject(Touch t)
	{
		if(!lockedObjects.ContainsKey(t.fingerId))
			return null;

		return lockedObjects[t.fingerId];
	}

	public void ForceFocusedObject(Touch t, GameObject target)
	{
		focusedObjects[t.fingerId] = target;
	}


//	void OnGUI()
//	{
//		string debugText = "";
//
//		foreach(KeyValuePair<int,GameObject> kv in focusedObjects)
//		{
//			debugText += "Touch # " + kv.Key.ToString() + " focused object is: " + kv.Value.name + "\n";
//		}
//
//		GUI.Box(new Rect(0,0,512,256),debugText);
//	}
}
