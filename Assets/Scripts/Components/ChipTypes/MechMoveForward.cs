/*
 * Brian Tria
 * July 15, 2015
 * 
 */

using UnityEngine;
using System;

public class MechMoveForward : ChipBase <MechMoveForward>, IMoveHandler, IRotateHandler
{
	public float linearSpeed { get; set; }
	public float rotationSpeed { get; set; }
	public Rigidbody movableRigidBody { get; set; }

	protected void Awake ()
	{
		linearSpeed = 0.0f;
		rotationSpeed = 0.0f;
		movableRigidBody = null;
	}

	public override void AttachTo (GameObject p_objMech)
	{
		base.AttachTo(p_objMech);
		linearSpeed = 3.0f;
		movableRigidBody = p_objMech.GetComponent<Rigidbody>();
	}

	public override void ExecuteCommand ()
	{
		MoveObject(Vector3.forward * (-1));
	}
	
	public void MoveObject (Vector3 p_v3Direction)
	{
		if(movableRigidBody)
		{
			movableRigidBody.AddForce(p_v3Direction * linearSpeed, ForceMode.Acceleration);
		}
	}
}
