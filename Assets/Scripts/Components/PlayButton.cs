using UnityEngine;

public class PlayButton : MonoBehaviour 
{
	public delegate void PlayButtonEventTrigger ();
	public static event PlayButtonEventTrigger onClick;

	public void OnClick ()
	{
		if(onClick != null)
		{
			onClick();
		}
	}
}
