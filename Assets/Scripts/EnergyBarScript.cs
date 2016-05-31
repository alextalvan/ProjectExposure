using UnityEngine;
using System.Collections;

public class EnergyBarScript : MonoBehaviour {

    [SerializeField]
    ResourceScript resources;

    private RectTransform rtransform;
    private Vector2 originalSize;

    // Use this for initialization
    void Start () {
        rtransform = transform.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        originalSize = rtransform.sizeDelta;
        rtransform.sizeDelta = new Vector2(resources.Energy, originalSize.y);
    }
}
