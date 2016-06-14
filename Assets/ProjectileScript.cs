using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        UnitAI unit = col.transform.GetComponent<UnitAI>();
        if (unit)
            transform.parent.GetComponent<ProjParentScript>().DecreaseChildCount(unit);
        Destroy(gameObject);
    }
}
