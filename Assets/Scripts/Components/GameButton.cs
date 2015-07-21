using UnityEngine;

public class GameButton : MonoBehaviour 
{
	public delegate void GameButtonEventTrigger ();
	public static event GameButtonEventTrigger onClickPlay;
	public static event GameButtonEventTrigger onClickBack;

	public void OnClickPlay ()
	{
		if(onClickPlay != null)
		{
			onClickPlay();
		}
	}

	public void OnClickBack ()
	{
		if(onClickBack != null)
		{
			onClickBack();
		}
	}
}
