/*
 * Brian Tria
 * July 17, 2015
 * 
 * use EventTrigger in inspector to handle event types
 * example: http://answers.unity3d.com/questions/846360/c-draggable-46-ui.html
 * 
 */

using UnityEngine; 
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public delegate void DraggableEventTrigger (GameObject p_gameObject);
	public static event DraggableEventTrigger onBeginDrag;
	public static event DraggableEventTrigger onEndDrag;
	public static event DraggableEventTrigger onDrag;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		//throw new System.NotImplementedException ();
		if(onBeginDrag != null)
		{
			onBeginDrag(this.gameObject);
		}
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		//throw new System.NotImplementedException ();
		if(onDrag != null)
		{
			onDrag(this.gameObject);
		}
		
		Vector3 cursorPosition = Input.mousePosition;
		cursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
		cursorPosition.z = 0;
		
		transform.position = cursorPosition;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		//throw new System.NotImplementedException ();
		if(onEndDrag != null)
		{
			onEndDrag(this.gameObject);
		}
	}

	#endregion

}
