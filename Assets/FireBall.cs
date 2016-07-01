using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    private float flightTime = 1f;
    public Transform target;
    private Vector3 targetPoint;
    private Vector3 launchPosition;
    private float startTime;
    [SerializeField]
    GameObject particle;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        targetPoint = target.position;
        launchPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FlyTowardsTarget();
    }

    private void FlyTowardsTarget()
    {
        if (target)
            targetPoint = target.position;
        
        Vector3 center = (launchPosition + targetPoint) * 0.5f;
        center.y -= Vector3.Distance(launchPosition, targetPoint) * 0.5f;
        Vector3 centerToLaunchPtVec = launchPosition - center;
        Vector3 centerToTargetVec = targetPoint - center;
        float fracComplete = (Time.time - startTime) / flightTime;
        transform.position = center + Vector3.Slerp(centerToLaunchPtVec, centerToTargetVec, fracComplete);
    }

    void OnCollisionEnter(Collision col)
    {
        UnitAI unit = col.transform.GetComponent<UnitAI>();
        HexagonTile tile = col.transform.GetComponent<HexagonTile>();

        if (unit)
            unit.DecreaseHealth(99999);
        else if (tile)
            tile.DestroyBuilding();

        //Instantiate(particle, transform.position, Random.rotation);
        Destroy(gameObject);
    }
}
