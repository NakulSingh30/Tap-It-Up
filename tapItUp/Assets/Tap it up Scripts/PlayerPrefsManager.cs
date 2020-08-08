using System;
using UnityEngine;

//MANAGER FOR MANAGING ALL THE USER CONFIGS 

public class PlayerPrefsManager : MonoBehaviour
{
	private const string MASTER_VOLUME = "master_volume";

	private const string BEST_SCORE = "best_score";

    private const string GAMES_PLAYED = "games_played";

    private const string IS_PRIVACY_POLICY_CHECKED = "privacy_policy";

	public static void SetMasterVolume(int volume)
	{
		PlayerPrefs.SetInt("master_volume", volume);
	}

	public static int GetMasterVolume()
	{
		return PlayerPrefs.GetInt("master_volume");
	}

	public static void SetHighScore(int value)
	{
        PlayerPrefs.SetInt(BEST_SCORE, value);
	}

	public static int GetHighScore()
	{
        return PlayerPrefs.GetInt(BEST_SCORE);
	}

    public static int GetGamesPlayed(){
        return PlayerPrefs.GetInt(GAMES_PLAYED);
    }

    public static void IncrementGamesPlayed(){
        PlayerPrefs.SetInt(GAMES_PLAYED, GetGamesPlayed() + 1);
    }


    public static void SetPrivacyPolicyCheck(){
        PlayerPrefs.SetInt(IS_PRIVACY_POLICY_CHECKED, 1);
    }

    public static int GetPrivacyPolicyCheck(){
        return PlayerPrefs.GetInt(IS_PRIVACY_POLICY_CHECKED);
    }


 

}
