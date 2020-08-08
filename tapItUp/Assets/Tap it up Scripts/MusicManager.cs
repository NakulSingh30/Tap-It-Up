using System;
using UnityEngine;


//ALL FUNTIONS RELATED TO MUSIC MANAGER FOR MANAGING MUSIC AND SOUNDS AND THEIR VOLUME

public class MusicManager : MonoBehaviour
{
	public AudioClip[] LevelMusicArray;

	[Range(0f, 1f)]
	public float musicVolume = 0.3f;

	private AudioSource audioSource;

	private int lastlevel;

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this.audioSource = base.GetComponent<AudioSource>();
		int masterVolume = PlayerPrefsManager.GetMasterVolume();
		UnityEngine.Debug.Log("master volume" + masterVolume);
		if (masterVolume == 0)
		{
			this.SetVolume(this.musicVolume);
		}
		else if (masterVolume == 1)
		{
			this.SetVolume(0f);
		}
	}

	private void OnLevelWasLoaded(int level)
	{
		if (this.lastlevel != 3 && this.lastlevel != 4)
		{
			AudioClip currentLevelMusic = this.LevelMusicArray[level];
			this.PlayMusic(currentLevelMusic);
		}
		this.lastlevel = level;
	}

	private void PlayMusic(AudioClip currentLevelMusic)
	{
		if (currentLevelMusic)
		{
			this.audioSource.clip = currentLevelMusic;
			this.audioSource.Play();
			this.audioSource.loop = true;
		}
	}

	public void SetVolume(float volume)
	{
		this.audioSource.volume = volume;
	}
}
