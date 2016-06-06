using UnityEngine;
using System.Collections.Generic;

public class AIPlayer : MonoBehaviour
{

    [SerializeField]
    PLAYERS playingAs;

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

    // Use this for initialization
    void Start()
    {
        gm = GetComponent<GameManager>();
        playerData = gm.playerData[playingAs];
    }

    // Update is called once per frame
    void Update()
    {
        PurchaseCard();
        SelectActionCard();
        SelectGreenBuildingCard();
        SelectFossilBuildingCard();
    }

    private void SelectActionCard()
    {
        if (actionCardsHolder.childCount <= 0) return;
        int rndCardIndex = Random.Range(0, actionCardsHolder.childCount);
        Card selectedCard = actionCardsHolder.GetChild(rndCardIndex).GetComponent<Card>();
        if (selectedCard.isActiveAndEnabled)
        {

            selectedCard.DoCardEffect();
        }
    }

    private void SelectGreenBuildingCard()
    {
        if (greenBuildingCardsHolder.childCount <= 0) return;
        int rndCardIndex = Random.Range(0, greenBuildingCardsHolder.childCount);
        Card selectedCard = greenBuildingCardsHolder.GetChild(rndCardIndex).GetComponent<Card>();
        if (selectedCard.isActiveAndEnabled)
        {
            selectedCard.DoCardEffect();
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
            selectedCard.DoCardEffect();
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

    private void SelectTile()
    {

    }

    private void PurchaseCard()
    {
        if (cardPurchaseButton.isActiveAndEnabled)
        {
            cardPurchaseButton.OnMouseUp();
        }
    }
}
