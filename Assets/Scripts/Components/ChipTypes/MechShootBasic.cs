using UnityEngine;

public class MechShootBasic : ChipBase
{
	private const string BULLET_PREFAB = "Prefabs/BulletBasic";
	private Bullet m_basicBullet;
	private Transform m_tBulletSpawnPoint;

	protected void OnEnable ()
	{
		m_basicBullet = (Instantiate(Resources.Load(BULLET_PREFAB)) as GameObject).GetComponent<Bullet>();
		m_basicBullet.Reset();
	}

	protected void OnDisable ()
	{
		if(m_basicBullet != null)
		{
			Destroy(m_basicBullet.gameObject);
		}
	}

	protected void Awake ()
	{
		m_tBulletSpawnPoint = this.GetComponent<ChipManager>().mechHatch.GetComponent<MechHatchManager>().bulletSpawnPoint;
	}

	public void ShootTarget ()
	{
		if(m_basicBullet.isAvailable)
		{
			//Debug.Log("SHOOT TARGET");
			Vector3 v3Direction = m_tBulletSpawnPoint.TransformDirection(Vector3.forward * (-1));
			//Debug.Log("DIRECTION: " + v3Direction);
			m_basicBullet.SetupAndFire(m_tBulletSpawnPoint, v3Direction);
		}
	}
}
