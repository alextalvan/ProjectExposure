using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class TimeBar : MonoBehaviour 
{
	[SerializeField]
	EnergyBuilding _building;

	[SerializeField]
	Color maxLifeColor = Color.green;

	[SerializeField]
	Color minLifeColor = Color.red;

	Vector3 startScale;

	Renderer _renderer;

	void Start()
	{
		startScale = transform.localScale;
		_renderer = GetComponent<Renderer>();
	}

	void Update () 
	{
		float coef = _building.CurrentLifeTimeLeft / _building.MaxLifeTime;
		transform.localScale = new Vector3(startScale.x * coef, startScale.y, startScale.z);

		_renderer.material.color = Color.Lerp(minLifeColor,maxLifeColor,coef);
	}
}
