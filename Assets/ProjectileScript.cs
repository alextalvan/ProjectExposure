using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    GameObject particle;

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
        Instantiate(particle, transform.position, Random.rotation);
        Destroy(gameObject);
    }
}
