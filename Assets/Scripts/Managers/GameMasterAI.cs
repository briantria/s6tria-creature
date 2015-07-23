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
	private List<GameObject> m_listMechUnits = new List<GameObject>();

	public delegate void GameMasterAIEventTriggers();
	public static event GameMasterAIEventTriggers onGameResults;

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

		TimerManager.instance.StartTimer ();
	}

	public void GameResult (bool p_bWon)
	{
		if(GameResultManager.instance.gameObject.activeInHierarchy) { return; }

		if(onGameResults != null)
		{
			onGameResults();
		}

		TimerManager.instance.StopTimer();
		GameResultManager.instance.DisplayResults(p_bWon);
	}

	public void MechSetup (Dictionary<int, ChipData> p_dictChipData)
	{
		GameObject objMech = Instantiate(Resources.Load(MECHBASIC_PREFAB)) as GameObject;
		ChipManager chipMngr = objMech.GetComponent<ChipManager>();
		MechManager mechMngr = objMech.GetComponent<MechManager>();
		mechMngr.transform.SetParent(GameScreenManager.instance.transform);
		mechMngr.Reset();

		if(mechMngr.Spawn() == false)
		{
			// arena too crowded
			Destroy(objMech);
			return;
		}
		
		int mechID = mechMngr.ID = m_listMechUnits.Count;
		if(mechID <= 0)
		{
			mechMngr.isMine = true;
		}

		foreach(KeyValuePair<int, ChipData> chipdata in p_dictChipData)
		{
			chipMngr.InstallChip(chipdata.Value.type);
		}

		m_listMechUnits.Add(objMech);
	}

	public void RemoveMech (GameObject p_objMech)
	{
		m_listMechUnits.Remove(p_objMech);
		if(m_listMechUnits.Count == 1)
		{
			GameResult(m_listMechUnits[0].GetComponent<MechManager>().isMine);
		}
	}
}
