using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FreezeCard : ActionCard 
{
	[SerializeField]
	float freezeDuration = 5.0f;

	protected override bool CalculatePlayCondition ()
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
			if(tr.childCount > 0 && IsGoodGroup(tr))
				groupsWithUnits.Add(tr);
		}

		if(groupsWithUnits.Count < 1)
			return;

		Transform randomGroup = groupsWithUnits[Random.Range(0,groupsWithUnits.Count)];

		foreach(Transform unit in randomGroup)
		{
			UnitAI aiComp = unit.GetComponent<UnitAI>();
            
			if(aiComp && !aiComp.CityTile && !aiComp.buffList.HasBuff(BUFF_TYPES.UNIT_FREEZE))
			{
				Buff freezeBuff = new Buff(BUFF_TYPES.UNIT_FREEZE,freezeDuration);
				//aiComp.buffList.AddBuff(freezeBuff);
				aiComp.AddFreezeBuff(freezeBuff);
				//unit.GetComponent<TemporaryBlink>().Begin(freezeDuration);
			}
		}

		Destroy(this.gameObject);
	}

    private bool IsGoodGroup(Transform tr)
    {
        int count = 0;
        foreach (Transform unit in tr)
        {
            UnitAI aiComp = unit.GetComponent<UnitAI>();
            if (aiComp.CityTile || aiComp.buffList.HasBuff(BUFF_TYPES.UNIT_FREEZE))
                count++;
        }
        if (count >= tr.childCount)
            return false;
        return true;
    }
}
