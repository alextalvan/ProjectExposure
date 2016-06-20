using UnityEngine;
using UnityEngine.UI;

public class WaveStrengthScript : MonoBehaviour
{
    [SerializeField]
    float lerpSpeed = 5f;
    [SerializeField]
    Vector2 offset;
    [SerializeField]
    Transform lane;
    int strength = 0;
    Text text;
    RectTransform rectt;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        rectt = GetComponent<RectTransform>();
        foreach (Transform unit in lane)
            strength += unit.GetComponent<UnitAI>().Health;
        text.text = strength.ToString();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (strength > 0)
            UpdatePosition(true);
    }

    private void UpdatePosition(bool lerp)
    {
        Vector3 avgPos = Vector3.zero;
        int unitsAlive = 0;
        foreach (Transform unit in lane)
        {
            if (!unit.GetComponent<UnitAI>().Won)
            {
                unitsAlive++;
                avgPos += unit.position;
            }
        }
        if (unitsAlive > 0)
        {
            avgPos /= unitsAlive;
            if (lerp)
                rectt.position = Vector3.Lerp(rectt.position, new Vector3(avgPos.x + offset.x, avgPos.y + offset.y, 0), Time.deltaTime * lerpSpeed);
            else
                rectt.position = new Vector3(avgPos.x + offset.x, avgPos.y + offset.y, 0);
        }
    }

    public void UpdateStrength(bool lerp)
    {
        strength = 0;
        foreach (Transform unit in lane)
            strength += unit.GetComponent<UnitAI>().Health;
        text.text = strength.ToString();
        if (strength <= 0)
        {
            text.enabled = false;
            rectt.position = Vector3.zero;
        }
        else
        {
            text.enabled = true;
            UpdatePosition(lerp);
        }
    }
}
