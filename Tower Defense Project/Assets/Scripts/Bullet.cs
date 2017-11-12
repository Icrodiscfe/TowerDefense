using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float BulletSpeed = 100f;

	void Start () {
		Invoke ("LifeTime", 1.0f);
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag == "Enemy") {
			collider.GetComponent<Enemy> ().GetDamage (10f);
			Destroy (this.gameObject);
		}
	}

	void LifeTime () {
		Destroy (this.gameObject);
	}

	void FixedUpdate () {
		transform.Translate (Vector3.forward * BulletSpeed * Time.deltaTime);
	}
}
