/*
 * Brian Tria
 * July 15, 2015
 * 
 */

using UnityEngine;
using System.Collections;

public class MechMoveForward : ChipBase <MechMoveForward>, IMoveHandler, IRotateHandler
{
	public float linearSpeed { get; set; }
	public float rotationSpeed { get; set; }
	public Transform movableObject { get; set; }
	public Rigidbody movableRigidBody { get; set; }

	protected void Awake ()
	{
		linearSpeed = 0.0f;
		rotationSpeed = 0.0f;
		movableObject = null;
		movableRigidBody = null;
	}

	public override void Create (GameObject p_objMech)
	{
		base.Create(p_objMech);
		linearSpeed = 3.0f;
		movableObject = m_objBody.transform;
		movableRigidBody = m_objMech.GetComponent<Rigidbody>();
	}

	public override void ExecuteCommand ()
	{

	}
	
	public void MoveObject (Vector3 p_v3Direction)
	{
		if(movableRigidBody)
		{
			movableRigidBody.AddForce(p_v3Direction * linearSpeed, ForceMode.Acceleration);
		}
	}
}
