using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	public bool DisableAutoMovement = false;
	public float MaxHealth = 100f;

	float currentHealth;
	Image Healthbar;

	// Use this for initialization
	void Start () {
		currentHealth = MaxHealth;

		Healthbar = transform.Find ("GUI/Healthbar").GetComponent<Image> ();


	}
		
	void Update () {
		// Rotate GUI to camera
		transform.Find ("GUI").rotation = Camera.main.transform.rotation;

		float scale = Mathf.InverseLerp (0, MaxHealth, currentHealth);
		float sizeDeltaX = 120f * scale;
		float posDeltaX = (120f - sizeDeltaX) / 2;

		Vector2 newSize = new Vector2 (sizeDeltaX, Healthbar.rectTransform.sizeDelta.y);
		Vector2 newPos = new Vector2 (posDeltaX, Healthbar.rectTransform.localPosition.y);
		Healthbar.rectTransform.sizeDelta = newSize;
		Healthbar.rectTransform.localPosition = newPos;

		// Destroy
		if (currentHealth == 0)
			Destroy (this.gameObject);

		// Auto "Enemy" movement
		if (!DisableAutoMovement && currentHealth > 0) {
			NavMeshAgent agent = GetComponent<NavMeshAgent> ();
			Vector3 destination = new Vector3 (transform.position.x, transform.position.y, transform.position.z + -5);
			agent.destination = destination; 
		}
	}

	public void GetDamage (float amount) {
		if (currentHealth >= amount)
			currentHealth -= amount;
		else
			currentHealth = 0f;
	}

	void OnParticleCollision (GameObject other) {
		GetDamage (25);
		// Finde object -> Partikel System und Stop()
		other.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
	}
}
