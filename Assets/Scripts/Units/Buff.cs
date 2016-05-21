using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BUFF_TYPES
{
	FREEZE,
	SPEED_MODIFIER
}


//used for generic buffs
[System.Serializable]
public class Buff 
{
	public Buff(BUFF_TYPES typ, float duration) { type = typ; maxDuration = duration; }
	public float maxDuration = 5.0f;
	public float currentDuration = 0.0f;
	public BUFF_TYPES type;
}

//slow buffs also have a slow strength
public class SpeedBuff : Buff
{
	public SpeedBuff(float speedMod, float duration) : base (BUFF_TYPES.SPEED_MODIFIER, duration) { speedModifier = speedMod; }
	public float speedModifier = 0.5f;
}


[System.Serializable]
public class BuffList
{
	//[SerializeField]
	public List<Buff> _buffs = new List<Buff>();

	public void AddBuff(Buff b)
	{
		_buffs.Add(b);
	}

	/// <summary>
	/// Determines whether this instance has at least one buff of the specified type
	/// </summary>
	public bool HasBuff(BUFF_TYPES type)
	{
		foreach(Buff b in _buffs)
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
		foreach(Buff b in _buffs)
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
		for(int i = _buffs.Count - 1; i > -1; --i)
		{
			if(_buffs[i].type == type)
				_buffs.RemoveAt(i);
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

		for(int i = _buffs.Count - 1; i > -1; --i)
		{
			_buffs[i].currentDuration += Time.deltaTime;

			if(_buffs[i].currentDuration >= _buffs[i].maxDuration)
				_buffs.RemoveAt(i);
		}
	}
}