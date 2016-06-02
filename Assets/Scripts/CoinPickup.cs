using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CardGlide),typeof(Collider),typeof(Rigidbody))]
public class CoinPickup : GameManagerSearcher {

	public PLAYERS owner;

	[SerializeField]
	public int valueAwarded;

	//[SerializeField]
	//GameObject UI_feedback_prefab;

	[SerializeField]
	float deletionTime = 5.0f;

	public delegate void OnDestructionDelegate();
	public event OnDestructionDelegate OnDestruction = null;

	#if TOUCH_INPUT
	void PenetratingTouchEnd()
	#else
	void OnMouseUp()
	#endif
	{
		StartGlide();
		//gameManager.SpawnUICoin(this.owner,transform.position,valueAwarded);
		//Destroy(this.gameObject);
	}

	void Start()
	{
		Destroy(this.gameObject,deletionTime);
	}

	void OnDestroy()
	{
		if(OnDestruction != null)
			OnDestruction();
	}

	public void StartGlide()
	{
		gameManager.StartCoinGlide(this);
		GetComponent<Collider>().enabled = false;
		GetComponent<Rigidbody>().isKinematic = true;
	}
}
