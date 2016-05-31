using UnityEngine;
using System.Collections;

public class ParticleAutoDestruction : MonoBehaviour {

    [SerializeField]
    float time;
    float timer;

    public void Start()
    {
        timer = time;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
