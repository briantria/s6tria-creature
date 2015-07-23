using UnityEngine;
using System.Collections;

public class MechCannonManager : MonoBehaviour 
{
	[SerializeField] private float m_fRecoilStrength = 0.5f;
	[SerializeField] private float m_fRecoverSpeed = 0.2f;

	private int m_iRecoverSteps;
	private Transform m_transform;
	private Vector3 m_v3OrigPosition;

	protected void Awake ()
	{
		m_transform = this.transform;
		m_v3OrigPosition = m_transform.localPosition;
		m_iRecoverSteps = (int)(Mathf.Ceil(m_fRecoilStrength / m_fRecoverSpeed));
	}

	public void AnimateRecoil ()
	{
		m_transform.localPosition = m_v3OrigPosition;

		StopCoroutine("IEAnimateRecoil");
		StartCoroutine("IEAnimateRecoil");
	}

	private IEnumerator IEAnimateRecoil ()
	{
		m_transform.Translate(Vector3.up * m_fRecoilStrength);

		for(int idx = 0; idx < m_iRecoverSteps; ++idx)
		{
			yield return new WaitForSeconds(0.03f);
			m_transform.Translate(Vector3.down * m_fRecoverSpeed);
		}

		m_transform.localPosition = m_v3OrigPosition;
	}
}
