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
	public GameObject mechHatch { get{ return m_objHatch; }}
	public GameObject mechCabin { get{ return m_objCabin; }}
	public int mechID { set; get; }

	[SerializeField] private GameObject m_objBody;
	[SerializeField] private GameObject m_objHatch;
	[SerializeField] private GameObject m_objCabin;

	private GameObject m_objMech;
	private MechMoveForward m_moveComponent;
	private List<ChipBase> m_listChipComponents = new List<ChipBase>();

	protected void OnEnable ()
	{
		GameButton.onClickPlay += GameStart;
		GameButton.onClickBack += GameReset;
	}

	protected void OnDisable ()
	{
		GameButton.onClickPlay -= GameStart;
		GameButton.onClickBack -= GameReset;
	}

	private void GameStart ()
	{
		this.gameObject.GetComponents<ChipBase>(m_listChipComponents);
	}

	private void GameReset ()
	{
		Destroy(this.gameObject);
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

	public void ActivateAllChips (bool p_bActivate)
	{
		ChipBase[] listChipComponents = this.gameObject.GetComponents<ChipBase>() as ChipBase[];
		
		for(int idx = listChipComponents.Length-1; idx >= 0; --idx)
		{
			listChipComponents[idx].isActive = p_bActivate;
		}
		
		listChipComponents = null;
	}
}
