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


//[RequireComponent(typeof(Collider2D))]
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
	protected GameObject highlight = null;

	void OnDestroy()
	{

		//if a card is destroyed while the player is in the middle of using it, handle it proeprly
		foreach(PLAYERS p in System.Enum.GetValues(typeof(PLAYERS)))
		{
			PlayerGameData pdata = gameManager.playerData[p];
			if(pdata.currentSelectedCard == this)
			{
				pdata.currentInputState = INPUT_STATES.FREE;
				pdata.currentSelectedCard = null;
				pdata.RefreshAllTilesHighlight();
				break;
			}
		}

		if(OnDestruction!=null)
			OnDestruction();

		//UIConsole.LogWithRandomColor("destroyed");

		//transform.wo
	}

	protected virtual void Start()
	{
		if(highlight)
			highlight.SetActive(false);

		//Destroy(this.gameObject,deletionTime);
	}


	public virtual bool CalculatePlayCondition()
	{
		return false;
	}

	public virtual void DoCardEffect()
	{
		
	}

#if TOUCH_INPUT
	public virtual void TouchEnd()
#else
    public virtual void OnMouseUp()
	#endif
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
