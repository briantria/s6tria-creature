/*
 * Brian Tria
 * July 15, 2015
 * 
 * ChipManager acts as the central processing unit of the mecha unit
 * 
 */

using UnityEngine;
using System.Collections;

public class ChipManager : MonoBehaviour 
{
	[SerializeField] private GameObject m_objBody;
	[SerializeField] private GameObject m_objHatch;

	private GameObject m_objMech;
	private MoveComponent m_moveComponent;

	// create new chip
	// addcomponent(chip)
	protected void Start ()
	{
		m_objMech = this.gameObject;

		m_moveComponent = gameObject.AddComponent<MoveComponent>();
		m_moveComponent.linearSpeed = 3.0f;
		m_moveComponent.movableObject = m_objBody.transform;
		m_moveComponent.movableRigidBody = m_objMech.GetComponent<Rigidbody>();
	}

	protected void LateUpdate ()
	{
		//moveComponent.MovableRigidBody = m_objMech.GetComponent<Rigidbody>();
		m_moveComponent.MoveRigidBody(Vector3.forward * (-1));
	}
}
