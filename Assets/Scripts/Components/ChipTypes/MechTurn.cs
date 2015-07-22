using UnityEngine;
using System.Collections;

public class MechTurn : ChipBase, IRotateHandler
{
	[SerializeField] public float m_fAngularSpeed;
	private GameObject m_objMechCabin;

	protected void Awake ()
	{
		m_fAngularSpeed = 3.0f;
		m_objMechCabin = this.GetComponent<ChipManager>().mechCabin;
	}

	public override void ExecuteCommand ()
	{
		RotateObject (Vector3.up);
	}

	public void RotateObject (Vector3 p_v3Rotation)
	{
		if(m_objMechCabin == null) { return; }
		m_objMechCabin.transform.Rotate(p_v3Rotation * m_fAngularSpeed);
	}
}
