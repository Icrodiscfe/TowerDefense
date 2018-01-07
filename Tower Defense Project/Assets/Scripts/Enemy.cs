using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	public Slider Healthbar;
	public bool DisableAutoMovement;
	public float MaxHealth;
	public int Bounty;

	GameControl gameControl;
	float currentHealth;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.Find ("GameController").GetComponent<GameControl> ();
		currentHealth = MaxHealth;

		// Auto "Enemy" movement
		if (!DisableAutoMovement && currentHealth > 0) {
			NavMeshAgent agent = GetComponent<NavMeshAgent> ();
			Vector3 destination = new Vector3 (transform.position.x, transform.position.y, transform.position.z + -40);
			agent.destination = destination; 
		}
	}
		
	void Update () {
		// Rotate GUI to camera
		transform.Find ("GUI").rotation = Camera.main.transform.rotation;

		float healthbarValue = Mathf.InverseLerp (0, MaxHealth, currentHealth);
		Healthbar.value = healthbarValue;

		// Destroy
		if (currentHealth == 0) {
			Destroy (this.gameObject);
			gameControl.Gold += Bounty;
		}


	}

	public void GetDamage (float amount) {
		if (currentHealth >= amount)
			currentHealth -= amount;
		else
			currentHealth = 0f;
	}
}
