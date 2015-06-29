using System;
using UnityEngine;

[RequireComponent(typeof (NavMeshAgent))]
[RequireComponent(typeof (EnemyCharacter))]
public class EnemyCharacterControl : MonoBehaviour
{
	public NavMeshAgent agent
	{
		get;
		private set;
	} 

	public EnemyCharacter character
	{
		get;
		private set;
	} 

	public Transform target; 

	private void Start()
	{
		agent = GetComponentInChildren<NavMeshAgent>();
		character = GetComponent<EnemyCharacter>();

		agent.updateRotation = false;
		agent.updatePosition = true;

		target = GameObject.FindWithTag ("Player").transform;
	}

	private void Update()
	{
		if (target != null)
		{
			agent.SetDestination(target.position);
				
			character.Move(agent.desiredVelocity);
		}
		else
		{
			character.Move(Vector3.zero);
		}

	}


	public void SetTarget(Transform target)
	{
		this.target = target;
	}
}
