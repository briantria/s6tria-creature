using UnityEngine;
using System.Collections;

public class AICountManager : MonoBehaviour 
{
	public void OnEnterAICount (string p_strValue)
	{
		int iAICount = 0;
		if(int.TryParse(p_strValue, out iAICount))
		{
			GameMasterAI.instance.aiCount = iAICount;
		}
	}
}
