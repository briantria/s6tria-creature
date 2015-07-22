using UnityEngine;

public class DeathManager : MonoBehaviour 
{
	private const string PREFAB_PARTICLE_EXPLOSION = "Prefabs/Particles/ParticleExplosion";
	private ParticleSystem m_particleExplosion;

	#region CREATORS

	public void CreateParticleExplosion ()
	{
		GameObject objParticle = Instantiate(Resources.Load(PREFAB_PARTICLE_EXPLOSION)) as GameObject;
		Transform transParticle = objParticle.transform;
		transParticle.SetParent(this.transform);
		transParticle.localPosition = Vector3.zero;
		transParticle.localScale = Vector3.one;

		m_particleExplosion = objParticle.GetComponent<ParticleSystem>();
	}

	#endregion

	public void Respawn ()
	{

	}

	public void StartExplode ()
	{
		if(m_particleExplosion != null)
		{
			m_particleExplosion.Play();
			Invoke("EndExplode", 1.0f);
		}
	}

	private void EndExplode ()
	{
		m_particleExplosion.Stop();
	}
}
