using UnityEngine;
using System.Collections;

public class MechTurn : ChipBase, IRotateHandler
{
	[SerializeField] public float m_fAngularSpeed;

	protected void Awake ()
	{
		m_fAngularSpeed = 3.0f;
	}

	public override void ExecuteCommand ()
	{
		RotateObject (Vector3.up);
	}

	public void RotateObject (Vector3 p_v3Rotation)
	{
		this.transform.Rotate(p_v3Rotation * m_fAngularSpeed);
	}
}
