using UnityEngine;
using UnityEngine.EventSystems;

public class MechSetupManager : MonoBehaviour, IDropHandler
{
	[SerializeField] private Transform m_tinstalledChipsContainer;

	private static MechSetupManager m_instance = null;
	private int m_iCurrentChipInstalled;
	private int m_iMaxChipInstall = 5; // TODO: max should depend on current mech used

	public static MechSetupManager instance {get{return m_instance;}}
	public Transform installedChipsContainer {get{return m_tinstalledChipsContainer;}}
	
	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
		m_iCurrentChipInstalled = 0;
	}

	public void OnDrop (PointerEventData eventData)
	{
		m_iCurrentChipInstalled = m_tinstalledChipsContainer.childCount;

		if(m_iCurrentChipInstalled < m_iMaxChipInstall)
		{
			DraggableChip selectedChip = DraggableChip.selectedChip;
			selectedChip.transform.SetParent(m_tinstalledChipsContainer);
			selectedChip.transform.SetSiblingIndex(selectedChip.fullListOrderIndex);
		}
	}
}
