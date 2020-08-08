using System;
using UnityEngine;
using UnityEngine.UI;

//VOLUME MANAGER FOR THE GAME

public class VolumeManager : MonoBehaviour
{
	private Text soundText;

	private int masterVolume;

	public static bool isVolumeEnabled = true;

    public static float musicVolume = 0.3f;

	private void Start()
	{
		this.soundText = GameObject.FindGameObjectWithTag("SoundButton").GetComponent<Text>();
		this.masterVolume = PlayerPrefsManager.GetMasterVolume();
		if (this.masterVolume == 0)
		{
			soundText.text = "Stop Sound";
			EnableSoundAndMusic();
		}
		else if (this.masterVolume == 1)
		{
			this.soundText.text = "Play Sound";
			this.DisableSoundAndMusic();
		}
	}

	public void OnTouch()
	{
		this.masterVolume = PlayerPrefsManager.GetMasterVolume();
		this.soundText = GameObject.FindGameObjectWithTag("SoundButton").GetComponent<Text>();
		if (this.masterVolume == 0)
		{
			PlayerPrefsManager.SetMasterVolume(1);
			this.DisableSoundAndMusic();
			this.soundText.text = "Play Sound";
			UnityEngine.Debug.Log(PlayerPrefsManager.GetMasterVolume());
		}
		else if (this.masterVolume == 1)
		{
			PlayerPrefsManager.SetMasterVolume(0);
			this.EnableSoundAndMusic();
			this.soundText.text = "Stop Sound";
			UnityEngine.Debug.Log(PlayerPrefsManager.GetMasterVolume());
		}
	}

	private void EnableSoundAndMusic()
	{
		SetMusicVolume(0.3f);
		VolumeManager.isVolumeEnabled = true;
	}

	private void DisableSoundAndMusic()
	{
		SetMusicVolume(0f);
		VolumeManager.isVolumeEnabled = false;
	}

    public static void SetMusicVolume(float volume)
	{
        MusicManager musicManager = UnityEngine.Object.FindObjectOfType<MusicManager>();
        if (musicManager)
        {
            musicManager.SetVolume(volume);
        }

	}

}
