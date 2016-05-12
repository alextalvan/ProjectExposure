using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class Image_Manipulator : MonoBehaviour 
{

	private Vector3 screenPoint = Vector3.zero;
	private Vector3 offset = Vector3.zero;

	void OnMouseDown() {

		//GetComponent<Renderer>().material.color = Color.green;
		//Debug.Log(Camera.main);
		//offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		//GetComponent<Renderer>().material.color = Color.green;
		//GetComponent<Image>().material.color = Color.white;
		//GetComponent<Image>().color = Color.green;
	}

	void OnMouseDrag()
	{
		//GetComponent<Renderer>().material.color = Color.white;
		//Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		//Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		//transform.position = curPosition;
	}

	void TouchEnter(Touch t)
	{
		//UIConsole.Log("<color=green>TouchEnter</color>");

		TouchInputManager.Singleton.LockObject(t,this.gameObject);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 0));
		GetComponent<Rigidbody2D>().isKinematic = true;
		gameObject.layer = 9;

		TouchInputManager.Singleton.OnTouchEnd += this.GlobalTouchEnd;
	}

	void TouchExit(Touch t)
	{
		//UIConsole.Log("<color=red>TouchExit</color>");
		//TouchInputManager.Singleton.UnlockObject(t);
		//GetComponent<Rigidbody2D>().isKinematic = false;
		//gameObject.layer = 5;
		Vector3 curScreenPoint = new Vector3(t.position.x, t.position.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
		TouchInputManager.Singleton.ForceFocusedObject(t,this.gameObject);
	}

//	void TouchEnd(Touch t)
//	{
//		//UIConsole.Log("<color=cyan>TouchEnd</color>");
//		TouchInputManager.Singleton.UnlockObject(t);
//		GetComponent<Rigidbody2D>().isKinematic = false;
//		gameObject.layer = 5;
//	}

	void TouchMove(Touch t)
	{
		//UIConsole.Log("<color=magenta>TouchMove</color>");
		Vector3 curScreenPoint = new Vector3(t.position.x, t.position.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}

	void TouchStay(Touch t)
	{
		//UIConsole.Log("<color=white>TouchStay</color>");
		Vector3 curScreenPoint = new Vector3(t.position.x, t.position.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}

	void GlobalTouchEnd(Touch t)
	{
		if(this.gameObject == TouchInputManager.Singleton.GetLockedObject(t))
		{
			TouchInputManager.Singleton.UnlockObject(t);
			GetComponent<Rigidbody2D>().isKinematic = false;
			gameObject.layer = 5;
			TouchInputManager.Singleton.OnTouchEnd -= this.GlobalTouchEnd;
		}
	}

		
}
