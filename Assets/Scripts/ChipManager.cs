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
	[SerializeField] private GameObject m_objMech;
	[SerializeField] private GameObject m_objBody;
	[SerializeField] private GameObject m_objHatch;

	MoveComponent moveComponent;

	// create new chip
	// addcomponent(chip)
	void Start ()
	{
		moveComponent = gameObject.AddComponent<MoveComponent>();
		moveComponent.LinearSpeed = 3.0f;
		moveComponent.MovableObject = m_objBody.transform;
		moveComponent.MovableRigidBody = m_objMech.GetComponent<Rigidbody>();
	}

	void LateUpdate ()
	{
		//moveComponent.MovableRigidBody = m_objMech.GetComponent<Rigidbody>();
		moveComponent.MoveRigidBody(Vector3.forward * (-1));
	}
}
