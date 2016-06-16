using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ScoreData  
{
	//public LANES lane;
	[SerializeField]
	private List<GameObject> winIndicatorsLeft = new List<GameObject>();

	[SerializeField]
	private List<GameObject> winIndicatorsRight = new List<GameObject>();

	[SerializeField]
	private float scoreToWin = 20.0f;

	public float MaxScore { get { return scoreToWin; } }

	[SerializeField]
	private float score = 0.0f;
	public float Score { get { return score; } }


	public void ChangeScore(float amount)
	{
        score = Mathf.Clamp(score + amount, -MaxScore, MaxScore);

		float normalizedProgress = score / scoreToWin;
		float threshold = 1.0f / winIndicatorsLeft.Count;

		int indicatorsUp = (int) Mathf.Abs(normalizedProgress / threshold);

		if(score < 0.0f)
		{
			for(int i=0; i < winIndicatorsLeft.Count; ++i)
			{
				if(i < indicatorsUp)
					winIndicatorsLeft[i].SetActive(true);
				else
					winIndicatorsLeft[i].SetActive(false);
			}

			foreach(GameObject obj in winIndicatorsRight)
				obj.SetActive(false);
		}
		else
		{
			for(int i=0; i < winIndicatorsRight.Count; ++i)
			{
				if(i < indicatorsUp)
					winIndicatorsRight[i].SetActive(true);
				else
					winIndicatorsRight[i].SetActive(false);
			}

			foreach(GameObject obj in winIndicatorsLeft)
				obj.SetActive(false);
		}


	}
}


