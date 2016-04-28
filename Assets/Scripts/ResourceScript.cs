using UnityEngine;
using System.Collections;

public class ResourceScript : MonoBehaviour {

    private float energy = 0f;
    private float modifier = 1f;

    public float ChangeEnergyModifier { set { modifier += value; } }
    public float EnergyModifier { get { return modifier; } set { modifier = value; } }
    public float Energy { get { return energy; } }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        UpdateEnergy();
    }

    /// <summary>
    /// Update current energy level
    /// </summary>
    void UpdateEnergy()
    {
        if (energy >= 0f && energy < 100f)
            energy += modifier * Time.deltaTime;
    }
}
