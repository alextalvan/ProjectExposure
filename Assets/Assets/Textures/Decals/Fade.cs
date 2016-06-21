using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	[SerializeField] private float fadePerSecond = 2.5f;
	[SerializeField] private float multiplier = 0.0f;	 


	private void FixedUpdate() {
		
		var material = GetComponent<Renderer> ().material;


		if (material.color.a < 0.95f) {
			
			material.color = new Color (material.color.r, material.color.g, material.color.b, material.color.a + (fadePerSecond * Time.deltaTime * multiplier));
			multiplier = multiplier + 0.05f;
		}

	}
}
