using UnityEngine;
using System.Collections;

public abstract class EnergyBuilding : MonoBehaviour 
{
	[SerializeField]
	protected float currentPollution;

	[SerializeField]
	protected float maxPollution;

	[SerializeField]
	protected float currentEnergy;

	[SerializeField]
	protected float maxEnergy;

	protected abstract void UpdateEnergy();

	protected abstract void UpdatePollution();

	protected virtual void FixedUpdate()
	{
		UpdateEnergy();
		UpdatePollution();
	}
}
