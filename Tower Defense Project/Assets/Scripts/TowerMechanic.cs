using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMechanic : MonoBehaviour {

	public List<GameObject> ListOfObjectsInRange = new List<GameObject> ();
	public List<float> Distances = new List<float> ();
	public GameObject Target;
	public float speed;

	Transform Rotator;

	void Start () {
		Rotator = transform.Find ("Rotator");
	}

	void Update() {
		
		// Rotator => rotate tower towards target
		if (Target != null) {
			Vector3 targetDir = Target.transform.position - Rotator.position;
			float step = speed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(Rotator.forward, new Vector3(targetDir.x, 0, targetDir.z), step, 0.0F);
			Rotator.rotation = Quaternion.LookRotation(newDir);
		}

		// Set new Target
		if (ListOfObjectsInRange.Count > 0 && Target == null) {
			Target = ListOfObjectsInRange [0];
		}

		// Get all distances
		Distances.Clear ();
		foreach (GameObject gameObject in ListOfObjectsInRange) {
			if (gameObject == null) {
				ListOfObjectsInRange.Remove (gameObject);
				return;
			}
			Distances.Add ((gameObject.transform.position - transform.position).magnitude);
		}
	}

	void FixedUpdate()
	{
		
	}

	//--------------------------------------------------------------
	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag == "Enemy")
			ListOfObjectsInRange.Add (collider.gameObject);
	}

	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.tag == "Enemy")
			ListOfObjectsInRange.Remove (collider.gameObject);

		if (ListOfObjectsInRange.Count == 0)
			Target = null;

		if (collider.gameObject == Target)
			Target = null;
	}
}




// Raycast
/*	Vector3 fwd = transform.TransformDirection(Vector3.forward);
	RaycastHit hit;

	if (Physics.Raycast(transform.position, fwd, out hit, 10))
		print(hit.collider.gameObject.name);
*/