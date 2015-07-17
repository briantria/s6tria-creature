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

[RequireComponent (typeof (EventTrigger))]

public class DraggableUI : MonoBehaviour 
{
	public void OnDrag ()
	{
		Vector3 cursorPosition = Input.mousePosition;
		cursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
		cursorPosition.z = 0;

		transform.position = cursorPosition;
	}
}
