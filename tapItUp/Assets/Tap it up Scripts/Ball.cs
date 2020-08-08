using System;
using UnityEngine;


//ALL FUNTIONS RELATED TO BALL

public class Ball : MonoBehaviour
{
	private Rigidbody2D thisRigidBody2d;

	private Swipe swipe;

	private float ballVelocityX = 15f;

	private float ballVelocityY = 0.25f;

	private SpriteRenderer ballSprite;

	private SoundClipsContainer soundClipsContainer;

	private ParticleController particleController;

	private bool isBallScriptStarted;

    private float ballSpeedUpTimer = 4f;

	public float gravityMultiplier = 3f;

	public bool isBallOnwall = true;

	public bool singleSwipe = true;

	public static bool inPlay;

	public float ballSpeed = 3f;

	private void Awake()
	{
		this.ballSprite = base.GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		this.particleController = UnityEngine.Object.FindObjectOfType<ParticleController>();
		this.thisRigidBody2d = base.GetComponent<Rigidbody2D>();
		this.swipe = base.GetComponent<Swipe>();
		this.soundClipsContainer = UnityEngine.Object.FindObjectOfType<SoundClipsContainer>();
		this.isBallScriptStarted = true;
		this.IncreaseSpeed();
	}

	private void Update()
	{
		this.particleController.SetParticleColor(this.ballSprite.color);
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && this.isBallScriptStarted)
		{
			Ball.inPlay = true;
			this.thisRigidBody2d.isKinematic = false;
			this.isBallScriptStarted = false;
		}
		else if (Ball.inPlay)
		{
			this.BallMainFunction();
		}
	}

	private void BallMainFunction()
	{
		if (Input.GetMouseButtonUp(0))
		{
			this.Jump();
		}
		else
		{
			this.CheckSwipe();
		}
		base.transform.rotation = Quaternion.Euler(Vector3.zero);
		base.transform.Translate(Vector2.up * Time.deltaTime * this.ballSpeed);
	}

	private void IncreaseSpeed()
	{
		this.ballSpeed += 0.1f;
        base.Invoke("IncreaseSpeed", ballSpeedUpTimer);
	}

	private void CheckSwipe()
	{
		if (this.singleSwipe)
		{
			if (this.swipe.SwipeLeft && base.gameObject.tag != "LeftCollider")
			{
				this.thisRigidBody2d.velocity = new Vector2(-this.ballVelocityX, this.ballVelocityY);
				this.SwipeAction();
			}
			else if (this.swipe.SwipeRight && base.gameObject.tag != "RightCollider")
			{
				this.thisRigidBody2d.velocity = new Vector2(this.ballVelocityX, this.ballVelocityY);
				this.SwipeAction();
			}
		}
	}

	private void SwipeAction()
	{
		this.PlaySwipeSound();
		this.particleController.PlayParticle();
		this.isBallOnwall = false;
		this.singleSwipe = false;
	}

	private void Jump()
	{
		float x = -Physics2D.gravity.x * this.gravityMultiplier;
		if (this.isBallOnwall)
		{
			this.PlayJumpSound();
			this.thisRigidBody2d.velocity = new Vector2(x, this.ballVelocityY);
			this.isBallOnwall = false;
		}
	}

	private void ballInitialState()
	{
		this.thisRigidBody2d.isKinematic = true;
	}

	private void PlayJumpSound()
	{
        int musicIndex =(int) SoundClipsContainer.Sounds.BallJump;
		this.soundClipsContainer.PlaySound(musicIndex, base.transform.position);
	}

	private void PlaySwipeSound()
	{
        int musicIndex = (int)SoundClipsContainer.Sounds.Swipe;
		this.soundClipsContainer.PlaySound(musicIndex, base.transform.position);
	}

	public void BallReset()
	{
		Vector3 position = base.transform.position;
		base.transform.position = position;
	}

	public void SetColor(Color32 color)
	{
		if (color != Color.white)
		{
			this.ballSprite.color = color;
		}
	}
}
