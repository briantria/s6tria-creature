using UnityEngine;
using System.Collections;

public class MainUIManager : MonoBehaviour 
{
	private static MainUIManager m_instance = null;
	public static MainUIManager instance {get{return m_instance;}}

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
	}
}
