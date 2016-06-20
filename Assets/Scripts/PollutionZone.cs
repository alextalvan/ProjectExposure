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

	int currentTurnCount = 0;

	public void HandleNewWave()
	{
		units.Clear();

		currentTurnCount++;
		if(currentTurnCount == turnsBeforeDamageUpgrade)
		{
			currentTurnCount = 0;
			currentDamage++;
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
