using System;
using UnityEngine;

//ALL FUNCTIONS RELATED TO THE WALL

public class Wall : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collider)
	{
        Ball ball = collider.gameObject.GetComponent<Ball>();
        if (ball)
		{
            this.SetBallTagAndFlags(ball);
			SpriteRenderer wallSprite = GetComponent<SpriteRenderer>();
            SpriteRenderer ballSprite = ball.gameObject.GetComponent<SpriteRenderer>();
            if (ballSprite.color != wallSprite.color)
			{
				GameOver gameOver = UnityEngine.Object.FindObjectOfType<GameOver>();
				gameOver.TriggerResetAnimation();
			}
		}
	}

	private void SetBallTagAndFlags(Ball ball)
	{
		if (base.gameObject.tag == "LeftCollider")
		{
			ball.gameObject.tag = base.gameObject.tag;
		}
		else if (base.gameObject.tag == "RightCollider")
		{
			ball.gameObject.tag = base.gameObject.tag;
		}
		ball.isBallOnwall = true;
		ball.singleSwipe = true;
	}
}
