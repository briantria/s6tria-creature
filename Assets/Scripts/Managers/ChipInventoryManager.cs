using UnityEngine;

public class ChipInventoryManager : MonoBehaviour 
{
	private static ChipInventoryManager m_instance = null;
	public static ChipInventoryManager instance {get{return m_instance;}}

	[SerializeField] private Transform m_tContentContainer;
	public Transform contentContainer {get{return m_tContentContainer;}}

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
	}
}
