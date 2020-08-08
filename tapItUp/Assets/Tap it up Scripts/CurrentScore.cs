using System;
using UnityEngine;
using UnityEngine.UI;

//CURRENT SCORE MANAGER

public class CurrentScore : MonoBehaviour
{
	private Text currentScoreText;

	private void Start()
	{
		this.currentScoreText = base.GetComponent<Text>();
	}

	private void Update()
	{
		this.currentScoreText.text = Score.currentScore.ToString() + " M";
	}
}
