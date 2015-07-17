/*
 * Brian Tria
 * July 18, 2015
 * 
 */

using UnityEngine;
using System.Collections;

public class ChipDragListener : MonoBehaviour 
{
	protected void OnEnable ()
	{
		DraggableUI.onBeginDrag += OnDragBegin;
		DraggableUI.onEndDrag += OnDragEnd;
	}

	protected void OnDisable ()
	{
		DraggableUI.onBeginDrag -= OnDragBegin;
		DraggableUI.onEndDrag -= OnDragEnd;
	}

	private void OnDragEnd (GameObject p_objDraggable)
	{

	}

	private void OnDragBegin (GameObject p_objDraggable)
	{
		
	}
}
