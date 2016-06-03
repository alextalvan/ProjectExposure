using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFader : MonoBehaviour {


	SpriteRenderer _renderer;

	float fadeDuration = 0.05f;
	float timeAccumulator = 0.0f;

	bool fade = false;


	// Use this for initialization
	void Start () {
		_renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(fade)
		{
			timeAccumulator += Time.deltaTime;

			Color newCol = _renderer.color;
			newCol.a = Mathf.Clamp01(1.0f - timeAccumulator / fadeDuration);
			_renderer.color = newCol;

			//if(newCol.a < 0.0001f)
			//	fade = false;
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			Reset();
			StartFade();
		}
	}

	public void StartFade(float duration = 1.0f)
	{
		fade = true;
		fadeDuration = duration;
		timeAccumulator = 0.0f;
	}

	public void Reset()
	{
		fade = false;

	}
}
