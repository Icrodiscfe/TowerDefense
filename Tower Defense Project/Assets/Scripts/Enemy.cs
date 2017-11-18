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

		// Auto "Enemy" movement
		if (!DisableAutoMovement) {
			NavMeshAgent agent = GetComponent<NavMeshAgent> ();
			Transform End = GameObject.Find ("End").transform;
			Vector3 destination = new Vector3 (End.position.x + transform.position.x, End.position.y, End.position.z);
			agent.destination = destination; 
		}
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
	}

	public void GetDamage (float amount) {
		if (currentHealth >= amount)
			currentHealth -= amount;
		else
			currentHealth = 0f;
	}

	void OnParticleCollision () {
		GetDamage (10);
	}
}
