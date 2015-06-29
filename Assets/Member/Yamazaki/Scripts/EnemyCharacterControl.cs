﻿using System;
using UnityEngine;

[RequireComponent(typeof (NavMeshAgent))]
[RequireComponent(typeof (EnemyCharacter))]
public class EnemyCharacterControl : MonoBehaviour
{
	public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
	public EnemyCharacter character { get; private set; } // the character we are controlling
	public Transform target; // target to aim for

	// Use this for initialization
	private void Start()
	{
		// get the components on the object we need ( should not be null due to require component so no need to check )
		agent = GetComponentInChildren<NavMeshAgent>();
		character = GetComponent<EnemyCharacter>();

		agent.updateRotation = false;
		agent.updatePosition = true;

		target = GameObject.FindWithTag ("Player").transform;
	}


	// Update is called once per frame
	private void Update()
	{
		if (target != null)
		{
			agent.SetDestination(target.position);
				
			// use the values to move the character
			character.Move(agent.desiredVelocity);
		}
		else
		{
			// We still need to call the character's move function, but we send zeroed input as the move param.
			character.Move(Vector3.zero);
		}

	}


	public void SetTarget(Transform target)
	{
		this.target = target;
	}
}
