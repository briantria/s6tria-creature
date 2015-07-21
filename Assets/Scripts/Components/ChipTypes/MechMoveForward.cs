/*
 * Brian Tria
 * July 15, 2015
 * 
 */

using UnityEngine;
using System;

public class MechMoveForward : ChipBase, IMoveHandler
{
	public float linearSpeed { get; set; }
	public Rigidbody movableRigidBody { get; set; }

	protected void Awake ()
	{
		linearSpeed = 3.0f;
		movableRigidBody = this.gameObject.GetComponent<Rigidbody>();
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
