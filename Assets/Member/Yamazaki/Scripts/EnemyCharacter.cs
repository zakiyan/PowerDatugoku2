using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class EnemyCharacter : MonoBehaviour
{
	[SerializeField] float m_MovingTurnSpeed = 360;
	[SerializeField] float m_StationaryTurnSpeed = 180;
		
	Rigidbody m_Rigidbody;
	const float k_Half = 0.5f;
	float m_TurnAmount;
	float m_ForwardAmount;
	bool m_Crouching;
		
		
	void Start()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
			
		m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX |
		                          RigidbodyConstraints.FreezeRotationY | 
				                  RigidbodyConstraints.FreezeRotationZ;

	}
		
	public void Move(Vector3 move)
	{
		if (move.magnitude > 1f)
		{
			move.Normalize ();
		}

		move = transform.InverseTransformDirection(move);
		m_TurnAmount = Mathf.Atan2(move.x, move.z);
		m_ForwardAmount = move.z;
			
		ApplyExtraTurnRotation();
			
	}
		
	void ApplyExtraTurnRotation()
	{
		float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
		transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
	}
}
