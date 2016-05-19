using UnityEngine;
using System.Collections;

public class SpawnPointTrigger : MonoBehaviour {

	private bool colliding = false;
	private bool available = true;

	public bool Available { get { return available; } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (colliding)
			available = false;
		else
			available = true;
		colliding = false;
	}

	void OnTriggerStay(Collider col) {
		colliding = true;
	}
}
