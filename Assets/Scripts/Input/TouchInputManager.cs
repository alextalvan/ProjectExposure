using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ApplicationTimeOut))]
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

	//used to keep track of the last object under each touch
	private Dictionary<int,GameObject> focusedObjects = new Dictionary<int, GameObject>();
	//the same thing, but for penetrating callbacks
	private Dictionary<int,List<GameObject>> focusedPenetratedObjects = new Dictionary<int, List<GameObject>>();
    bool half1Blocked = false;
    bool half2Blocked = false;

	ApplicationTimeOut appTimeOut;

	void Update () 
	{
		HandleTouchInput();
	}

	void Awake()
	{
		_instance = this;
		appTimeOut = GetComponent<ApplicationTimeOut>();
	}


	void HandleTouchInput()
	{
		int nbTouches = Input.touchCount;

		if(nbTouches > 0)
			appTimeOut.Reset();

		for (int i = 0; i < nbTouches; i++)
		{
			Touch touch = Input.GetTouch(i);

            if (half1Blocked && touch.position.x < Screen.width / 2) continue;
            if (half2Blocked && touch.position.x > Screen.width / 2) continue;

            TouchPhase phase = touch.phase;

			Collider2D col2d = Get2DColliderUnderTouch(touch);
			Collider   col3d = Get3DColliderUnderTouch(touch);
			RaycastHit[] allCol3D = GetAll3DCollidersUnderTouch(touch);
			List<GameObject> newPenetratedObjectsList = new List<GameObject>();
			foreach(RaycastHit rhit in allCol3D) newPenetratedObjectsList.Add(rhit.collider.gameObject);

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


					bool beginCondition = (targetObject != null) && CanInteractWithObject(touch,targetObject);


					if(beginCondition)
					{
						targetObject.SendMessageUpwards("TouchEnter",touch);
						focusedObjects[touch.fingerId] = targetObject;
					}


					//penetrating touch callbacks
					foreach(RaycastHit rhit in allCol3D)
					{
						GameObject tObj = rhit.collider.gameObject;
						if(CanInteractWithObject(touch,tObj))
						{
							tObj.SendMessageUpwards("PenetratingTouchEnter",touch);
						}
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

						oldFocusedObj.SendMessageUpwards("TouchExit",touch);
					}

					oldFocusedObj = focusedObjects[touch.fingerId];

					//penetrating exit
					List<GameObject> oldPenetratedObjects = focusedPenetratedObjects[touch.fingerId];

					foreach(GameObject oldPenObj in oldPenetratedObjects)
					{
						if(CanInteractWithObject(touch,oldPenObj) && !newPenetratedObjectsList.Contains(oldPenObj))
							oldPenObj.SendMessageUpwards("PenetratingTouchExit",touch);
					}





					bool enterCondition = (targetObject != null) && 
										  CanInteractWithObject(touch,targetObject) && 
										  (oldFocusedObj == null || oldFocusedObj != targetObject);

					if(enterCondition)
					{
						//update focused object at end
						focusedObjects[touch.fingerId] = targetObject;

						targetObject.SendMessageUpwards("TouchEnter",touch);
					}



					//penetrating enter from movement
					foreach(GameObject newPenObj in newPenetratedObjectsList)
					{
						if(CanInteractWithObject(touch,newPenObj) && !oldPenetratedObjects.Contains(newPenObj))
							newPenObj.SendMessageUpwards("PenetratingTouchEnter",touch);
					}




					//touchEnter and touchExit overrides touchMove
					if(enterCondition || exitCondition)
					{
						focusedPenetratedObjects[touch.fingerId] = newPenetratedObjectsList;
						break;
					}

					bool moveCondition = (oldFocusedObj !=null) &&
										 CanInteractWithObject(touch,oldFocusedObj);

					if(moveCondition)
					{
						focusedObjects[touch.fingerId].SendMessageUpwards("TouchMove",touch);
					}


					//penetrating move
					foreach(GameObject newPenObj in newPenetratedObjectsList)
					{
						if(CanInteractWithObject(touch,newPenObj))
							newPenObj.SendMessageUpwards("PenetratingTouchMove",touch);
					}

					focusedPenetratedObjects[touch.fingerId] = newPenetratedObjectsList;


					//UIConsole.Log("Touch index " + touch.fingerId + " has moved by " + touch.deltaPosition);
					break;
				case TouchPhase.Stationary:

					bool stayCondition = (targetObject != null) && 
										 CanInteractWithObject(touch,targetObject);

					if(stayCondition)
					{
						focusedObjects[touch.fingerId].SendMessageUpwards("TouchStay",touch);
					}


					//penetrating stay
					foreach(GameObject newPenObj in newPenetratedObjectsList)
					{
						if(CanInteractWithObject(touch,newPenObj))
							newPenObj.SendMessageUpwards("PenetratingTouchStay",touch);
					}

					focusedPenetratedObjects[touch.fingerId] = newPenetratedObjectsList;

					//UIConsole.Log("Touch index " + touch.fingerId + " is stationary at position " + touch.position);
					break;
				case TouchPhase.Ended:

					//current object test
					if(targetObject!= null && CanInteractWithObject(touch,targetObject))
						targetObject.SendMessageUpwards("TouchEnd",touch);


					//penetrating stay
					foreach(GameObject newPenObj in newPenetratedObjectsList)
					{
						if(CanInteractWithObject(touch,newPenObj))
							newPenObj.SendMessageUpwards("PenetratingTouchEnd",touch);
					}
						
					
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
		focusedPenetratedObjects[t.fingerId] = new List<GameObject>();
	}


	void DisposeTouch(Touch t)
	{
		lockedObjects.Remove(t.fingerId);
		focusedObjects.Remove(t.fingerId);
		focusedPenetratedObjects.Remove(t.fingerId);
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

	RaycastHit[] GetAll3DCollidersUnderTouch(Touch t)
	{
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(t.position.x,t.position.y,0));

		RaycastHit[] hitinfos = Physics.RaycastAll(ray);

		return hitinfos;
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

    public void BlockHalf(int index)
    {
        if (index == 0)
            half1Blocked = true;
        else
            half2Blocked = true;
    }

    public void EnableHalf(int index)
    {
        if (index == 0)
            half1Blocked = false;
        else
            half2Blocked = false;
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
