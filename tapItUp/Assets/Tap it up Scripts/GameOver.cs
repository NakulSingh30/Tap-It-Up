
using UnityEngine;
using EZCameraShake;


//ALL FUNCTIONS RELATED TO GAME OVER EVENT

public class GameOver : MonoBehaviour
{
	private GameOver gameOver;
    private int admultiplier = 3;
	public static bool isGamerOver;

	private void Start()
	{
		this.gameOver = base.GetComponent<GameOver>();
	}

	public void TriggerResetAnimation()
	{
		GameOver.isGamerOver = true;
		Animator component = base.GetComponent<Animator>();
		component.SetTrigger("GameOverTrigger");
	}

     void Reset()
	{
		this.gameOver.ResetWalls();
		this.gameOver.CameraShake();
		this.gameOver.PlayGameOverSound();
		this.gameOver.ResetBall();
	}

    public void AdEvent(){
        if (PlayerPrefsManager.GetGamesPlayed() % admultiplier != 0  && PlayerPrefsManager.GetGamesPlayed() != 0)  // interestitial ad is shown every 3rd game;
        {
            PlayerPrefsManager.IncrementGamesPlayed();
            ResetLevel();
            return;
        } else {
            VolumeManager.SetMusicVolume(0f);
            InterestitialAd ad = FindObjectOfType<InterestitialAd>();
            ad.ShowAd();
        }

       
    }

	private void CameraShake()
	{
        Debug.Log("camera shake");
		CameraShaker.Instance.ShakeOnce(6f, 6f, 0.2f, 0.2f);
	}

	public void ResetLevel()
	{
		LevelManager levelManager = UnityEngine.Object.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("Retry");
	}

	private void ResetBall()
	{
		Ball ball = UnityEngine.Object.FindObjectOfType<Ball>();
		Ball.inPlay = false;
		ball.BallReset();
	}

	private void ResetWalls()
	{
		LeftWall.initialFlag = true;
		RightWall.initialFlag = true;
	}

	private void PlayGameOverSound()
	{
		SoundClipsContainer soundClipsContainer = UnityEngine.Object.FindObjectOfType<SoundClipsContainer>();
        int musicIndex = (int) SoundClipsContainer.Sounds.GamerOver;
		Vector3 position = UnityEngine.Object.FindObjectOfType<Ball>().transform.position;
		soundClipsContainer.PlaySound(musicIndex, position);
	}
}
