using System;
using UnityEngine;

//CLASS FOR BALL TRAIL ANIMATION AND COLOR

public class ParticleController : MonoBehaviour
{
	private ParticleSystem particle;

	private ParticleSystem.ColorOverLifetimeModule particleColor;

	private void Start()
	{
		this.particle = base.GetComponent<ParticleSystem>();
		this.particleColor = base.GetComponent<ParticleSystem>().colorOverLifetime;
	}

	public void SetParticleColor(Color color)
	{
		this.particleColor.color = color;
	}

	public void PlayParticle()
	{
		this.particle.Play();
	}

	private void SetParticleActive()
	{
		base.gameObject.SetActive(true);
	}
}
