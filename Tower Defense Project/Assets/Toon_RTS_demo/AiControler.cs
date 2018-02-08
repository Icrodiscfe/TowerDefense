using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiControler : MonoBehaviour {

	public float AttackDistance, AttackRate;

	private Animator anim;
	private NavMeshAgent navMeshAgent;
	private Transform targetedEnemy = null;
	private bool walking;
	private float nextAttack;


	AnimatorClipInfo[] m_CurrentClipInfo;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () 
	{
		MoveAndAttack();

		if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
			if (!navMeshAgent.hasPath || Mathf.Abs (navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
				walking = false;
		} else {
			walking = true;
		}

		anim.SetBool ("IsWalking", walking);

		if (targetedEnemy == null)
			targetedEnemy = FindClosestEnemy (6f, "Player").transform;

	}

	private void MoveAndAttack()
	{
		if (targetedEnemy == null)
			return;

		m_CurrentClipInfo = anim.GetCurrentAnimatorClipInfo (0);
		Debug.Log (m_CurrentClipInfo [0].clip.name);
		Debug.Log (navMeshAgent.isStopped);

		navMeshAgent.destination = targetedEnemy.position;
		if (navMeshAgent.remainingDistance >= AttackDistance) {
			if (m_CurrentClipInfo [0].clip.name != "WK_heavy_infantry_08_attack_B") {
				navMeshAgent.isStopped = false;
				walking = true;
			}
		}

		if (navMeshAgent.remainingDistance <= AttackDistance) {
			anim.SetBool ("IsAttacking", false);
			transform.LookAt(targetedEnemy);
			Vector3 dirToAttack = targetedEnemy.transform.position - transform.position;
			if (Time.time > nextAttack)
			{
				nextAttack = Time.time + AttackRate;
				anim.SetBool ("IsAttacking", true);
			}
			navMeshAgent.isStopped = true;
			walking = false;
		}
	}

	public GameObject FindClosestEnemy(float _distance, string _tag)
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag(_tag);
		GameObject closest = null;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			if (go != this.gameObject) {
				Vector3 diff = go.transform.position - transform.position;
				float curDistance = diff.magnitude;
				if (curDistance < _distance) {
					closest = go;
					_distance = curDistance;
				}
			}
		}
		return closest;
	}
}
