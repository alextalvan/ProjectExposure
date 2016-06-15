using UnityEngine;
using System.Collections.Generic;

public class AIPlayer : GameManagerSearcher
{
    [SerializeField]
    PLAYERS playingAs;

    [SerializeField]
    GameObject finger;

    [SerializeField]
    float fingerSpeed = 5f;
    [SerializeField]
    float distanceToTarget = 1f;

    [SerializeField]
    Transform cardPicker;

    PlayerGameData playerData;

    private List<BuildingCard> buildingCards = new List<BuildingCard>();
    private delegate void Action();
    private Action OnAction = null;
    private GameObject target = null;

    // Use this for initialization
    void Start()
    {
        playerData = gameManager.playerData[playingAs];
        foreach (Transform cardParent in cardPicker)
        {
            buildingCards.Add(cardParent.GetChild(0).GetComponent<BuildingCard>());
        }
    }

    void OnEnable()
    {
        finger.SetActive(true);
    }

    void OnDisable()
    {
        finger.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Behave();
    }

    private void PickTarget()
    {
        SelectBuildingCard();
    }

    private void Behave()
    {
        if (target)
        {
            float dist = Vector3.Distance(finger.transform.position, target.transform.position);
            if (dist > distanceToTarget)
                MoveTowardsTarget();
            else
            {
                if (target.GetComponent<BuildingCard>())
                {
                    OnAction();
                    SelectFreeTile();
                }
                else
                    OnAction();
            }
        }
        else
        {
            PickTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        finger.GetComponent<RectTransform>().position = Vector3.Lerp(finger.GetComponent<RectTransform>().position, target.transform.position, fingerSpeed * Time.deltaTime);
    }

    private void SelectBuildingCard()
    {
        List<BuildingCard> playableCards = new List<BuildingCard>();
        foreach (BuildingCard bCard in buildingCards)
            if (bCard.IsPlayable)
                playableCards.Add(bCard);

        if (playableCards.Count == 0) return;

        int rndCardIndex = Random.Range(0, playableCards.Count);
        BuildingCard selectedCard = playableCards[rndCardIndex];
        target = selectedCard.gameObject;
#if TOUCH_INPUT
        OnAction += selectedCard.TouchEnd;
#else
        OnAction += selectedCard.OnMouseUp;
#endif
        OnAction += Nullify;
    }

    private void SelectFreeTile()
    {
        List<HexagonTile> availableTiles = new List<HexagonTile>();
        foreach (HexagonTile tile in playerData.tiles)
        {
            if (tile.isActiveAndEnabled && tile.AllowBuild)
                availableTiles.Add(tile);
        }

        if (availableTiles.Count == 0) return;

        int rndTileIndex = Random.Range(0, availableTiles.Count);
        target = availableTiles[rndTileIndex].gameObject;
#if TOUCH_INPUT
        OnAction += availableTiles[rndTileIndex].PenetratingTouchEnd;
#else
        OnAction += availableTiles[rndTileIndex].OnMouseUp;
#endif
        OnAction += Nullify;
    }

    /*
    private void InteractWithUnit()
    {
        foreach (Transform unitGroup in playerData.unitGroups)
        {
            foreach (Transform unit in unitGroup)
            {
                UnitAI unitAI = unit.GetComponent<UnitAI>();
                if (!unitAI.buffList.HasBuff(BUFF_TYPES.UNIT_SPEED_MODIFIER) || unitAI.buffList.HasBuff(BUFF_TYPES.UNIT_FREEZE))
                {
                    target = unit.gameObject;
#if TOUCH_INPUT
                    OnAction += unitAI.PenetratingTouchEnd;
#else
                    OnAction += unitAI.OnMouseUp;
#endif
                    OnAction += Nullify;
                    return; //for now
                }
            }
        }
    }
    */

    /*
    private void RemoveBuildingDebuff()
    {
        foreach (HexagonTile tile in playerData.tiles)
        {
            if (tile.CurrentEnergyBuilding && tile.CurrentEnergyBuilding.buffList.HasBuff(BUFF_TYPES.BUILDING_TEMPORARY_DISABLE))
            {
                target = tile.CurrentEnergyBuilding.gameObject;
#if TOUCH_INPUT
                OnAction += tile.CurrentEnergyBuilding.TouchEnd;
#else
                OnAction += tile.CurrentEnergyBuilding.OnMouseUp;
#endif
                OnAction += Nullify;
                return;
            }
        }
    }

    private void RemoveSwamp()
    {
        foreach (SwampSpot swamp in playerData.swampSpots)
        {
            if (swamp.isActiveAndEnabled)
            {
                target = swamp.gameObject;
                OnAction += swamp.ToggleOff;
                OnAction += Nullify;
                return;
            }
        }
    }

    private void PurchaseCard()
    {
        if (cardPurchaseButton.isActiveAndEnabled)
        {
            if (neutralCardSpawner.GetCurrentCard && !neutralCardSpawner.GetCurrentCard.GetComponent<ActionCard>())
            {
                target = cardPurchaseButton.gameObject;
#if TOUCH_INPUT
                OnAction += cardPurchaseButton.TouchEnd;
#else
                OnAction += cardPurchaseButton.OnMouseUp;
#endif
                OnAction += Nullify;
            }
        }
    }
    */

    private void Nullify()
    {
        target = null;
        OnAction = null;
    }
}
