using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AIPlayer : GameManagerSearcher
{
    public enum AIMod { AI, Helper, None };
    private AIMod currentMod = AIMod.Helper;
    public AIMod Mod { set { currentMod = value; } }

    [SerializeField]
    PLAYERS playingAs;

    [SerializeField]
    GameObject finger;
    private Image fingerImg;

    [SerializeField]
    Sprite idleFinger;
    [SerializeField]
    Sprite pressedFinger;

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
    float fingerReleaseDelay = 0.5f;

    [SerializeField]
    Transform cardPicker;

    PlayerGameData playerData;
    BuildingCard selectedCard = null;

    private List<BuildingCard> buildingCards = new List<BuildingCard>();
    private delegate void Action();
    private Action OnAction = null;
    private GameObject target = null;
    private bool allowMovement = true;

    private float fingerReleaseTimer;
    private int helperStage = 0;

    // Use this for initialization
    void Start()
    {
        fingerImg = finger.GetComponent<Image>();
        fingerImg.sprite = idleFinger;
        playerData = gameManager.playerData[playingAs];
        foreach (Transform cardParent in cardPicker)
        {
            buildingCards.Add(cardParent.GetChild(0).GetComponent<BuildingCard>());
        }
    }

    private void PressFinger()
    {
        fingerImg.sprite = pressedFinger;
        allowMovement = false;
        StartCoroutine(ReleaseFinger());
    }

    IEnumerator ReleaseFinger()
    {
        yield return new WaitForSeconds(fingerReleaseDelay);
        fingerImg.sprite = idleFinger;
        allowMovement = true;
    }

    void OnEnable()
    {
        finger.SetActive(true);
    }

    void OnDisable()
    {
        finger.SetActive(false);
    }

    void FixedUpdate()
    {
        delayTimer -= Time.deltaTime;
        switch (currentMod)
        {
            case AIMod.AI:
                AIBehavior();
                break;
            case AIMod.Helper:
                HelperBehavior();
                break;
            case AIMod.None:
                this.enabled = true;
                break;
        }
    }

    private void PickTarget()
    {
        if (playerData.pickUp)
            SelectPickUp();
        else
            SelectBuildingCard(false);
    }

    private void AIBehavior()
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
                    SelectFreeTile(false);
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

    private void HelperBehavior()
    {
        fingerReleaseTimer -= Time.deltaTime;

        if (helperStage == 0)
        {
            if (!target)
                SelectBuildingCard(true);
            else if (playerData.currentSelectedCard)
            {
                target = null;
                helperStage++;
            }
        }
        else if (helperStage == 1)
        {
            if (!target)
                SelectFreeTile(true);
            else if (playerData.buildingCount > 0)
            {
                target = null;
                currentMod = AIMod.None;
                this.enabled = false;
                return;
            }
        }

        float dist = Mathf.Infinity;
        if (target)
            dist = Vector3.Distance(finger.transform.position, target.transform.position);

        if (dist < distanceToTarget)
        {
            if (fingerReleaseTimer <= 0f)
            {
                PressFinger();
                fingerReleaseTimer = fingerReleaseDelay * 2f;
            }
        }
        else
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        if (target && allowMovement)
            finger.GetComponent<RectTransform>().position = Vector3.Lerp(finger.GetComponent<RectTransform>().position, target.transform.position, fingerSpeed * Time.deltaTime);
    }

    private void SelectBuildingCard(bool helper)
    {
        int fossilCount = 0;
        int greenCount = 0;

        foreach (EnergyBuilding building in playerData.buildings)
        {
            if (building.IsPolluting)
                fossilCount++;
            else
                greenCount++;
        }

        bool goGreen = fossilCount > greenCount ? true : false;

        List<BuildingCard> playableCards = new List<BuildingCard>();
        foreach (BuildingCard bCard in buildingCards)
            if (bCard.IsPlayable)
            {
                if (!bCard.BuildingType.prefab.GetComponent<EnergyBuilding>().IsPolluting == goGreen)
                    playableCards.Add(bCard);
            }

        if (playableCards.Count == 0) return;

        int rndCardIndex = Random.Range(0, playableCards.Count);
        selectedCard = playableCards[rndCardIndex];
        target = selectedCard.gameObject;
        if (helper) return;

#if TOUCH_INPUT
        OnAction += selectedCard.TouchEnd;
#else
        OnAction += selectedCard.OnMouseUp;
#endif
        OnAction += Click;
    }

    private void SelectFreeTile(bool helper)
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
                if (tile.isActiveAndEnabled && tile.AllowBuild && selectedCard.BuildingType.type != tile.CurrentEnergyBuilding.Type)
                    availableTiles.Add(tile);
            }
        }

        if (availableTiles.Count == 0) return;

        int rndTileIndex = Random.Range(0, availableTiles.Count);
        target = availableTiles[rndTileIndex].gameObject;

        if (helper) return;
#if TOUCH_INPUT
        OnAction += availableTiles[rndTileIndex].PenetratingTouchEnd;
#else
        OnAction += availableTiles[rndTileIndex].OnMouseUp;
#endif
        OnAction += Click;
    }

    private void SelectPickUp()
    {
        CoinPickup gem = playerData.pickUp.GetComponent<CoinPickup>();
        target = playerData.pickUp;

        gem.OnDestruction += () => { target = null; OnAction = null; };
#if TOUCH_INPUT
        OnAction += gem.PenetratingTouchEnd;
#else
        OnAction += gem.OnMouseUp;
#endif
        OnAction += Click;
    }

    private void Click()
    {
        PressFinger();
        target = null;
        OnAction = null;
    }
}
