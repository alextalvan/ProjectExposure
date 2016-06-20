using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ScoreData  
{
	//public LANES lane;
	[SerializeField]
	private Transform redBar;

	[SerializeField]
	private Transform blueBar;

	[SerializeField]
	private float scoreToWin = 20.0f;

	public float MaxScore { get { return scoreToWin; } }

	[SerializeField]
	private float score = 0.0f;
	public float Score { get { return score; } }

	[SerializeField]
	float maxBarScale = 1.25f;

	//[SerializeField]
	float interpolationSpeed = 0.1f;

	float targetRelativeScaleRed = 1.0f;
	float targetRelativeScaleBlue = 1.0f;

	public void ChangeScore(float amount)
	{
        score = Mathf.Clamp(score + amount, -MaxScore, MaxScore);

		float normalizedScore = Mathf.Abs(score / MaxScore);

		if(score < 0.0f)
		{
			targetRelativeScaleRed = 1.0f + normalizedScore;
			targetRelativeScaleBlue = 1.0f - normalizedScore;
		}
		else
		{
			targetRelativeScaleBlue = 1.0f + normalizedScore;
			targetRelativeScaleRed = 1.0f - normalizedScore;
		}


	}


	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.K))
			ChangeScore(-2);

		if(Input.GetKeyDown(KeyCode.L))
			ChangeScore(2);

		Vector3 redScale = redBar.transform.localScale;
		redScale.x = Mathf.Lerp(redScale.x,targetRelativeScaleRed * maxBarScale, interpolationSpeed);
		redBar.transform.localScale = redScale;

		Vector3 blueScale = blueBar.transform.localScale;
		blueScale.x = Mathf.Lerp(blueScale.x,targetRelativeScaleBlue * maxBarScale, interpolationSpeed);
		blueBar.transform.localScale = blueScale;
	}
}


