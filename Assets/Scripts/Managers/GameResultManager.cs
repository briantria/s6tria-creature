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

	public void DisplayResults (EnumGameResults p_enumResult)
	{
		this.gameObject.SetActive (true);

		switch(p_enumResult){
		case EnumGameResults.Win:
		{
			m_textResult.text = "YOU WIN!";
			break;
		}
		case EnumGameResults.Lose:
		{
			m_textResult.text = "YOU LOSE!";
			break;
		}}
	}
}
