using UnityEngine;
using System.Collections.Generic;

public class AIPlayer : MonoBehaviour
{
    [SerializeField]
    PLAYERS playingAs;

    [SerializeField]
    Sprite fingerSprite;

    [SerializeField]
    float fingerSpeed = 5f;
    [SerializeField]
    float distanceToTarget = 5f;

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

    private Vector2 fingerPos;
    private Vector2 targetPos;
    private object targetObj = null;
    private delegate void Action();
    private Action currentAction = null;

    // Use this for initialization
    void Start()
    {
        gm = GetComponent<GameManager>();
        playerData = gm.playerData[playingAs];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PurchaseCard();
        SelectActionCard();
        SelectGreenBuildingCard();
        SelectFossilBuildingCard();
        PickUpCoin();
        InteractWithUnit();
        RemoveBuildingDebuff();
        RemoveSwamp();
    }

    private void Tap()
    {

    }

    private void PickUpCoin()
    {
        if (playerData.coin)
        {
#if TOUCH_INPUT
	        playerData.coin.PenetratingTouchEnd();
#else
            playerData.coin.OnMouseUp();
#endif
            targetObj = playerData.coin;
        }
    }

    private void SelectActionCard()
    {
        if (actionCardsHolder.childCount <= 0) return;
        int rndCardIndex = Random.Range(0, actionCardsHolder.childCount);
        Card selectedCard = actionCardsHolder.GetChild(rndCardIndex).GetComponent<Card>();
        if (selectedCard.isActiveAndEnabled)
        {
#if TOUCH_INPUT
            selectedCard.TouchEnd();
#else
            selectedCard.OnMouseUp();
#endif
        }
    }

    private void SelectGreenBuildingCard()
    {
        if (greenBuildingCardsHolder.childCount <= 0) return;
        int rndCardIndex = Random.Range(0, greenBuildingCardsHolder.childCount);
        Card selectedCard = greenBuildingCardsHolder.GetChild(rndCardIndex).GetComponent<Card>();
        if (selectedCard.isActiveAndEnabled)
        {
#if TOUCH_INPUT
            selectedCard.TouchEnd();
#else
            selectedCard.OnMouseUp();
#endif
            SelectFreeTile();
        }
    }

    private void SelectFossilBuildingCard()
    {
        if (fossilBuildingCardsHolder.childCount <= 0) return;
        int rndCardIndex = Random.Range(0, fossilBuildingCardsHolder.childCount);
        Card selectedCard = fossilBuildingCardsHolder.GetChild(rndCardIndex).GetComponent<Card>();
        if (selectedCard.isActiveAndEnabled)
        {
#if TOUCH_INPUT
            selectedCard.TouchEnd();
#else
            selectedCard.OnMouseUp();
#endif
            SelectFreeTile();
        }
    }

    private void SelectFreeTile()
    {
        List<HexagonTile> availableTiles = new List<HexagonTile>();
        foreach (HexagonTile tile in playerData.tiles)
        {
            if (tile.AllowBuild)
                availableTiles.Add(tile);
        }

        if (availableTiles.Count <= 0)
        {
#if TOUCH_INPUT
	        bgCol.TouchEnd();
#else
            bgCol.OnMouseUp();
#endif
            return;
        }
        int rndTileIndex = Random.Range(0, availableTiles.Count);
#if TOUCH_INPUT
	    availableTiles[rndTileIndex].TouchEnd();
#else
        availableTiles[rndTileIndex].OnMouseUp();
#endif
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
#if TOUCH_INPUT
                    unitAI.PenetratingTouchEnd();
#else
                    unitAI.OnMouseUp();
#endif
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
#if TOUCH_INPUT
                tile.CurrentEnergyBuilding.TouchEnd();
#else
                tile.CurrentEnergyBuilding.OnMouseUp();
#endif
                return; //
            }
        }
    }

    private void RemoveSwamp()
    {
        foreach (SwampSpot swamp in playerData.swampSpots)
        {
            if (swamp.isActiveAndEnabled)
                swamp.ToggleOff();
        }
    }

    private void PurchaseCard()
    {
        if (cardPurchaseButton.isActiveAndEnabled)
        {
            //if (neutralCardSpawner.GetCurrentCard && !neutralCardSpawner.GetCurrentCard.GetComponent<ActionCard>())
                cardPurchaseButton.OnMouseUp();
        }
    }
}
