using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class PollutionZone : MonoBehaviour 
{

	private List<UnitAI> units = new List<UnitAI>();

	[SerializeField]
	int currentDamage = 0;

	[SerializeField]
	int turnsBeforeDamageUpgrade = 1;

	[SerializeField]
	int damageGainPerUpgrade = 1;

	int currentTurnCount = 0;

	bool isGrowing = false;

	public void SetGrowState(bool state)
	{
		isGrowing = state;
	}

	public void HandleNewWave()
	{
		units.Clear();

		currentTurnCount++;
		if(currentTurnCount == turnsBeforeDamageUpgrade)
		{
			currentTurnCount = 0;

			if(isGrowing)
				currentDamage += damageGainPerUpgrade;
			else
				currentDamage -= damageGainPerUpgrade;

			if(currentDamage < 0 )
				currentDamage = 0;
		}
	}


	void OnTriggerEnter(Collider other)
	{
		UnitAI ai = other.GetComponent<UnitAI>();

		if(ai && !units.Contains(ai))
		{
			units.Add(ai);
			ai.DecreaseHealth(currentDamage);
		}
	}
}
