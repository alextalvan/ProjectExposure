using UnityEngine;
using System.Collections;

public class SendInputUpwards : MonoBehaviour {


	#if TOUCH_INPUT
	void TouchEnd()
	#else
	void OnMouseUp()
	#endif
	{


		if(transform.parent!=null)
			transform.parent.SendMessage("OnMouseUp");
	}
}
