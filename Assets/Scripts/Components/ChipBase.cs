using UnityEngine;
using System;

public class ChipBase : MonoBehaviour 
{
	protected void FixedUpdate ()
	{
		ExecuteCommand();
	}

	public virtual void ExecuteCommand ()
	{

	}
}
