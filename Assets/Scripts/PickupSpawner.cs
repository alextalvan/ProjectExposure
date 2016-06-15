using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupSpawner : ObjectSpawner {

	[SerializeField]
	PLAYERS owner;

	List<ActionCard> cardList = new List<ActionCard>();

	// Use this for initialization
	void Start () 
	{
		foreach(GameObject obj in prefabs)
		{
			ActionCard cardComp = obj.GetComponent<ActionCard>();
			cardList.Add(cardComp);
			cardComp.Owner = this.owner;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	protected override void CalculateEligibleObjects ()
	{
		eligibleObjects.Clear();

		foreach(ActionCard card in cardList)
		{
			if(card.CalculatePlayCondition())
				eligibleObjects.Add(card.gameObject);
		}
	}
}
