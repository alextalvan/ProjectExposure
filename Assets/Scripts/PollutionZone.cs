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
	int maxDamage = 20;

	[SerializeField]
	int turnsBeforeDamageUpgrade = 1;

	[SerializeField]
	int damageGainPerUpgrade = 1;

	int currentTurnCount = 0;

	bool isGrowing = false;

	[SerializeField]
	Renderer pollutionDecalRenderer;

	//[SerializeField]
	public float startPollutionVisibility = 0.25f;

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

			if(currentDamage > maxDamage)
				currentDamage = maxDamage;

			Color c = pollutionDecalRenderer.material.color;
			c.a = (float)currentDamage / (float)maxDamage + ((currentDamage > 0) ? startPollutionVisibility : 0.0f);
			if(c.a > 0.75f)
				c.a = 0.75f;
			pollutionDecalRenderer.material.color = c;
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
