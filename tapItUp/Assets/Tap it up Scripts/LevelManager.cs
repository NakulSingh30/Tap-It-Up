using System;
using UnityEngine;
using UnityEngine.SceneManagement;


//LEVEL MANAGER FOR MANAGING ALL SCENES OF THE GAME

public class LevelManager : MonoBehaviour
{
	private float SplashScreenLoadingTime = 0.1f;

	private void Start()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
            
			this.AutoLoadNextLevel();
		}
	}

	public void AutoLoadNextLevel()
	{
        //skipping privacy policy scene if already shown
        if(PlayerPrefsManager.GetPrivacyPolicyCheck() == 1){
            LoadLevel("Start Menu");
        }
		base.Invoke("LoadNextLevel", this.SplashScreenLoadingTime);
	}

	public void LoadLevel(string name)
	{
        //for showing privacy policy only once
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
            PlayerPrefsManager.SetPrivacyPolicyCheck();
        }
        SceneManager.LoadScene(name);
	}

	public void QuitRequest()
	{
		UnityEngine.Debug.Log("Quit requested");
		Application.Quit();
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}


    public void OpenPolicyURL(){
        Application.OpenURL("https://sites.google.com/view/tapitup");
    }

}
