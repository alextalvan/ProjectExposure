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

	void OnDestroy()
	{
		if(OnDestruction!=null)
			OnDestruction();
	}
}
