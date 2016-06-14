using UnityEngine;
using System.Collections;

public class ProjParentScript : GameManagerSearcher
{
    private float lifeTime = 10f;
    public float SetLifeTime { set { lifeTime = value; } }
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
        unit.DecreaseStrength();
        bool dead = unit.CheckDeath();
        gameManager.UpdateStrDisplay();
        if (dead)
            ownerAI.UpdateTarget();
        Destroy(gameObject);
    }

    public void DecreaseChildCount(UnitAI unit)
    {
        projLeft--;
        if (projLeft <= 0)
            DoDamage(unit);
    }
}
