using UnityEngine;

public class HealthManager : MonoBehaviour 
{
	[SerializeField] private GameObject m_objHealthbar;
	[SerializeField] private float m_fFullHealth;

	private float m_fCurrHealth;
	private float m_fFullHealthbarScale;

	protected void Awake ()
	{
		m_fCurrHealth = m_fFullHealth;
		if(m_objHealthbar != null)
		{
			m_fFullHealthbarScale = m_objHealthbar.transform.localScale.x;
		}
	}

	public void Reset ()
	{
		m_fCurrHealth = m_fFullHealth;
		if(m_objHealthbar != null)
		{
			Vector3 v3Scale = m_objHealthbar.transform.localScale;
			v3Scale.x = m_fFullHealthbarScale;
			m_objHealthbar.transform.localScale = v3Scale;
		}
	}

	public float UpdateCurrentHealth (float p_fValue)
	{
		m_fCurrHealth = Mathf.Max(0.0f, m_fCurrHealth + p_fValue);

		if(m_objHealthbar != null)
		{
			Vector3 v3Scale = m_objHealthbar.transform.localScale;
			v3Scale.x = m_fFullHealthbarScale * (m_fCurrHealth / m_fFullHealth);
			m_objHealthbar.transform.localScale = v3Scale;
		}

		return m_fCurrHealth;
	}
}
