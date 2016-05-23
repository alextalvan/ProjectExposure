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
		buffList.Update();
	}

	void OnMouseUp()
	{
		if(gameManager.playerData[Owner].currentInputState != INPUT_STATES.FREE)
			return;

		bool revertUnitDisable = true;

		foreach(Buff b in buffList.buffs)
		{
			if(b.type == BUFF_TYPES.BUILDING_TEMPORARY_DISABLE)
			{
				BuildingStunBuff bstun = ((BuildingStunBuff)b);
				bstun.currentTapCount--;
				if(bstun.currentTapCount == 0) 
					bstun.currentDuration = bstun.maxDuration + 1.0f;

				//Debug.Log(bstun.currentTapCount);

				if(bstun.currentDuration < bstun.maxDuration)
					revertUnitDisable = false;
			}
		}

		if(revertUnitDisable)
		{
			GetComponent<UnitSpawner>().enabled = true;
			foreach(Renderer r in GetComponentsInChildren<Renderer>())
				r.material.color = Color.white;
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
