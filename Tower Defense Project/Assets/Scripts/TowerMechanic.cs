using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMechanic : MonoBehaviour {

	public Transform Rotator;
	public float RotatorSpeed = 10.0f;
	public float FireRange = 100.0f;

	GameObject Target;

	void Update() {
		
		if (Target == null) {
			Target = FindClosestEnemy (FireRange);
		} else {
			Vector3 targetDir = Target.transform.position - Rotator.position;
			float step = RotatorSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards (Rotator.forward, new Vector3 (targetDir.x, 0, targetDir.z), step, 0.0F);
			Rotator.rotation = Quaternion.LookRotation (newDir);
		}
	}

	public GameObject FindClosestEnemy(float distance)
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
}