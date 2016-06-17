using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class CoinPickup : GameManagerSearcher {

	public PLAYERS owner;

	[SerializeField]
	public float valueAwarded = 1.0f;

	//[SerializeField]
	//GameObject UI_feedback_prefab;

	[SerializeField]
	float deletionTime = 5.0f;


    private bool used = false;

    public bool IsUsed { get { return used; } }

	public delegate void OnDestructionDelegate();
	public event OnDestructionDelegate OnDestruction = null;

#if TOUCH_INPUT
	public void PenetratingTouchEnd()
#else
    public void OnMouseUp()
	#endif
	{
        if (used) return;
		//StartGlide();
        used = true;
        //gameManager.SpawnUICoin(this.owner,transform.position,valueAwarded);
        
		if(owner == PLAYERS.PLAYER1)
			gameManager.Player1Money += this.valueAwarded;
		else
			gameManager.Player2Money += this.valueAwarded;
		Destroy(this.gameObject);
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

//	public void StartGlide()
//	{
//		gameManager.StartCoinGlide(this);
//		GetComponent<Collider>().enabled = false;
//		GetComponent<Rigidbody>().isKinematic = true;
//	}
}
