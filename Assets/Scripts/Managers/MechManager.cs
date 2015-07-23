/*
 * Brian
 * July 22, 2015
 * 
 * handles events related to mech. (e.g. health, chips status, etc...)
 * 
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MechManager : MonoBehaviour 
{
	[SerializeField] private GameObject m_objCabin;
	[SerializeField] private GameObject m_objHighlight;

	private ChipManager m_chipManager;
	private HealthManager m_healthManager;
	private DeathManager m_deathManager;
	private Rigidbody m_rigidBody;
	private BoxCollider m_boxCollider;
	private bool m_bIsMine;

	public int ID { set; get; }

	public bool isMine
	{
		get { return m_bIsMine; }

		set
		{
			m_bIsMine = value;
			m_objHighlight.SetActive(m_bIsMine);
		}
	}

	protected void Awake ()
	{
		isMine = false;
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
		if(m_objHighlight != null) { m_objHighlight.SetActive(false); }
		if(m_deathManager != null) { m_deathManager.StartExplode(); }
		if(m_boxCollider != null) { m_boxCollider.enabled = false; }

		if(m_rigidBody != null)
		{
			m_rigidBody.isKinematic = true;
			m_rigidBody.detectCollisions = false;
		}
	}

	public void Reset ()
	{
		Transform mechMngrTransform = this.transform;
		mechMngrTransform.position = new Vector3(0,1,0);
		mechMngrTransform.localScale = Vector3.one;
		m_objCabin.transform.rotation = Quaternion.identity;
	}

	public bool Spawn ()
	{
		Transform randomSpawnPoint = ArenaManager.instance.GetRandomSpawnPoint();
		if(randomSpawnPoint == null) { return false; }
		this.transform.position = randomSpawnPoint.position;
		m_objCabin.transform.Rotate(0.0f, Random.Range(0.0f,360.0f), 0.0f);

		return true;
	}

	public void DealDamage (float p_fDamage)
	{
		if(m_healthManager == null) { return; }
		float fCurrentHealth = m_healthManager.UpdateCurrentHealth(-p_fDamage);
		// TODO: distribute damage to chips/components

		if(fCurrentHealth <= 0 && m_deathManager != null)
		{
			MechDeath();
			GameMasterAI.instance.RemoveMech(this.gameObject);
			if(isMine) { GameMasterAI.instance.GameResult(false); }
		}
	}
}
