using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class PollutionZone : MonoBehaviour
{
    [SerializeField]
    int currentDamage = 0;

    [SerializeField]
    int maxDamage = 20;

    [SerializeField]
    int turnsBeforeDamageUpgrade = 1;

    [SerializeField]
    int damageGainPerUpgrade = 1;

    int currentTurnCount = 0;

    bool isGrowing = false;

    [SerializeField]
    Renderer pollutionDecalRenderer;

    [SerializeField]
    float startPollutionVisibility = 0.25f;


    float targetAlpha = 0f;
    float currentAlpha = 0f;
    float lerpSpeed = 0.05f;

    public void SetGrowState(bool state)
    {
        isGrowing = state;
    }

    public void HandleNewWave()
    {
        currentTurnCount++;
        if (currentTurnCount == turnsBeforeDamageUpgrade)
        {
            currentTurnCount = 0;

            if (isGrowing)
                currentDamage += damageGainPerUpgrade;
            else
                currentDamage -= damageGainPerUpgrade;

            if (currentDamage < 0)
                currentDamage = 0;

            if (currentDamage > maxDamage)
                currentDamage = maxDamage;

            targetAlpha = (float)currentDamage / (float)maxDamage + ((currentDamage > 0) ? startPollutionVisibility : 0.0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        UnitAI ai = other.GetComponent<UnitAI>();

        if (ai)
        {
            ai.DecreaseHealth(currentDamage);
        }
    }

    void Update()
    {
        currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, lerpSpeed);

        Color c = pollutionDecalRenderer.material.color;
        c.a = currentAlpha;
        pollutionDecalRenderer.material.color = c;
        pollutionDecalRenderer.material.SetFloat("_Curruption_Clip", currentAlpha);
    }
}
