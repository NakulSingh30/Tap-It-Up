using System;
using UnityEngine;
using UnityEngine.SceneManagement;


//SUB CLASS OF LEVEL MANAGER FOR GOING TO PREVIOUS SCENE

public class GotoPreviousScene : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("Start Menu");
			UnityEngine.Debug.Log("back button pressed");
		}
	}
}
