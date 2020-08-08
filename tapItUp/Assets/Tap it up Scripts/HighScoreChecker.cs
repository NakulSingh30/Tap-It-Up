using System;
using UnityEngine;


//CHECK FOR THE HIGHSCORE IN EVERY GAME INSTANTIATION

public class HighScoreChecker : MonoBehaviour
{
	private Animator highScoreAnimator;

	private SoundClipsContainer soundClipsContainer;

	private int highScore;

	private int index;

	private void Start()
	{
		this.index = 0;
		this.highScoreAnimator = base.GetComponent<Animator>();
		this.highScore = PlayerPrefsManager.GetHighScore();
		this.soundClipsContainer = UnityEngine.Object.FindObjectOfType<SoundClipsContainer>();
	}

	private void Update()
	{
        if (Score.currentScore == this.highScore && this.index == 0 && highScore!=0)
		{
			this.index++;
			this.highScoreAnimator.SetTrigger("HighScoreTrigger");
            this.soundClipsContainer.PlaySound((int) SoundClipsContainer.Sounds.HighScore, base.transform.position);
		}
	}
}
