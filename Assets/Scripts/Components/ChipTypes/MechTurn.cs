using UnityEngine;
using System.Collections;

public class MechTurn : ChipBase, IRotateHandler
{
	public float angularSpeed { set; get; }

	protected override void Awake ()
	{
		base.Awake();
		angularSpeed = 1.0f;
	}

	public override void ExecuteCommand ()
	{
		RotateObject (Vector3.up);
	}

	public void RotateObject (Vector3 p_v3Rotation)
	{
		this.transform.Rotate(p_v3Rotation * angularSpeed);
	}
}
