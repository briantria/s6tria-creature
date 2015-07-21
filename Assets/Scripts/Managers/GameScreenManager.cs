using UnityEngine;

public class GameScreenManager : MonoBehaviour 
{
	private static GameScreenManager m_instance = null;
	public  static GameScreenManager instance {get{return m_instance;}}

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
	}
}
