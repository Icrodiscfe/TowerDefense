using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonMechanics : MonoBehaviour {

	public GameObject Bullet;
	public float FireRate = 60f;
	public List<GameObject> ListOfObjectsInRange = new List<GameObject> ();

	bool fire;
	float refireTime, deltaFireTime;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// Calculate refire time
		refireTime = 60 / FireRate;

		// Check if target is in aim direction
		foreach (GameObject gameObject in ListOfObjectsInRange)
			if (gameObject == null) {
				ListOfObjectsInRange.Remove (gameObject);
				return;
			}
		//	else
		//		fire = this.GetComponentInParent<TowerMechanic> ().Target == gameObject;

		if (ListOfObjectsInRange.Count == 0)
			fire = false;

		// Fire bullet
		if (fire && deltaFireTime > refireTime) {
			Instantiate (Bullet, transform.position, transform.rotation);
			deltaFireTime = 0f;
		}

		deltaFireTime += Time.deltaTime;
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag == "Enemy")
			ListOfObjectsInRange.Add (collider.gameObject);
	}

	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.tag == "Enemy")
			ListOfObjectsInRange.Remove (collider.gameObject);
	}
}
