using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	[SerializeField]
	float currentEnergy = 100;

	[SerializeField]
	float maxEnergy = 1000;

	[SerializeField]
	float energyVelocity = -0.2f;

	[SerializeField]//temp using transform and scaling
	Transform energyUIBar;

	[SerializeField]
	float currentPollution = 100;

	[SerializeField]
	float maxPollution = 1000;

	[SerializeField]
	float pollutionVelocity = 0.0f;

	[SerializeField]//temp using transform and scaling
	Transform pollutionUIBar;



	void FixedUpdate()
	{
		currentEnergy += energyVelocity;
		currentEnergy = Mathf.Clamp(currentEnergy,0.0f,maxEnergy);

		currentPollution += pollutionVelocity;
		currentPollution = Mathf.Clamp(currentPollution,0.0f,maxPollution);


		UpdateUIBars();
	}


	void UpdateUIBars()
	{
		energyUIBar.localScale = new Vector3(1, currentEnergy / maxEnergy, 1);
		pollutionUIBar.localScale = new Vector3(1, currentPollution / maxPollution, 1);
	}
}
