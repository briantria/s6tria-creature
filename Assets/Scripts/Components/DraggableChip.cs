/*
 * Brian Tria
 * July 17, 2015
 * 
 * example: https://www.youtube.com/watch?v=c47QYgsJrWc
 * 
 */

using UnityEngine; 
using UnityEngine.UI; 
using UnityEngine.EventSystems;

public class DraggableChip : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public static DraggableChip selectedChip { set; get; }
	public int fullListOrderIndex {get{return m_iFullListOrderIndex;}}

	private GameObject m_objDraggableChip;
	private Transform m_transform;
	private Transform m_tInventory;
	private CanvasGroup m_canvasGroup;
	private int m_iFullListOrderIndex;

	// TODO: database of chips' full list. include constant order index;

	protected void Awake ()
	{
		m_transform = this.transform;
		m_tInventory = m_transform.parent;
		m_iFullListOrderIndex = m_transform.GetSiblingIndex();
		m_canvasGroup = this.GetComponent<CanvasGroup>();
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		selectedChip = this;
		m_transform.SetParent(MainUIManager.instance.transform);
		m_canvasGroup.blocksRaycasts = false;
	}

	public void OnDrag (PointerEventData eventData)
	{
		Vector3 cursorPosition = Input.mousePosition;
		cursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
		cursorPosition.z = 0;
		transform.position = cursorPosition;
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		selectedChip = null;
		m_canvasGroup.blocksRaycasts = true;

		if(m_transform.parent.gameObject.GetInstanceID() == MainUIManager.instance.gameObject.GetInstanceID())
		{
			m_transform.SetParent(m_tInventory);
			m_transform.SetSiblingIndex(fullListOrderIndex);
		}
	}
}
