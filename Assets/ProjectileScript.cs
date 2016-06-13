using UnityEngine;
using System.Collections;

public class ProjectileScript : GameManagerSearcher
{
    UnitAI ownerAI;
    public UnitAI SetOwner { set { ownerAI = value; } }

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
        {
            unit.DecreaseStrength();
            bool dead = unit.CheckDeath();
            gameManager.UpdateStrDisplay();
            if (dead)
                ownerAI.UpdateTarget();
        }
        Destroy(gameObject);
    }
}
