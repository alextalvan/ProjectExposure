using UnityEngine;
using System.Collections;

public class BuildingDissolve : MonoBehaviour {

	[SerializeField]
	float dissolveTime = 5.0f;

	float timeAccumulator;

	[SerializeField]
	Renderer _renderer;

	void Start()
	{
		timeAccumulator = 0.0f;
	}

	void Update()
	{
		timeAccumulator = Mathf.Clamp(timeAccumulator + Time.deltaTime,0.0f,dissolveTime);

		_renderer.material.SetFloat("_Visibility",timeAccumulator / dissolveTime);
	}
}
