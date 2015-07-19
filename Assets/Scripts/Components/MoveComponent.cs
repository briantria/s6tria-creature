/*
 * Brian Tria
 * July 15, 2015
 * 
 */

using UnityEngine;
using System.Collections;

public class MoveComponent : MonoBehaviour 
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

	public void Move (Vector3 p_v3Direction)
	{
		if(movableObject)
		{
			movableObject.Translate(p_v3Direction * linearSpeed);
		}
	}

	public void MoveRigidBody (Vector3 p_v3Direction)
	{
		if(movableRigidBody)
		{
			movableRigidBody.AddForce(p_v3Direction * linearSpeed, ForceMode.Acceleration);
		}
	}

	public void Rotate ()
	{

	}
}
