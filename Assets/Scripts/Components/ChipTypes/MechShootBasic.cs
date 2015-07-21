using UnityEngine;

public class MechShootBasic : ChipBase
{
	private const string BULLET_PREFAB = "Prefabs/BulletBasic";
	private Bullet m_basicBullet;
	private Transform m_tBulletSpawnPoint;

	protected void OnEnable ()
	{
		MechScanBasic.onDetectTarget += ShootTarget;

		m_basicBullet = (Instantiate(Resources.Load(BULLET_PREFAB)) as GameObject).GetComponent<Bullet>();
		m_basicBullet.Reset();
	}

	protected void OnDisable ()
	{
		MechScanBasic.onDetectTarget -= ShootTarget;

		if(m_basicBullet != null)
		{
			Destroy(m_basicBullet.gameObject);
		}
	}

	protected void Awake ()
	{
		m_tBulletSpawnPoint = ChipManager.instance.mechHatch.GetComponent<MechHatchManager>().bulletSpawnPoint;
	}

	private void ShootTarget (GameObject p_objTarget)
	{
		if(p_objTarget != null && m_basicBullet.isAvailable)
		{
			//Debug.Log("SHOOT TARGET");
			Vector3 v3Direction = m_tBulletSpawnPoint.TransformDirection(Vector3.forward * (-1));
			//Debug.Log("DIRECTION: " + v3Direction);
			m_basicBullet.SetupAndFire(m_tBulletSpawnPoint, v3Direction);
		}
	}
}
