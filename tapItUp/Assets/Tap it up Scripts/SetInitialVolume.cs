using UnityEngine;

//SETTING INITIAL VOLUME OF GAME ACCORDING TO THE USER CONFIG

public class SetInitialVolume : MonoBehaviour
{
    private MusicManager musicManager;

    private void Start()
    {
        this.musicManager = FindObjectOfType<MusicManager>();
        if (this.musicManager)
        {
            int masterVolume = PlayerPrefsManager.GetMasterVolume();
            if (masterVolume == 0)
            {
                VolumeManager.SetMusicVolume(VolumeManager.musicVolume);
            }
            else {
                VolumeManager.SetMusicVolume(0f);
                }
        }
        else
        {
            Debug.LogError("music manager not found");
        }
    }

    private void Update()
    {
    }
}