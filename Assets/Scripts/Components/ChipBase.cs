using UnityEngine;
using System;

public class ChipBase : MonoBehaviour 
{
	private bool m_bIsActive = true;
	public bool isActive { set { m_bIsActive = value; } get { return m_bIsActive; } }

	protected void OnEnable ()
	{
		GameMasterAI.onGameResults += OnGameResults;
	}

	protected void OnDisable ()
	{
		GameMasterAI.onGameResults -= OnGameResults;
	}

	protected void FixedUpdate ()
	{
		if(m_bIsActive == false) { return; }
		ExecuteCommand();
	}

	private void OnGameResults ()
	{
		m_bIsActive = false;
	}

	public virtual void ExecuteCommand ()
	{

	}
}
