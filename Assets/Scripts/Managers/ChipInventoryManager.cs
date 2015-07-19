using UnityEngine;
using System.Collections.Generic;

public class ChipInventoryManager : MonoBehaviour 
{
	private static ChipInventoryManager m_instance = null;
	public static ChipInventoryManager instance {get{return m_instance;}}

	[SerializeField] private Transform m_tContentContainer;
	//public Transform contentContainer {get{return m_tContentContainer;}}

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
		move.label = "Simple Move";
		move.description = "Simple Move";

		ChipData turn = new ChipData();
		turn.id = 1;
		turn.label = "Simple Turn";
		turn.description = "Simple Turn";

		ChipData fire = new ChipData();
		fire.id = 1;
		fire.label = "Simple Fire";
		fire.description = "Simple Fire";

		ChipData scan = new ChipData();
		scan.id = 1;
		scan.label = "Simple Scan";
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
			chipDataDisplay.id = chipData.id;
			chipDataDisplay.label = chipData.label;
			chipDataDisplay.description = chipData.description;
		}
	}
}
