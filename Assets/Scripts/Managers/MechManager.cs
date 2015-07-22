/*
 * Brian
 * July 22, 2015
 * 
 * handles events related to mech. (e.g. health, chips status, etc...)
 * 
 */

using UnityEngine;

public class MechManager : MonoBehaviour 
{
	[SerializeField] private GameObject m_objCabin;

	private ChipManager m_chipManager;
	private HealthManager m_healthManager;
	private DeathManager m_deathManager;
	private Rigidbody m_rigidBody;
	private BoxCollider m_boxCollider;

	protected void Awake ()
	{
		m_chipManager = this.GetComponent<ChipManager>();
		m_healthManager = this.GetComponent<HealthManager>() as HealthManager;
		m_deathManager = this.GetComponent<DeathManager>() as DeathManager;
		m_rigidBody = this.GetComponent<Rigidbody>();
		m_boxCollider = this.GetComponent<BoxCollider>();

		if(m_deathManager != null)
		{
			m_deathManager.CreateParticleExplosion();
		}
	}
	
	private void MechDeath ()
	{
		if(m_chipManager != null) { m_chipManager.ActivateAllChips(false); }
		if(m_objCabin != null) { m_objCabin.SetActive(false); }
		if(m_deathManager != null) { m_deathManager.StartExplode(); }
		if(m_boxCollider != null) { m_boxCollider.enabled = false; }
		if(m_rigidBody != null)
		{
			m_rigidBody.isKinematic = true;
			m_rigidBody.detectCollisions = false;
		}
	}

	public void DealDamage (float p_fDamage)
	{
		if(m_healthManager == null) { return; }
		float fCurrentHealth = m_healthManager.UpdateCurrentHealth(-p_fDamage);
		// TODO: distribute damage to chips/components

		if(fCurrentHealth <= 0 && m_deathManager != null)
		{
			MechDeath();
		}
	}
}
