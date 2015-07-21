using UnityEngine;
using System;

public class ChipBase : MonoBehaviour 
{
	private bool m_bOnPlay;

//	protected void OnEnable ()
//	{
//		GameButton.onClickPlay += OnClickPlay;
//		GameButton.onClickBack += OnClickBack;
//	}
//
//	protected void OnDisable ()
//	{
//		GameButton.onClickPlay -= OnClickPlay;
//		GameButton.onClickBack -= OnClickBack;
//	}

	protected virtual void Awake ()
	{
		m_bOnPlay = true;
	}

	protected void LateUpdate ()
	{
		if(m_bOnPlay == false) { return; }
		ExecuteCommand();
	}

//	private void OnClickPlay ()
//	{
//		m_bOnPlay = true;
//	}
//
//	private void OnClickBack ()
//	{
//		m_bOnPlay = false;
//	}

	public virtual void ExecuteCommand ()
	{

	}
}
