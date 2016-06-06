using UnityEngine;
using System.Collections;

public class SendInputUpwards : MonoBehaviour 
{
	#if TOUCH_INPUT
	void PenetratingTouchEnd()
	{
		if(transform.parent!=null)
			transform.parent.SendMessage("PenetratingTouchEnd");
	}
	#else
	void OnMouseUp()
	{
		if(transform.parent!=null)
			transform.parent.SendMessage("OnMouseUp");
	}
	#endif
}
