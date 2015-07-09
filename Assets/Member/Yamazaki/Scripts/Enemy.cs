using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof (NavMeshAgent))]
[RequireComponent(typeof (CapsuleCollider))]
public class Enemy : MonoBehaviour {
	public Transform[] wayPoints;
	public int currentRoot;

	public GameObject target;

	public float walkSpeed = 2.0f;
	public float runSpeed = 3.5f;
	public float encountDistance = 50f;
	public float escapeDistance = 100f;
	public float escapeTime = 5.0f;
	float countTime = 0f;

	public float fieldOfViewAngle = 180f;

	NavMeshAgent agent;
	Animator animator;

	bool hasPatrol = true;

	Vector3 initialDirection;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponentInChildren<Animator> ();

		agent.speed = walkSpeed;

		if (wayPoints.Length == 0 || !wayPoints[0]) {
			initialDirection = transform.position;
		}

	}
	
	// Update is called once per frame
	void Update () {

		//プレイヤーと敵の位置の差
		Vector3 direction = target.transform.position - transform.position;
		float angle = Vector3.Angle(direction, transform.forward);

		//索敵
		if (angle < fieldOfViewAngle * 0.5f) {
			
			RaycastHit hit;
			
			if (Physics.Raycast (transform.position + transform.up, direction.normalized, out hit, 10)) {
				
				if (hit.collider.gameObject == target) {
					
					// playerを視界に捉えた
					if (direction.sqrMagnitude < encountDistance) {
						//エンカウント距離内に入った
						hasPatrol = false;
						agent.speed = runSpeed;
						animator.SetBool("Angry",true);
						countTime = 0f;
					} else {
						if (!hasPatrol) {
							hasPatrol = false;
							animator.SetBool("Angry",true);
							countTime = 0f;
						}
					}

				} else {
					// playerの視界を遮る物を捉えた
					if (!hasPatrol) {
						countTime += Time.deltaTime;

					}
				}
			}
		} else {
			if (!hasPatrol & (direction.sqrMagnitude > escapeDistance)) {
				countTime += Time.deltaTime;

			}
		}
		if (countTime >= escapeTime){
			//逃げ判定距離外に出た
			hasPatrol = true;
			agent.speed = walkSpeed;
			animator.SetBool("Angry",false);
			currentRoot = 0;
			countTime = 0f;
		}

		//行動 hasPatrol true:パトロール false:エンカウント 
		if (hasPatrol) {

			if (wayPoints.Length == 0 || !wayPoints[0]) {
				agent.SetDestination (initialDirection);
			}else{

				Vector3 pos = wayPoints [currentRoot].position;

				if (Vector3.Distance (transform.position, pos) < 1f) {
					currentRoot = (currentRoot < wayPoints.Length - 1) ? currentRoot + 1 : 0;
				}

			agent.SetDestination (pos);
			}
		
		} else {
			agent.destination = target.transform.position;
		}

	}
}