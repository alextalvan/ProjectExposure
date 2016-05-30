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

	Material _mat;

	void Start()
	{
		_mat = GetComponent<Image>().material;
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
		_mat.SetFloat("_Health",normValue);
	}
}
