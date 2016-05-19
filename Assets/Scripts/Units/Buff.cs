using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BUFF_TYPES
{
	FREEZE,
	SLOW
}


[System.Serializable]
public class Buff 
{
	public Buff(BUFF_TYPES typ, float duration) { type = typ; maxDuration = duration; }
	public float maxDuration = 5.0f;
	public float currentDuration = 0.0f;
	public BUFF_TYPES type;
}

//[System.Serializable]
public class BuffList
{
	[SerializeField]
	private List<Buff> _buffs = new List<Buff>();

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
	List<Buff> HasBuffs(BUFF_TYPES type)
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
	/// Update all the buff timers and removes the ones that wear out.
	/// It uses the frame delta time (Time.deltaTime)
	/// </summary>
	public void Update()
	{
		foreach(Buff b in _buffs)
		{
			b.currentDuration += Time.deltaTime;
		}

		for(int i = _buffs.Count - 1; i > -1; --i)
		{
			if(_buffs[i].currentDuration >= _buffs[i].maxDuration)
				_buffs.RemoveAt(i);
		}
	}
}