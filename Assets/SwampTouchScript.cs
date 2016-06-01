using UnityEngine;
using System.Collections;

public class SwampTouchScript : MonoBehaviour
{
    [SerializeField]
    int tapCountForUndo = 1;
    int currentTapCount;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

#if TOUCH_INPUT
	void PenetratingTouchEnd()
#else
    void OnMouseUp()
#endif
    {
        currentTapCount++;

        if (currentTapCount == tapCountForUndo)
            transform.parent.GetComponent<SwampSpot>().ToggleOff();
    }
}
