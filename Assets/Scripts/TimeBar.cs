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

	//the time bar will reposition itself above the building in the event that the building gets moved
	Vector3 storedOffset;

	Renderer _renderer;

	void Start()
	{
		startScale = transform.localScale;
		_renderer = GetComponent<Renderer>();

		_building.OnDestruction += () => { Destroy(this.gameObject); };
		this.transform.SetParent(null);
		this.transform.localScale = startScale;
		storedOffset = this.transform.position - _building.transform.position;
	}

	void Update () 
	{
		float coef = _building.CurrentLifeTimeLeft / _building.MaxLifeTime;
		transform.localScale = new Vector3(startScale.x * coef, startScale.y, startScale.z);

		_renderer.material.color = Color.Lerp(minLifeColor,maxLifeColor,coef);

		transform.position =  _building.transform.position + storedOffset;
	}
}
