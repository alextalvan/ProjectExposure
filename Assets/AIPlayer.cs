using UnityEngine;
using System.Collections.Generic;

public class AIPlayer : MonoBehaviour
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
    Transform actionCardsHolder;
    [SerializeField]
    Transform greenBuildingCardsHolder;
    [SerializeField]
    Transform fossilBuildingCardsHolder;

    [SerializeField]
    NeutralCardSpawner neutralCardSpawner;
    [SerializeField]
    CardPurchaseButton cardPurchaseButton;

    [SerializeField]
    BackgroundCollider bgCol;

    GameManager gm;
    PlayerGameData playerData;

    private delegate void Action();
    private Action OnAction = null;
    private GameObject target = null;

    // Use this for initialization
    void Start()
    {
        gm = GetComponent<GameManager>();
        playerData = gm.playerData[playingAs];
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
        int rnd = Random.Range(0, 8);
        switch (rnd) {
            case 0:
                PurchaseCard();
                break;
            case 1:
                SelectActionCard();
                break;
            case 2:
                SelectGreenBuildingCard();
                break;
            case 3:
                SelectFossilBuildingCard();
                break;
            case 4:
                PickUpCoin();
                break;
            case 5:
                InteractWithUnit();
                break;
            case 6:
                RemoveBuildingDebuff();
                break;
            case 7:
                RemoveSwamp();
                break;
        }
    }

    private void Behave()
    {
        //Debug.Log(target);
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

    private void PickUpCoin()
    {
        if (playerData.coin && !playerData.coin.IsUsed)
        {
            target = playerData.coin.gameObject;
#if TOUCH_INPUT
            OnAction += playerData.coin.PenetratingTouchEnd;
#else
            OnAction += playerData.coin.OnMouseUp;
#endif
            OnAction += Nullify;
        }
    }

    private void SelectActionCard()
    {
        if (actionCardsHolder.childCount <= 0) return;
        int rndCardIndex = Random.Range(0, actionCardsHolder.childCount);
        Card selectedCard = actionCardsHolder.GetChild(rndCardIndex).GetComponent<Card>();
        if (selectedCard.isActiveAndEnabled)
        {
            target = selectedCard.gameObject;
#if TOUCH_INPUT
            OnAction += selectedCard.TouchEnd;
#else
            OnAction += selectedCard.OnMouseUp;
#endif
            OnAction += Nullify;
        }
    }

    private void SelectGreenBuildingCard()
    {
        if (greenBuildingCardsHolder.childCount <= 0) return;
        int rndCardIndex = Random.Range(0, greenBuildingCardsHolder.childCount);
        Card selectedCard = greenBuildingCardsHolder.GetChild(rndCardIndex).GetComponent<Card>();
        if (selectedCard.isActiveAndEnabled)
        {
            target = selectedCard.gameObject;
#if TOUCH_INPUT
            OnAction += selectedCard.TouchEnd;
#else
            OnAction += selectedCard.OnMouseUp;
#endif
            OnAction += Nullify;
        }
    }

    private void SelectFossilBuildingCard()
    {
        if (fossilBuildingCardsHolder.childCount <= 0) return;
        int rndCardIndex = Random.Range(0, fossilBuildingCardsHolder.childCount);
        Card selectedCard = fossilBuildingCardsHolder.GetChild(rndCardIndex).GetComponent<Card>();
        if (selectedCard.isActiveAndEnabled)
        {
            target = selectedCard.gameObject;
#if TOUCH_INPUT
            OnAction += selectedCard.TouchEnd;
#else
            OnAction += selectedCard.OnMouseUp;
#endif
            OnAction += Nullify;
        }
    }

    private void SelectFreeTile()
    {
        List<HexagonTile> availableTiles = new List<HexagonTile>();
        foreach (HexagonTile tile in playerData.tiles)
        {
			if (tile.isActiveAndEnabled && tile.AllowBuild)
                availableTiles.Add(tile);
        }

        if (availableTiles.Count <= 0)
        {
            target = bgCol.gameObject;
#if TOUCH_INPUT
            OnAction += bgCol.TouchEnd;
#else
            OnAction += bgCol.OnMouseUp;
#endif
            OnAction += Nullify;
            return;
        }
        int rndTileIndex = Random.Range(0, availableTiles.Count);
        target = availableTiles[rndTileIndex].gameObject;
#if TOUCH_INPUT
        OnAction += availableTiles[rndTileIndex].PenetratingTouchEnd;
#else
        OnAction += availableTiles[rndTileIndex].OnMouseUp;
#endif
        OnAction += Nullify;
    }

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

    private void Nullify()
    {
        target = null;
        OnAction = null;
    }
}
