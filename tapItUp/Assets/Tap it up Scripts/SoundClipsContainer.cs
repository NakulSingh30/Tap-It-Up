using System;
using UnityEngine;

//GAME SOUND MANAGER

public class SoundClipsContainer : MonoBehaviour
{
	public enum Sounds
	{
		BallJump,
		Swipe,
		GamerOver,
		HighScore
	}

	public AudioClip[] audioClips;

	private AudioClip GetAudioClip(int index)
	{
		switch (index)
		{
		case 0:
			return this.audioClips[0];
		case 1:
			return this.audioClips[1];
		case 2:
			return this.audioClips[2];
		case 3:
			return this.audioClips[3];
		default:
			throw new Exception("error");
		}
	}


	public void PlaySound(int musicIndex, Vector3 position)
	{
		if (VolumeManager.isVolumeEnabled)
		{
			AudioSource.PlayClipAtPoint(this.audioClips[musicIndex], position, 1f);
		}
	}
}
