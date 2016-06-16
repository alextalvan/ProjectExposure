using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BUFF_TYPES
{
	UNIT_FREEZE,
	UNIT_SPEED_MODIFIER,
	BUILDING_TEMPORARY_DISABLE,
	BUILDING_TEMPORARY_WEAKER_UNITS
}


//used for generic buffs
[System.Serializable]
public class Buff 
{
	public Buff(BUFF_TYPES typ, float duration) { type = typ; maxDuration = duration; }
	public float maxDuration = 5.0f;
	public float currentDuration = 0.0f;
	public BUFF_TYPES type;

    public delegate void BuffEndDelegate();
    public event BuffEndDelegate OnExpiration = null;

    public void InvokeEndEvent()
    {
        if (OnExpiration != null)
            OnExpiration();
    }
}

//slow buffs also have a slow strength
public class SpeedBuff : Buff
{
	public SpeedBuff(float speedMod, float duration) : base (BUFF_TYPES.UNIT_SPEED_MODIFIER, duration) { speedModifier = speedMod; }
	public float speedModifier = 0.5f;
}

//slow buffs also have a slow strength
public class BuildingStunBuff : Buff
{
	public BuildingStunBuff(int tapCountForUndo, float duration) : base (BUFF_TYPES.BUILDING_TEMPORARY_DISABLE, duration) { currentTapCount = tapCountForUndo; }
	public int currentTapCount;
}


[System.Serializable]
public class BuffList
{
	//[SerializeField]
	public List<Buff> buffs = new List<Buff>();

	public void AddBuff(Buff b)
	{
		buffs.Add(b);
	}

	/// <summary>
	/// Determines whether this instance has at least one buff of the specified type
	/// </summary>
	public bool HasBuff(BUFF_TYPES type)
	{
		foreach(Buff b in buffs)
		{
			if(b.type == type)
				return true;
		}

		return false;
	}

	/// <summary>
	/// Returns all the buffs of the specified type that the list contains
	/// </summary>
	public List<Buff> HasBuffs(BUFF_TYPES type)
	{
		List<Buff> ret = new List<Buff>();
		foreach(Buff b in buffs)
		{
			if(b.type == type)
				ret.Add(b);
		}
		return ret;
	}

	/// <summary>
	/// Removes ALL buffs of the given type.
	/// </summary>
	/// <param name="type">Type.</param>
	public void RemoveBuffs(BUFF_TYPES type)
	{
		for(int i = buffs.Count - 1; i > -1; --i)
		{
			if(buffs[i].type == type)
				buffs.RemoveAt(i);
		}
	}

	/// <summary>
	/// Update all the buff timers and removes the ones that wear out.
	/// It uses the frame delta time (Time.deltaTime)
	/// </summary>
	public void Update()
	{
//		foreach(Buff b in _buffs)
//		{
//			b.currentDuration += Time.deltaTime;
//		}

		for(int i = buffs.Count - 1; i > -1; --i)
		{
			buffs[i].currentDuration += Time.deltaTime;

			if(buffs[i].currentDuration >= buffs[i].maxDuration)
            {
                buffs[i].InvokeEndEvent();
                buffs.RemoveAt(i);
            }
		}
	}
}