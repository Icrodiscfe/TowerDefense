using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMechanic : MonoBehaviour {

	public Transform Rotator;
	public float RotatorSpeed = 10.0f;
	public float FireRange = 10.0f;
	public float FireCooldown = 1.0f;
	public Material BadMat, GoodMat;
	public bool CreatingModeActive, CreatingAllowed;

	GameObject Target;
	ParticleSystem particleSystem;
	bool targeted;
	Transform rotatorIdleTransform;

	void Start () {
		particleSystem = transform.Find ("Head/Particle System").GetComponent<ParticleSystem> ();
		rotatorIdleTransform = Rotator;
	}


	void Update() {
		CreatingMode (CreatingModeActive);
		if (CreatingModeActive)
			return;
		
		Fire ();

		if (Target == null) {
			Target = FindClosestEnemy (FireRange, "Enemy");
			targeted = false;

			Vector3 targetDir = new Vector3(rotatorIdleTransform.position.x, rotatorIdleTransform.position.y, rotatorIdleTransform.position.z + 1) - Rotator.position;
			float step = RotatorSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(Rotator.forward, targetDir, step, 0.0F);
			Debug.DrawRay(Rotator.position, newDir, Color.red);
			Rotator.rotation = Quaternion.LookRotation(newDir);
		} else {
			Vector3 targetDir = Target.transform.position - Rotator.position;
			float step = RotatorSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards (Rotator.forward, new Vector3 (targetDir.x, 0, targetDir.z), step, 0.0F);

			// Rotate turret towards Target
			Rotator.rotation = Quaternion.LookRotation (newDir);

			// Check if turret is already pointing at Target
			targeted = targetDir == Rotator.transform.forward;

			Ray ray = new Ray(Rotator.position, Rotator.forward);
			RaycastHit hit;

			targeted = Physics.Raycast (ray, out hit, FireRange);
			if (targetDir.magnitude > FireRange)
				Target = null;
		}

	}

	public GameObject FindClosestEnemy(float distance, string name)
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag(name);
		GameObject closest = null;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			if (go != this.gameObject) {
				Vector3 diff = go.transform.position - transform.position;
				float curDistance = diff.magnitude;
				if (curDistance < distance) {
					closest = go;
					distance = curDistance;
				}
			}
		}
		return closest;
	}

	float fireCooldown;
	void Fire () {
		if (FireCooldown > fireCooldown)
			fireCooldown += Time.deltaTime;

		if (!particleSystem.isPlaying && FireCooldown <= fireCooldown && targeted) {
			fireCooldown = 0.0f;
			particleSystem.Play ();
		}
		if (!targeted)
			particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
	}

	void CreatingMode(bool creatingModeactive) {
		if (creatingModeactive && FindClosestEnemy (0.9f, "Turret") == null) {
			transform.Find ("Head").GetComponent<MeshRenderer> ().material = GoodMat;
			transform.Find ("Body").GetComponent<MeshRenderer> ().material = GoodMat;
			CreatingAllowed = true;
		}
		if (creatingModeactive && FindClosestEnemy (0.9f, "Turret") != null) {
			transform.Find ("Head").GetComponent<MeshRenderer> ().material = BadMat;
			transform.Find ("Body").GetComponent<MeshRenderer> ().material = BadMat;
			CreatingAllowed = false;
		}
	}

}