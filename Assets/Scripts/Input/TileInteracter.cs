using UnityEngine;
using System.Collections;

public class TileInteracter : MonoBehaviour 
{
	void Start()
	{
		TouchInputManager.Singleton.OnTouchBegin += DebugColor;
	}

	void DebugColor()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hitinfo;

		if(Physics.Raycast(ray,out hitinfo))
		{

			Renderer[] rends = hitinfo.collider.GetComponentsInChildren<Renderer>();

			foreach(Renderer r in rends)
				r.material.color = Color.blue;
		}
	}
}
