using System;
using UnityEngine;



//CUSTOM GRAVITY PHYSICS FOR THIS GAME

public class GravityController : MonoBehaviour
{
	public float gravityXmagnitude = 15f;

	private void Awake()
	{
		Physics2D.gravity = new Vector2(-this.gravityXmagnitude, 0f);
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		Ball component = collider.gameObject.GetComponent<Ball>();
		if (component)
		{
			this.ChangeGravity(component);
		}
	}

	private void ChangeGravity(Ball ball)
	{
		if (ball.gameObject.tag == "RightCollider")
		{
			Physics2D.gravity = new Vector2(-this.gravityXmagnitude, 0f);
		}
		else if (ball.gameObject.tag == "LeftCollider")
		{
			Physics2D.gravity = new Vector2(this.gravityXmagnitude, 0f);
		}
	}
}
