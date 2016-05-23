using UnityEngine;
using System.Collections;

public class SendInputUpwards : MonoBehaviour {


	void OnMouseUp()
	{


		if(transform.parent!=null)
			transform.parent.SendMessage("OnMouseUp");
	}
}
