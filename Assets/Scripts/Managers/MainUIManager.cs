using UnityEngine;
using System.Collections.Generic;

public class MainUIManager : MonoBehaviour 
{
	private static MainUIManager m_instance = null;
	public static MainUIManager instance {get{return m_instance;}}
	
	[SerializeField] private List<GameObject> m_listHomeScreen = new List<GameObject>();
	[SerializeField] private List<GameObject> m_listGameScreen = new List<GameObject>();

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
	}
}
