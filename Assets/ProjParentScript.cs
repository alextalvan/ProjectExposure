using UnityEngine;
using System.Collections;

public class ProjParentScript : GameManagerSearcher
{
    [SerializeField]
    private float lifeTime = 10f;
    private UnitAI ownerAI;
    public UnitAI SetOwner { set { ownerAI = value; } }
    private int projLeft;

    // Use this for initialization
    void Start()
    {
        projLeft = transform.childCount;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoDamage(UnitAI unit)
    {
		//temp
		unit.DecreaseHealth(UnitAI.damageMatrix[(int)this.ownerAI.Type,(int)unit.Type]);


        //unit.DecreaseHealth();
        bool dead = unit.CheckDeath();
        if (dead && ownerAI)
            ownerAI.NullifyTarget();
        Destroy(gameObject);
    }

    public void DecreaseChildCount(UnitAI unit)
    {
        projLeft--;
        if (projLeft <= 0)
            DoDamage(unit);
    }
}
