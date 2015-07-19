using UnityEngine;
using System.Collections.Generic;

public class MechManager : MonoBehaviour 
{
	private static MechManager m_instance = null;
	public  static MechManager instance {get{return m_instance;}}

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
	}

	public void MechSetup (Dictionary<int, ChipData> p_dictChipData)
	{
		foreach(KeyValuePair<int, ChipData> chipdata in p_dictChipData)
		{
			Debug.Log(chipdata.Value.label);
		}
	}
}
