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
	public int aiCount { set; get; }

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
		aiCount = 0;
	}

	private void GameReset ()
	{
		m_listMechUnits.Clear();
		ArenaManager.instance.Reset();
	}

	public void GameSetup (Dictionary<int, ChipData> p_dictChipData)
	{
		MechSetup(p_dictChipData);

		Dictionary<int, ChipData> aiChipData = new Dictionary<int, ChipData>();
		for(int idx = 0; idx < aiCount; ++idx)
		{
			foreach(ChipData chipdata in ChipInventoryManager.instance.GetRandomChipData(3))
			{
				aiChipData.Add(chipdata.id, chipdata);
			}

			MechSetup(aiChipData);
			aiChipData.Clear();
		}
	}

	public void MechSetup (Dictionary<int, ChipData> p_dictChipData)
	{
		GameObject objMech = Instantiate(Resources.Load(MECHBASIC_PREFAB)) as GameObject;
		MechManager mechMngr = objMech.GetComponent<MechManager>();
		mechMngr.transform.SetParent(GameScreenManager.instance.transform);
		mechMngr.Reset();

		if(mechMngr.Spawn() == false)
		{
			// arena too crowded
			Destroy(objMech);
			return;
		}

		ChipManager chipMngr = objMech.GetComponent<ChipManager>();
		int mechID = m_listMechUnits.Count;
		m_listMechUnits.Add(mechID,chipMngr);

		foreach(KeyValuePair<int, ChipData> chipdata in p_dictChipData)
		{
			chipMngr.InstallChip(chipdata.Value.type);
		}
	}
}
