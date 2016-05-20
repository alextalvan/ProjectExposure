using UnityEngine;
using System.Collections;

public enum CARD_TYPES
{
	BUILD_COAL,
	BUILD_OIL,
	BUILD_GAS,
	BUILD_WIND,
	BUILD_SOLAR,
	BUILD_BIOFUEL,
	BUILD_NUCLEAR,
	ZAP,
	WIND_GUST,
	SMOG,
	SWAMP,
	ICE,
	EARTHQUAKE

}


[RequireComponent(typeof(Collider2D))]
public abstract class Card : GameManagerSearcher 
{
	public delegate void CardDestructionDelegate();
	public event CardDestructionDelegate OnDestruction = null;

	[SerializeField]
	PLAYERS owner;

	public PLAYERS Owner { get { return owner; } set { owner = value; } }

	[SerializeField]
	CARD_TYPES cardType;

	public CARD_TYPES CardType { get { return cardType; } }

	[SerializeField]
	int moneyCost = 0;

	public int MoneyCost { get { return moneyCost; } }

	[SerializeField]
	float deletionTime = 15.0f;

	[SerializeField]
	GameObject highlight = null;

	void OnDestroy()
	{
		if(OnDestruction!=null)
			OnDestruction();
	}

	protected virtual void Start()
	{
		if(highlight)
			highlight.SetActive(false);

		Destroy(this.gameObject,deletionTime);
	}


	protected virtual bool CalculatePlayCondition()
	{
		return false;
	}

	protected virtual void DoCardEffect()
	{
		
	}

	protected virtual void OnMouseUp()
	{
		if(CalculatePlayCondition())
			DoCardEffect();

		gameManager.raycastedOn2DObject = true;
	}

	protected virtual void Update()
	{
		if(highlight)
			highlight.SetActive(CalculatePlayCondition());
	}

	//utility function for checking if the card can be afforded
	protected bool CheckMoneyCost()
	{
		return ((this.Owner == PLAYERS.PLAYER1) ? gameManager.Player1Money : gameManager.Player2Money) >= this.MoneyCost;
	}
}
