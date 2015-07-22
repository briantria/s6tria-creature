using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArenaManager : MonoBehaviour 
{
	private static ArenaManager m_instance = null;
	public  static ArenaManager instance {get{return m_instance;}}

	[SerializeField] private List<Transform> m_spawnPoints = new List<Transform>();
	private List<Transform> m_availableSpawnPoints = new List<Transform>();

	protected void Awake ()
	{
		if(m_instance == null){m_instance = this;}
		m_availableSpawnPoints.AddRange(m_spawnPoints);
	}

	public void Reset ()
	{
		m_availableSpawnPoints.AddRange(m_spawnPoints);
	}

	public Transform GetRandomSpawnPoint ()
	{
		if(m_availableSpawnPoints.Count <= 0)
		{
			Debug.Log("Arena is full!");
			return null;
		}

		int index = Random.Range(0, m_availableSpawnPoints.Count);
		Transform spawnPoint = m_availableSpawnPoints[index];
		m_availableSpawnPoints.RemoveAt(index);

		return spawnPoint;
	}
}
