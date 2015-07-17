/*
 * Brian Tria
 * July 15, 2015
 * 
 */

using UnityEngine;
using System.Collections;

public class MoveComponent : MonoBehaviour 
{
	public float LinearSpeed { get; set; }
	public float RotationSpeed { get; set; }
	public Transform MovableObject { get; set; }
	public Rigidbody MovableRigidBody { get; set; }

	protected void Awake ()
	{
		LinearSpeed = 0.0f;
		RotationSpeed = 0.0f;
		MovableObject = null;
		MovableRigidBody = null;
	}

	public void Move (Vector3 p_v3Direction)
	{
		if(MovableObject)
		{
			MovableObject.Translate(p_v3Direction * LinearSpeed);
		}
	}

	public void MoveRigidBody (Vector3 p_v3Direction)
	{
		if(MovableRigidBody)
		{
			MovableRigidBody.AddForce(p_v3Direction * LinearSpeed, ForceMode.Acceleration);
		}
	}

	public void Rotate ()
	{

	}
}
