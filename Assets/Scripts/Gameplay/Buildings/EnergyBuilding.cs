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

	//each building can leave the tile blocked after it is destroyed
	[SerializeField]
	float blockTime = 0.0f;

	[SerializeField]
	GameObject pollutionPrefab = null;

	public float MaxLifeTime { get { return maxlifeTime; } }
	public float CurrentLifeTimeLeft { get { return lifeTimeLeft; } }
	public float BlockTime { get { return blockTime; } }
	public GameObject PollutionPrefab { get { return pollutionPrefab; } }

	public delegate void BuildingDestructionDelegate();
	public event BuildingDestructionDelegate OnDestruction = null;

	//buildings can also be buffed
	public BuffList buffList = new BuffList();

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



		bool wasDisabled = false;

		foreach(Buff b in buffList.buffs)
		if(b.type == BUFF_TYPES.BUILDING_TEMPORARY_DISABLE)
		{
			wasDisabled = true;
			break;
		}


		buffList.Update();


		if(wasDisabled)
		{
			bool isNowDisabled = false;

			foreach(Buff b in buffList.buffs)
			if(b.type == BUFF_TYPES.BUILDING_TEMPORARY_DISABLE)
			{
				isNowDisabled = true;
				break;
			}

			if(!isNowDisabled)
			{
				GetComponent<UnitSpawner>().enabled = true;
				GetComponent<TemporaryBlink>().Stop();
			}
		}
	}


	#if TOUCH_INPUT
	void TouchEnd()
	#else
	void OnMouseUp()
	#endif
	{
		if(gameManager.playerData[Owner].currentInputState != INPUT_STATES.FREE)
			return;

		foreach(Buff b in buffList.buffs)
		{
			if(b.type == BUFF_TYPES.BUILDING_TEMPORARY_DISABLE)
			{
				BuildingStunBuff bstun = ((BuildingStunBuff)b);
				bstun.currentTapCount--;
				if(bstun.currentTapCount == 0) 
					bstun.currentDuration = bstun.maxDuration + 1.0f;

			}
		}
			
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
