using UnityEngine;
using System;

public class ChipBase <T> : MonoBehaviour 
{
	public virtual void AttachTo (GameObject p_objMech)
	{
		p_objMech.AddComponent(typeof(T));
	}

	public virtual void ExecuteCommand ()
	{

	}
}
