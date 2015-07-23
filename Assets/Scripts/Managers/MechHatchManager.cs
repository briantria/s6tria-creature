using UnityEngine;

public class MechHatchManager : MonoBehaviour 
{
	[SerializeField] private Transform m_bulletSpawnPoint;
	[SerializeField] private GameObject m_cannon;

	public Transform bulletSpawnPoint {get{return m_bulletSpawnPoint;}}
	public GameObject cannon {get{return m_cannon;}}
}
