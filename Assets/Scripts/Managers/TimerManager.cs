using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour 
{
	private static TimerManager m_instance = null;
	public  static TimerManager instance {get{return m_instance;}}

	[SerializeField] private Text m_textTimer;

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
	}

	private IEnumerator IEStartTimer ()
	{
		float fTimeValue = 5.0f;

		while (true) 
		{
			m_textTimer.text = "" + fTimeValue;

			yield return new WaitForSeconds (0.8f);
			fTimeValue--;

			if(fTimeValue < 0)
			{
				GameMasterAI.instance.GameResult(EnumGameResults.Win);
				break;
			}
		}
	}

	public void StartTimer ()
	{
		StartCoroutine ("IEStartTimer");
	}

	public void StopTimer ()
	{
		StopCoroutine ("IEStartTimer");
	}
}
