using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitAI : MonoBehaviour {

	[SerializeField]
	float unitSpeed = 1f;
    [SerializeField]
    float maxTurnValue;
    [SerializeField]
    float distanceToPath;
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
        GetDirection();
        Move();
    }

    void GetDirection()
    {
        if (pathLength > currentWP)
        {
            Vector3 dirVec = new Vector3(path[currentWP].x, transform.position.y, path[currentWP].z) - transform.position;

            float currentTurnValue = maxTurnValue;

            Quaternion lookRotation = Quaternion.LookRotation(dirVec);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, currentTurnValue * Time.deltaTime);
           // transform.Translate(dirVec.normalized * 0.1f);

            if (dirVec.magnitude <= distanceToPath)
            {
                currentWP++;
                if (pathLength <= currentWP)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void Move()
    {
        if (rb.velocity.magnitude < unitSpeed/5)
            rb.AddForce(transform.forward * unitSpeed);
    }

    public void SetPath(List<Vector3> unitPath)
    {
        path = unitPath;
        pathLength = path.Count;
    }

	public void SetTarget(Transform target) {

	}
}
