using System;
using UnityEngine;
using UnityEngine.UI;

//SCORE MANAGER

public class Score : MonoBehaviour
{
	private Text scoreText;

	private Ball ball;

	private int highscore;

	public static int currentScore;

	private void Start()
	{
		this.highscore = PlayerPrefsManager.GetHighScore();
		this.scoreText = base.GetComponent<Text>();
		this.ball = UnityEngine.Object.FindObjectOfType<Ball>();
	}

	private void Update()
	{
		Score.currentScore = (int)this.ball.transform.position.y;
		if (Ball.inPlay)
		{
			this.scoreText.text = Score.currentScore.ToString() + " m";
		}
		else
		{
			this.scoreText.text = string.Empty;
		}
		if (Score.currentScore > this.highscore)
		{
			PlayerPrefsManager.SetHighScore(Score.currentScore);
		}
	}
}
