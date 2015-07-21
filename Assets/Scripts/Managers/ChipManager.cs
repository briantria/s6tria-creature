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

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
	}

	protected void LateUpdate ()
	{
		//m_moveComponent.MoveRigidBody(Vector3.forward * (-1));
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
