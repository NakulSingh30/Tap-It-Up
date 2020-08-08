using System;
using UnityEngine;
using UnityEngine.UI;

//HIGH SCORE MANAGER

public class HighScore : MonoBehaviour
{
	private Text highScoreText;

	private void Start()
	{
		this.highScoreText = base.GetComponent<Text>();
	}

	private void Update()
	{
		this.highScoreText.text = PlayerPrefsManager.GetHighScore().ToString() + " M";
	}
}
