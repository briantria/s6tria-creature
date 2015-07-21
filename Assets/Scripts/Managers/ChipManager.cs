/*
 * Brian Tria
 * July 15, 2015
 * 
 * ChipManager acts as the central processing unit of the mecha unit
 * 
 */

using UnityEngine;
using System;
using System.Collections.Generic;

public class ChipManager : MonoBehaviour 
{
	private static ChipManager m_instance = null;
	public  static ChipManager instance {get{return m_instance;}}

	[SerializeField] private GameObject m_objBody;
	[SerializeField] private GameObject m_objHatch;

	private GameObject m_objMech;
	private MechMoveForward m_moveComponent;
	private List<ChipBase> m_listChipComponents = new List<ChipBase>();

	protected void OnEnable ()
	{
		GameButton.onClickPlay += GameStart;
	}

	protected void OnDisable ()
	{
		GameButton.onClickPlay -= GameStart;
	}

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
	}

//	protected void LateUpdate ()
//	{
//		if(m_listChipComponents == null || m_listChipComponents.Count <= 0)
//		{
//			return;
//		}
//
//
//	}

	private void GameStart ()
	{
		this.gameObject.GetComponents<ChipBase>(m_listChipComponents);
	}

	public void InstallChip (string p_chipTypeName)
	{
		this.gameObject.AddComponent(Type.GetType(p_chipTypeName));
	}

	public void UninstallAllChips ()
	{
		ChipBase[] listChipComponents = this.gameObject.GetComponents<ChipBase>() as ChipBase[];

		for(int idx = listChipComponents.Length-1; idx >= 0; --idx)
		{
			Destroy(listChipComponents[idx]);
		}

		listChipComponents = null;
	}
}
