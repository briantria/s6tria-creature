/*
 * Brian
 * July 22, 2015
 * 
 * handles overall events in a game. mostly about updates from all players.
 * 
 */

using UnityEngine;
using System.Collections.Generic;

public class GameMasterAI : MonoBehaviour 
{
	private static GameMasterAI m_instance = null;
	public  static GameMasterAI instance {get{return m_instance;}}

	private const string MECHBASIC_PREFAB = "Prefabs/MechBasic";
	private Dictionary<int, ChipManager> m_listMechUnits = new Dictionary<int, ChipManager>();

	protected void OnEnable ()
	{
		GameButton.onClickBack += GameReset;
	}
	
	protected void OnDisable ()
	{
		GameButton.onClickBack -= GameReset;
	}

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
	}

	private void GameReset ()
	{
		m_listMechUnits.Clear();
	}

	public void MechSetup (Dictionary<int, ChipData> p_dictChipData)
	{
		ChipManager mechUnit = (Instantiate(Resources.Load(MECHBASIC_PREFAB)) as GameObject).GetComponent<ChipManager>();
		mechUnit.transform.SetParent(GameScreenManager.instance.transform);
		mechUnit.Reset();

		int mechID = m_listMechUnits.Count;
		m_listMechUnits.Add(mechID,mechUnit);

		foreach(KeyValuePair<int, ChipData> chipdata in p_dictChipData)
		{
			mechUnit.InstallChip(chipdata.Value.type);
		}
	}
}
