using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class CardPurchaseButton : MonoBehaviour 
{
	[SerializeField]
	PLAYERS owner;

	[SerializeField]
	CardHolderGroup holderGroup;


	[SerializeField]
	NeutralCardSpawner spawner;


	#if TOUCH_INPUT
	void TouchEnd()
	#else
	public void OnMouseUp()
	#endif
	{
		spawner.BuyCardAttempt(owner,holderGroup);
	}
}
