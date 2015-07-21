using UnityEngine;

public class ChipBase <T> : MonoBehaviour 
{
	public virtual void Create (GameObject p_objMech)
	{
		T chipComponent = p_objMech.AddComponent<T>();
	}

	public virtual void ExecuteCommand ()
	{

	}
}
