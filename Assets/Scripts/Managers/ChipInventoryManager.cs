using UnityEngine;
using System.Collections.Generic;

public class ChipInventoryManager : MonoBehaviour 
{
	private static ChipInventoryManager m_instance = null;
	public  static ChipInventoryManager instance {get{return m_instance;}}

	[SerializeField] private Transform m_tContentContainer;
	public Transform contentContainer {get{return m_tContentContainer;}}

	private const string CHIP_PREFAB_PATH = "Prefabs/Chip";
	private List<ChipData> m_listChipData = new List<ChipData>();

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
		FetchChipData();
		LoadChipData();
	}

	private void FetchChipData ()
	{
		// TODO: load from xml

		ChipData move = new ChipData();
		move.id = 0;
		move.type = "MechMoveForward";
		move.label = "MOVE FORWARD";
		move.description = "Simple Move";

		ChipData turn = new ChipData();
		turn.id = 1;
		turn.type = "MechTurn";
		turn.label = "TURN RIGHT";
		turn.description = "Simple Turn";

		ChipData fire = new ChipData();
		fire.id = 2;
		fire.type = "MechShootBasic";
		fire.label = "SINGLE FIRE";
		fire.description = "Simple Fire";

		ChipData scan = new ChipData();
		scan.id = 3;
		scan.type = "MechScanBasic";
		scan.label = "BASIC RADAR";
		scan.description = "Simple Scan";
		
		m_listChipData.Add(move);
		m_listChipData.Add(turn);
		m_listChipData.Add(fire);
		m_listChipData.Add(scan);
	}

	private void LoadChipData ()
	{
		GameObject objChip;
		ChipDataDisplay chipDataDisplay;

		foreach(ChipData chipData in m_listChipData)
		{
			objChip = Instantiate(Resources.Load(CHIP_PREFAB_PATH)) as GameObject;
			objChip.name = chipData.label;
			objChip.transform.SetParent(m_tContentContainer);
			objChip.transform.localScale = Vector3.one;

			chipDataDisplay = objChip.GetComponent<ChipDataDisplay>();
			chipDataDisplay.chipData = chipData;
		}
	}

	public List<ChipData> GetRandomChipData (int p_iCount = 1)
	{
		List<ChipData> listChipData = new List<ChipData>();
		List<ChipData> listChosenChips = new List<ChipData>();

		listChipData.AddRange(m_listChipData);

		for(int iTry = 0; iTry < p_iCount; ++iTry)
		{
			int index = Random.Range(0, listChipData.Count);
			listChosenChips.Add(listChipData[index]);
			listChipData.RemoveAt(index);

			if(listChipData.Count == 0)
			{
				break;
			}
		}

		return listChosenChips;
	}
}
