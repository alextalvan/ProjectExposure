using UnityEngine;
using System.Collections;

public class CheerTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        UnitAI unit = col.transform.GetComponent<UnitAI>();
        if (unit)
        {
            unit.StartCheer();
        }
    }
}
