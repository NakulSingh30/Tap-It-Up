using System;
using UnityEngine;

//ALL FUNCTIONS RELATED TO SWICHER

public class Switch : MonoBehaviour
{
	[Range(0f, 100f)]
	public float rotateSpeed = 85f;

	private static Color leftWallColor;

	private static Color rightWallColor;

	private int index;

	private void Update()
	{
		base.transform.Rotate(new Vector3(0f, 0f, this.rotateSpeed * Time.deltaTime));
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		Ball component = collider.GetComponent<Ball>();
		if (component && this.index == 0)
		{
			SpriteRenderer component2 = collider.gameObject.GetComponent<SpriteRenderer>();
			if (component.gameObject.tag == "RightCollider")
			{
				component2.color = Switch.leftWallColor;
			}
			else if (component.gameObject.tag == "LeftCollider")
			{
				component2.color = Switch.rightWallColor;
			}
			this.index++;
		}
	}

	public static void SetBallColorAtLeftWall(Color color)
	{
		Switch.leftWallColor = color;
	}

	public static void SetBallColorAtRightWall(Color color)
	{
		Switch.rightWallColor = color;
	}
}
