using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArrowScript : MonoBehaviour {

    [SerializeField]
    float lerpSpeed = 1f;

    [SerializeField]
    GameObject hostCard;

    [SerializeField]
    GameObject targetCard;

    private Image img;

	// Use this for initialization
	void Start () {
        img = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (hostCard.transform.parent.position == hostCard.transform.position && targetCard.transform.parent.position == targetCard.transform.position)
            img.color = new Color(1f, 1f, 1f, Mathf.Lerp(img.color.a, 1f, lerpSpeed));
        else
            img.color = new Color(1f, 1f, 1f, Mathf.Lerp(img.color.a, 0f, lerpSpeed));
    }
}
