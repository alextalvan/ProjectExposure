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
    float minDelay = 1f;
    [SerializeField]
    float maxDelay = 2f;
    float delayTimer;

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
        delayTimer -= Time.deltaTime;
        Behave();
    }

    private void PickTarget()
    {
        SelectBuildingCard();
    }

    private void Behave()
    {
        if (target && delayTimer <= 0f)
        {
            float dist = Vector3.Distance(finger.transform.position, target.transform.position);
            if (dist > distanceToTarget)
            {
                MoveTowardsTarget();
            }
            else
            {
                if (target.GetComponent<BuildingCard>())
                {
                    OnAction();
                    SelectFreeTile();
                }
                else
                {
                    OnAction();
                }
            }
        }
        else
        {
            if (!target)
                delayTimer = Random.Range(minDelay, maxDelay);
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
            if (tile.isActiveAndEnabled && tile.AllowBuild && !tile.CurrentEnergyBuilding)
                availableTiles.Add(tile);
        }
        if (availableTiles.Count == 0)
        {
            foreach (HexagonTile tile in playerData.tiles)
            {
                if (tile.isActiveAndEnabled && tile.AllowBuild)
                    availableTiles.Add(tile);
            }
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

    private void Nullify()
    {
        target = null;
        OnAction = null;
    }
}
