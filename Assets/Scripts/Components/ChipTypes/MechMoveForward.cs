/*
 * Brian Tria
 * July 15, 2015
 * 
 */

using UnityEngine;
using System;

public class MechMoveForward : ChipBase, IMoveHandler
{
	[SerializeField] private float m_fLinearSpeed;
	public Rigidbody movableRigidBody { get; set; }
	private GameObject m_objMechCabin;

	protected void Awake ()
	{
		m_fLinearSpeed = 20.0f;
		movableRigidBody = this.GetComponent<Rigidbody>();
		m_objMechCabin = this.GetComponent<ChipManager>().mechCabin;
	}

	public override void ExecuteCommand ()
	{
		MoveObject(m_objMechCabin.transform.TransformDirection(Vector3.forward * (-1)));
	}
	
	public void MoveObject (Vector3 p_v3Direction)
	{
		if(movableRigidBody)
		{
			movableRigidBody.AddRelativeForce(p_v3Direction * m_fLinearSpeed, ForceMode.Acceleration);
		}
	}
}
