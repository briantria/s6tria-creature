using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameResultManager : MonoBehaviour 
{
	private static GameResultManager m_instance = null;
	public  static GameResultManager instance {get{return m_instance;}}

	[SerializeField] private Text m_textResult;

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
		this.gameObject.SetActive (false);
	}

	public void DisplayResults (bool p_bWon)
	{
		this.gameObject.SetActive (true);
		m_textResult.text = p_bWon ? "YOU WIN!" : "YOU LOSE!";
	}
}
