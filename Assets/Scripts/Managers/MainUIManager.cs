using UnityEngine;
using System.Collections.Generic;

public class MainUIManager : MonoBehaviour 
{
	private static MainUIManager m_instance = null;
	public static MainUIManager instance {get{return m_instance;}}
	
	[SerializeField] private List<GameObject> m_listHomeScreen = new List<GameObject>();
	[SerializeField] private List<GameObject> m_listGameScreen = new List<GameObject>();

	protected void OnEnable ()
	{
		GameButton.onClickPlay += OnClickPlay;
		GameButton.onClickBack += OnClickBack;
	}

	protected void OnDisable ()
	{
		GameButton.onClickPlay -= OnClickPlay;
		GameButton.onClickBack -= OnClickBack;
	}

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
	}

	private void OnClickPlay ()
	{
		foreach(GameObject obj in m_listHomeScreen)
		{
			obj.SetActive(false);
		}

		foreach(GameObject obj in m_listGameScreen)
		{
			obj.SetActive(true);
		}
	}

	private void OnClickBack ()
	{
		foreach(GameObject obj in m_listHomeScreen)
		{
			obj.SetActive(true);
		}
		
		foreach(GameObject obj in m_listGameScreen)
		{
			obj.SetActive(false);
		}

		GameResultManager.instance.gameObject.SetActive(false);
		GameScreenManager.instance.gameObject.SetActive(false);
	}
}
