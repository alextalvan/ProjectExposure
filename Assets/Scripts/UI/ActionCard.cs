using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public abstract class ActionCard : MonoBehaviour 
{
	public delegate void CardDestructionDelegate();
	public event CardDestructionDelegate OnDestruction = null;

	[SerializeField]
	PLAYERS owner;

	public PLAYERS Owner { get { return owner; } set { owner = value; } }

	void OnDestroy()
	{
		if(OnDestruction!=null)
			OnDestruction();
	}
}
