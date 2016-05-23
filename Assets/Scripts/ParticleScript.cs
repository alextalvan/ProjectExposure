using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

	[SerializeField]
	float particleSpeed = 1f;
	[SerializeField]
	RectTransform energyBar;
	ParticleSystem particleSys;
	Vector3 velocity;
	Vector3 energyWorldPos;

	float originalSize;
	float originalDist;

	// Use this for initialization
	void Start () {
		particleSys = GetComponent<ParticleSystem>();
		originalSize = particleSys.startSize;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.A))
			Play ();
	}

	void LateUpdate () {
		ParticleSystem.Particle[] p = new ParticleSystem.Particle[particleSys.particleCount+1];
		int l = particleSys.GetParticles(p);

		int i = 0;
		while (i < l) {
			float distance = Vector3.Distance (p[i].position, energyWorldPos);
			p[i].velocity = velocity;
			p[i].startSize = (distance/originalDist + originalSize/originalDist) * originalSize;
			i++;
		}

		particleSys.SetParticles(p, l);    
	}

	void Play() {
		Vector2 energyPos = new Vector2(Camera.main.pixelWidth/2 + energyBar.anchoredPosition.x, Camera.main.pixelHeight/2 + energyBar.anchoredPosition.y);
		energyWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(energyPos.x, energyPos.y, Camera.main.nearClipPlane));
		originalDist = Vector3.Distance (transform.position, energyWorldPos);

		velocity = (energyWorldPos -  transform.position).normalized * particleSpeed;
		particleSys.Play ();
	}
}
