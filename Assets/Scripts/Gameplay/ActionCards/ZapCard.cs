using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZapCard : ActionCard 
{

    [SerializeField]
    GameObject thunderPrefab;
    [SerializeField]
    float unitDestructionDelay = 1f;

	public override bool CalculatePlayCondition ()
	{
		if(!enabled)
			return false;

//		if(!CheckMoneyCost())
//			return false;

		return EnemyHasUnits();
	}

	public override void DoCardEffect ()
	{
		base.DoCardEffect();

		enemyData = gameManager.playerData[(this.Owner == PLAYERS.PLAYER1) ? PLAYERS.PLAYER2 : PLAYERS.PLAYER1];
		List<Transform> groupsWithUnits = new List<Transform>(enemyData.unitGroups.Count);

		foreach(Transform tr in enemyData.unitGroups)
		{
			if(tr.childCount > 0)
				groupsWithUnits.Add(tr);
		}

		Transform randomGroup = groupsWithUnits[Random.Range(0,groupsWithUnits.Count)];

		foreach(Transform unit in randomGroup)
		{
            Instantiate(thunderPrefab, unit.position + Vector3.up * 2f - Vector3.forward * 15f, Quaternion.identity);
            //Destroy(unit.gameObject, unitDestructionDelay);
            unit.GetComponent<UnitAI>().CustomDestroy();
            //Destroy(unit.gameObject);
        }

		Destroy(this.gameObject);
	}
}
