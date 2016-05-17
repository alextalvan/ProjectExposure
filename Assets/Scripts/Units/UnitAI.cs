using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitAI : MonoBehaviour {

	[SerializeField]
	float unitSpeed = 1f;
    //[SerializeField]
    //float maxTurnValue;
    [SerializeField]
    float distanceToWP;
    private List<Vector3> path;
    private Rigidbody rb;

    private int currentWP = 0;
    private int pathLength;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //GetDirection();
        Move();
    }

	void Move()
    {
        if (pathLength > currentWP)
        {
            Vector3 dirVec = path[currentWP] - transform.position;

			transform.position += dirVec.normalized * unitSpeed;
            //float currentTurnValue = maxTurnValue;

            //Quaternion lookRotation = Quaternion.LookRotation(dirVec);
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, currentTurnValue);

			if (dirVec.magnitude <= distanceToWP)
            {
                currentWP++;
                if (pathLength <= currentWP)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

	/*
    void Move()
    {
        //if (rb.velocity.magnitude < 1f)
        //    rb.AddForce(transform.forward * unitSpeed);
    }
*/
    public void SetPath(List<Vector3> unitPath)
    {
        path = unitPath;
        pathLength = path.Count;
    }
}
