using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMechanic : MonoBehaviour {

	[Header("Unity Setup Fields")]
	public Transform PartToRotateHorizontal;
	public Transform PartToRotateVertical;
	public Material BadMat, GoodMat;
	public Transform FirePoint;
	public GameObject BulletPrefab;


	[Header("Attributes")]
	public float TurnSpeed = 30f;
	public float FireRangeMax = 10f;
	public float FireRangeMin = 2f;
	public float FireRate = 1f;

	[Header("Scripting Interface")]
	public bool CreatingModeActive;
	public bool CreatingAllowed;

	GameObject Target;
	bool targeted;
	Quaternion partToRotateHorizontalIdle, partToRotateVerticalIdle;
	float fireCooldown;
	Animator anim;

	void Start () {
		partToRotateHorizontalIdle = PartToRotateHorizontal.rotation;
		partToRotateVerticalIdle = PartToRotateVertical.rotation;
		anim = GetComponent<Animator> ();

	}


	void Update() {
		CreatingMode (CreatingModeActive);
		if (CreatingModeActive)
			return;

		if (Target == null) {
			Target = FindClosestEnemy (FireRangeMax, "Enemy");
			targeted = false;


			// If no Target, rotate to default position
			// Get default direction
			Quaternion lookRotationH = partToRotateHorizontalIdle;
			Quaternion lookRotationV = partToRotateVerticalIdle;
			// Rotate Horizontal to Target direction
			Vector3 rotationH = Quaternion.RotateTowards(PartToRotateHorizontal.rotation, lookRotationH, TurnSpeed * Time.deltaTime).eulerAngles;
			PartToRotateHorizontal.rotation = Quaternion.Euler (0f, rotationH.y, 0f);
			// Rotate Vertical to Target direction
			Vector3 rotationV = Quaternion.RotateTowards(PartToRotateVertical.rotation, lookRotationV, Time.deltaTime * TurnSpeed).eulerAngles;
			PartToRotateVertical.rotation = Quaternion.Euler (rotationV.x, rotationH.y, 0f);
		} else {
			// Get Target direction
			Transform ShootPoint = Target.transform.Find ("ShootPoint").transform;
			Vector3 dir = Target.transform.position - PartToRotateVertical.position;
			Quaternion lookRotation = Quaternion.LookRotation (dir);
			// Rotate Horizontal to Target direction
			//Vector3 rotationH = Quaternion.Lerp (PartToRotateHorizontal.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
			Vector3 rotationH = Quaternion.RotateTowards(PartToRotateHorizontal.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
			PartToRotateHorizontal.rotation = Quaternion.Euler (0f, rotationH.y, 0f);
			// Rotate Vertical to Target direction
			Vector3 rotationV = Quaternion.RotateTowards(PartToRotateVertical.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
			PartToRotateVertical.rotation = Quaternion.Euler (rotationV.x, rotationH.y, 0f);


			Ray ray = new Ray(FirePoint.position, FirePoint.forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, FireRangeMax))
				targeted = hit.collider.name.Contains ("Enemy");


			if (targeted)
				Debug.DrawLine (FirePoint.position, hit.point, Color.green);
			else
				Debug.DrawLine (FirePoint.position, hit.point, Color.red);



			if (dir.magnitude > FireRangeMax)
				Target = null;


			if (fireCooldown <= 0f && targeted && dir.magnitude > FireRangeMin && Target != null) {
				Shoot ();
				fireCooldown = 1f / FireRate;
			}

			fireCooldown -= Time.deltaTime;
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

	void Shoot () {
		anim.Play ("MyTurret001Anim001");
		GameObject bulletGO = (GameObject)Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
			bullet.Seek(Target.transform);
	}

	bool iniCreatingModeDone;
	List<Material> listMaterials = new List<Material>();
	void CreatingMode(bool creatingModeactive) {
		if (!iniCreatingModeDone) {
			MeshRenderer[] allMeshRenderer = transform.GetComponentsInChildren<MeshRenderer> ();
			foreach (MeshRenderer meshRen in allMeshRenderer) {
				listMaterials.Add (meshRen.material);
			}
			iniCreatingModeDone = true;
		}

		if (creatingModeactive && FindClosestEnemy (2.5f, "Turret") == null) {
			int x = 0;
			MeshRenderer[] allMeshRenderer = transform.GetComponentsInChildren<MeshRenderer> ();
			foreach (MeshRenderer meshRen in allMeshRenderer) {
				meshRen.material = listMaterials[x];
				x++;
			}
			CreatingAllowed = true;
		}

		if (creatingModeactive && FindClosestEnemy (2.5f, "Turret") != null) {
			MeshRenderer[] allMeshRenderer = transform.GetComponentsInChildren<MeshRenderer> ();
			foreach (MeshRenderer meshRen in allMeshRenderer) {
				meshRen.material = BadMat;
			}
			CreatingAllowed = false;
		}
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (transform.position, FireRangeMax);
		Gizmos.DrawWireSphere (transform.position, FireRangeMin);
	}
}