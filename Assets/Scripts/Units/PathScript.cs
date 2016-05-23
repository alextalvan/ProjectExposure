using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathScript : MonoBehaviour
{
    public Color gizmosColor = Color.blue;

    void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;

        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 pos = transform.GetChild(i).position;

            if (i > 0)
            {
                Vector3 prev = transform.GetChild(i - 1).position;
                Gizmos.DrawLine(prev, pos);
                Gizmos.DrawSphere(pos, 0.5f);
            }
            else if (i == 0)
            {
                Gizmos.DrawSphere(pos, 0.5f);
            }
        }
    }

    void Start()
    {
		
    }

    void Update()
    {

    }
}
