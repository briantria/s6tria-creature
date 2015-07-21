using UnityEngine;
using System.Collections.Generic;

public class MechManager : MonoBehaviour 
{
	private static MechManager m_instance = null;
	public  static MechManager instance {get{return m_instance;}}

	protected void OnEnable ()
	{
		GameButton.onClickBack += OnClickBack;
	}

	protected void OnDisable ()
	{
		GameButton.onClickBack -= OnClickBack;
	}

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
	}

	private void OnClickBack ()
	{
		ChipManager chipManager = ChipManager.instance;
		Transform chipMngrTransform = chipManager.transform;

		chipMngrTransform.position = new Vector3(0,1,0);
		chipMngrTransform.localScale = Vector3.one;
		chipMngrTransform.rotation = Quaternion.identity;
		chipManager.UninstallAllChips();
	}

	public void MechSetup (Dictionary<int, ChipData> p_dictChipData)
	{
		foreach(KeyValuePair<int, ChipData> chipdata in p_dictChipData)
		{
			ChipManager.instance.InstallChip(chipdata.Value.type);
		}
	}
}
