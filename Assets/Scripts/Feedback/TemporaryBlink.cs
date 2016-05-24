using UnityEngine;
using System.Collections;

public class TemporaryBlink : MonoBehaviour 
{
	//the interval at which it switches from on to off
	[SerializeField]
	float blinkInterval = 0.25f;

	//internal members
	float totalTimer = -1.0f;
	float blinkTimer;
	bool objectIsVisible = true;


	//storing initial shader state
	float originalAlpha;
	float originalBlendMode;
	int originalZWrite;
	int originalSrcBlend;
	int originalDstBlend;
	int originalRenderQueue;
	bool originalAlphaTestKeyWord;
	bool originalAlphaBlendKeyWord;
	bool originalAlphaPreMultiplyBlendKeyWord;

	[SerializeField]
	Renderer _targetRenderer;

	void Start()
	{
		originalAlpha = _targetRenderer.material.color.a;
		originalBlendMode = _targetRenderer.material.GetFloat("_Mode");
		originalZWrite = _targetRenderer.material.GetInt("_ZWrite");
		originalSrcBlend = _targetRenderer.material.GetInt("_SrcBlend");
		originalDstBlend = _targetRenderer.material.GetInt("_DstBlend");
		originalRenderQueue = _targetRenderer.material.renderQueue;
		originalAlphaTestKeyWord = _targetRenderer.material.IsKeywordEnabled("_ALPHATEST_ON");
		originalAlphaBlendKeyWord = _targetRenderer.material.IsKeywordEnabled("_ALPHABLEND_ON");
		originalAlphaPreMultiplyBlendKeyWord = _targetRenderer.material.IsKeywordEnabled("_ALPHAPREMULTIPLY_ON");
		//Debug.Log(originalBlendMode);
	}


	public void Begin(float duration = 5.0f)
	{
		totalTimer = duration;
		blinkTimer = blinkInterval;
		objectIsVisible = true;

		//force transparent rendering mode
		_targetRenderer.material.SetFloat("_Mode",3);
		_targetRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
		_targetRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
		_targetRenderer.material.SetInt("_ZWrite", 0);
		_targetRenderer.material.DisableKeyword("_ALPHATEST_ON");
		_targetRenderer.material.EnableKeyword("_ALPHABLEND_ON");
		_targetRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
		_targetRenderer.material.renderQueue = 3000;

		//Color newCol = _renderer.material.color;
		//newCol.a = 1.0f;
	}

	public void Stop()
	{
		totalTimer = -1.0f;
	}

	void Update()
	{
		totalTimer -= Time.deltaTime;
		blinkTimer -= Time.deltaTime;

		if(totalTimer <= 0.0f)
		{
			Color newCol = _targetRenderer.material.color;
			newCol.a = originalAlpha;
			_targetRenderer.material.color = newCol;
			_targetRenderer.material.SetFloat("_Mode",originalBlendMode);//restore original blend mode
			_targetRenderer.material.SetInt("_SrcBlend", originalSrcBlend);
			_targetRenderer.material.SetInt("_DstBlend", originalDstBlend);
			_targetRenderer.material.SetInt("_ZWrite", originalZWrite);
			if(originalAlphaTestKeyWord) _targetRenderer.material.EnableKeyword("_ALPHATEST_ON"); else _targetRenderer.material.DisableKeyword("_ALPHATEST_ON");
			if(originalAlphaBlendKeyWord) _targetRenderer.material.EnableKeyword("_ALPHABLEND_ON"); else _targetRenderer.material.DisableKeyword("_ALPHABLEND_ON");
			if(originalAlphaPreMultiplyBlendKeyWord) _targetRenderer.material.EnableKeyword("_ALPHAPREMULTIPLY_ON"); else _targetRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
			_targetRenderer.material.renderQueue = originalRenderQueue;
			return;
		}

		if(blinkTimer <= 0.0f)
		{
			blinkTimer = blinkInterval;
			objectIsVisible = !objectIsVisible;

			Color newCol = _targetRenderer.material.color;
			newCol.a = (objectIsVisible) ? originalAlpha : 0.0f;
			_targetRenderer.material.color = newCol;
		}

	}
}
