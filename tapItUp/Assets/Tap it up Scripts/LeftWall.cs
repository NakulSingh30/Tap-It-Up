using System;
using UnityEngine;

//ALL FUNCTIONS RELATED TO LEFT WALL

public class LeftWall : MonoBehaviour
{
	private static Color currentColor;

	private static Color prevColor;

	private int index;

	private Ball ball;

	public static bool initialFlag = true;

	private void Start()
	{
		this.InitialState();
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		Ball component = collider.GetComponent<Ball>();
		if (component)
		{
			this.index++;
			if (component.gameObject.tag == "LeftCollider")
			{
				UnityEngine.Debug.Log("left wall color changed");
				this.ChangeCurrentColor();
				while (LeftWall.prevColor == LeftWall.currentColor)
				{
					this.ChangeCurrentColor();
				}
				LeftWall.prevColor = LeftWall.currentColor;
				this.SetLeftBumpColor();
				Switch.SetBallColorAtLeftWall(LeftWall.currentColor);
				this.ChangeLeftWallsColor();
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.GetComponent<Ball>())
		{
			this.index = 0;
		}
	}

	public void InitialState()
	{
		if (LeftWall.initialFlag)
		{
			this.ball = UnityEngine.Object.FindObjectOfType<Ball>();
			this.ChangeCurrentColor();
			this.ChangeLeftWallsColor();
			Switch.SetBallColorAtLeftWall(LeftWall.currentColor);
			this.ball.SetColor(LeftWall.currentColor);
			LeftWall.initialFlag = false;
		}
	}

	private void ChangeLeftWallsColor()
	{
		LeftWall[] array = UnityEngine.Object.FindObjectsOfType<LeftWall>();
		LeftWall[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			LeftWall leftWall = array2[i];
			leftWall.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = LeftWall.currentColor;
		}
	}

	private void ChangeCurrentColor()
	{
		LeftWall.currentColor = ColorManager.SetRandomColor();
	}

	private void SetLeftBumpColor()
	{
		LeftBump leftBump = UnityEngine.Object.FindObjectOfType<LeftBump>();
		leftBump.SetBumpColor(LeftWall.currentColor);
	}
}
