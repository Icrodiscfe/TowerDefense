using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class SpielerControler : MonoBehaviour {
	public float AttackDistance, AttackRate;

	private Animator anim;
	private NavMeshAgent navMeshAgent;
	private Transform targetedEnemy;
	private bool walking;
	private bool enemyClicked;
	private float nextAttack;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetKeyDown(KeyCode.Mouse0) & EventSystem.current.currentSelectedGameObject == null) 
		{
			if (Physics.Raycast(ray, out hit, 100))
			{
				if (hit.collider.CompareTag("Enemy"))
				{
					targetedEnemy = hit.transform;
					enemyClicked = true;
				}

				else
				{
					walking = true;
					enemyClicked = false;
					navMeshAgent.destination = hit.point;
					navMeshAgent.isStopped = false;
				}
			}
		}

		if (enemyClicked) {
			MoveAndAttack();
		}

		if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
			if (!navMeshAgent.hasPath || Mathf.Abs (navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
				walking = false;
		} else {
			walking = true;
		}

		anim.SetBool ("IsWalking", walking);
	}

	private void MoveAndAttack()
	{
		if (targetedEnemy == null)
			return;
		navMeshAgent.destination = targetedEnemy.position;
		if (navMeshAgent.remainingDistance >= AttackDistance) {

			navMeshAgent.isStopped = false;
			walking = true;
		}

		if (navMeshAgent.remainingDistance <= AttackDistance) {

			transform.LookAt(targetedEnemy);
			Vector3 dirToAttack = targetedEnemy.transform.position - transform.position;
			if (Time.time > nextAttack)
			{
				nextAttack = Time.time + AttackRate;
				//shootingScript.Shoot(dirToShoot);
			}
			navMeshAgent.isStopped = true;
			walking = false;
		}
	}

}
