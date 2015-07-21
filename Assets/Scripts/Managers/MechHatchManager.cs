using UnityEngine;

public class MechHatchManager : MonoBehaviour 
{
	[SerializeField] private Transform m_bulletSpawnPoint;
	public Transform bulletSpawnPoint {get{return m_bulletSpawnPoint;}}
}
