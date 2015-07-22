﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour, IMoveHandler
{
	[SerializeField] private float m_fSpeed = 15.0f;
	[SerializeField] private float m_fExplosionRadius = 5.0f;
	[SerializeField] private float m_fExplosionPower = 4.0f;
	[SerializeField] private float m_fExplosionUpwardMod = 1.5f;

	public bool isAvailable { set; get; }

	private Rigidbody m_rigidBody;
	private MeshRenderer m_meshRenderer;
	private SphereCollider m_sphereCollider;

	protected void Awake ()
	{
		isAvailable = false;
		m_rigidBody = this.GetComponent<Rigidbody>();
		m_meshRenderer = this.GetComponent<MeshRenderer>();
		m_sphereCollider = this.GetComponent<SphereCollider>();
	}

	protected  void OnTriggerEnter (Collider p_collider) 
	{
		if(p_collider.CompareTag("Mech"))
		{
			// explosion!
			Rigidbody hitMech = p_collider.GetComponent<Rigidbody>();
			if(hitMech != null)
			{
				hitMech.AddExplosionForce(m_fExplosionPower, this.transform.position, m_fExplosionRadius, m_fExplosionUpwardMod, ForceMode.Impulse);
			}
		}

		Reset();
	}

	public void Reset ()
	{
		isAvailable = true;
		m_rigidBody.isKinematic = true;
		m_meshRenderer.enabled = false;
		m_sphereCollider.enabled = false;
	}

	public void MoveObject (Vector3 p_v3Direction)
	{
		if(m_rigidBody != null && isAvailable)
		{
			//Debug.Log("SPEED: " + (p_v3Direction * m_fSpeed));
			m_rigidBody.AddForce(p_v3Direction * m_fSpeed, ForceMode.Impulse);
		}
	}

	public void SetupAndFire (Transform p_spawnPoint, Vector3 p_v3Direction)
	{
		this.transform.position = p_spawnPoint.position;
		m_rigidBody.isKinematic = false;
		m_meshRenderer.enabled = true;
		m_sphereCollider.enabled = true;
		MoveObject(p_v3Direction);
		isAvailable = false;
	}
}
