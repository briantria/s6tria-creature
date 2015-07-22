using UnityEngine;
using System.Collections;

public class MechScanBasic : ChipBase, IRotateHandler
{
	[SerializeField] private float m_fRange = 25.0f; // serialized for easier testing
	private GameObject m_objMechHatch;
	private MechShootBasic m_shootBasic;

	public float angularSpeed { set; get; }
	
	protected void Awake ()
	{
		angularSpeed = 3.0f;
		m_objMechHatch = this.GetComponent<ChipManager>().mechHatch;
		m_shootBasic = this.GetComponent<MechShootBasic>(); // TODO: should handle multiple cannon/shooters
	}

	public override void ExecuteCommand ()
	{
		RotateObject (Vector3.up * -1);

		RaycastHit hit;
		Ray rayScanner = new Ray (m_objMechHatch.transform.position,
		                          m_objMechHatch.transform.TransformDirection(new Vector3(0,0,-1)));

		//Debug.DrawLine(rayScanner.origin, rayScanner.direction * m_fRange, Color.yellow);	

		if(Physics.Raycast(rayScanner, out hit, m_fRange))
		{
			if(hit.collider != null && hit.collider.CompareTag("Mech"))
			{
				if(m_shootBasic != null)
				{
					m_shootBasic.ShootTarget();
				}
				else
				{
					m_shootBasic = this.GetComponent<MechShootBasic>();
				}
			}
		}
	}

	public void RotateObject (Vector3 p_v3Rotation)
	{
		m_objMechHatch.transform.Rotate(p_v3Rotation * angularSpeed);
	}
}
