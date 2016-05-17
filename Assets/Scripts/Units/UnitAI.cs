using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitAI : MonoBehaviour {

	[SerializeField]
	float unitSpeed = 1f;
    [SerializeField]
    float distanceToWP;
	[SerializeField]
	float animationTime = 1f;
    private List<Vector3> path;

    private int currentWP = 0;
    private int pathLength;
	private bool fighting = false;

    // Use this for initialization
    void Start ()
    {
		
    }
	
	// Update is called once per frame
	void Update ()
    {
        Move ();
		Fight ();
    }

	void Move()
    {
        if (!fighting && pathLength > currentWP)
        {
            Vector3 dirVec = path[currentWP] - transform.position;

			//Quaternion lookRotation = Quaternion.LookRotation(dirVec);
			//transform.rotation = Quaternion.LookRotation(dirVec);

			transform.position += dirVec.normalized * unitSpeed;

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

	void Fight() {
		if (fighting) {
			animationTime -= Time.deltaTime;
			if (animationTime <= 0f) {
				fighting = false;
				Destroy (gameObject);
			}
		}
	}

    public void SetPath(List<Vector3> unitPath)
    {
        path = unitPath;
        pathLength = path.Count;
    }

	void OnCollisionEnter(Collision col) {
		if (col.transform.GetComponent<UnitAI> ())
			fighting = true;
	}
}
