using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class IconTimer : MonoBehaviour 
{

	[SerializeField]
	float totalTime;

	[SerializeField]
	float currentTime;

	[SerializeField]
	Material circleTimerMaterialPrefab;

	Material _material;

	void Start()
	{
		//force material instantiation
		_material = (Material)Instantiate(circleTimerMaterialPrefab);
		GetComponent<Image>().material = _material;
	}

	public void Reset(float duration)
	{
		currentTime = duration;
		totalTime = duration;
	}

	void Update()
	{
		currentTime -= Time.deltaTime;
		float normValue = Mathf.Clamp01(currentTime / totalTime);
		_material.SetFloat("_Health",normValue);
	}
}
