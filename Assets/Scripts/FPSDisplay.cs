using UnityEngine;


public class FPSDisplay : MonoBehaviour
{
    float timeAccumulator;
    int frameRate = 0;
    int count;
    bool enabled = false;

    void Update()
    {
        if (!enabled && Input.GetKeyDown(KeyCode.F))
            enabled = true;
        else if (enabled && Input.GetKeyDown(KeyCode.F))
            enabled = false;

        count++;
        timeAccumulator += Time.deltaTime;

        if (timeAccumulator >= 1.0f)
        {
            timeAccumulator -= 1.0f;
            frameRate = count;
            count = 0;
        }
    }

    void Start()
    {
        timeAccumulator = 0;
        count = 0;
    }

    void OnGUI()
    {
        if (enabled)
        {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
            //float fps = 1.0f / deltaTime;
            //string text = string.Format("({0:0.} fps)", frameRate);
            string text = "FPS: " + frameRate.ToString();
            GUI.Label(rect, text, style);
        }
    }
}