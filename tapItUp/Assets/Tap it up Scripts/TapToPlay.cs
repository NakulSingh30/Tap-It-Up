using System;
using UnityEngine;
using UnityEngine.UI;

//WAITS FOR THE USER FOR A TAP TO START GAME

public class TapToPlay : MonoBehaviour
{
	private Text tapToPlay;

	private void Start()
	{
		this.tapToPlay = base.GetComponent<Text>();
		GameOver.isGamerOver = false;
	}

	private void Update()
	{
		if (GameOver.isGamerOver)
		{
			this.tapToPlay.text = "Game Over!!";
		}
		else if (!Ball.inPlay)
		{
			this.tapToPlay.text = "Tap To Play";
		}
		else
		{
			this.tapToPlay.text = string.Empty;
		}
	}
}
