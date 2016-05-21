using UnityEngine;
using System.Collections;

public class EnergyBuilding : GameManagerSearcher 
{
	PLAYERS owner;
	public PLAYERS Owner { get { return owner; } set { owner = value; } }

	[SerializeField]
	float maxlifeTime = 30.0f;

	[SerializeField]
	float lifeTimeLeft;

	public float MaxLifeTime { get { return maxlifeTime; } }
	public float CurrentLifeTimeLeft { get { return lifeTimeLeft; } }

	public delegate void BuildingDestructionDelegate();
	public event BuildingDestructionDelegate OnDestruction = null;

	void Start()
	{
		Destroy(this.gameObject,maxlifeTime);
		lifeTimeLeft = maxlifeTime;
	}

	void OnDestroy()
	{
		if(OnDestruction != null)
			OnDestruction();
	}

	void Update()
	{
		lifeTimeLeft -= Time.deltaTime;
	}

//	[SerializeField]
//	protected float currentPollution;
//
//	[SerializeField]
//	protected float maxPollution;
//
//	[SerializeField]
//	protected float currentEnergy;
//
//	[SerializeField]
//	protected float maxEnergy;
//
//	protected abstract void UpdateEnergy();
//
//	protected abstract void UpdatePollution();
//
//	protected virtual void FixedUpdate()
//	{
//		UpdateEnergy();
//		UpdatePollution();
//	}
}
