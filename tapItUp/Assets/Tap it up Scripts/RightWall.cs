using System;
using UnityEngine;

//ALL FUNCTIONS RELATED TO RIGHT WALL

public class RightWall : MonoBehaviour
{
	private static Color currentColor;

	private static Color prevColor;

	private int index;

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
			if (component.gameObject.tag == "RightCollider")
			{
				UnityEngine.Debug.Log("Right wall color changed");
				this.CurrentColorChange();
				while (RightWall.prevColor == RightWall.currentColor)
				{
					this.CurrentColorChange();
				}
				RightWall.prevColor = RightWall.currentColor;
				this.SetRightBumpColor();
				Switch.SetBallColorAtRightWall(RightWall.currentColor);
				this.ChangeRightWallsColor();
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
		if (RightWall.initialFlag)
		{
			this.CurrentColorChange();
			this.ChangeRightWallsColor();
			Switch.SetBallColorAtRightWall(RightWall.currentColor);
			RightWall.initialFlag = false;
		}
	}

	private void ChangeRightWallsColor()
	{
		RightWall[] array = UnityEngine.Object.FindObjectsOfType<RightWall>();
		RightWall[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RightWall rightWall = array2[i];
			rightWall.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = RightWall.currentColor;
		}
	}

	private void CurrentColorChange()
	{
		RightWall.currentColor = ColorManager.SetRandomColor();
	}

	private void SetRightBumpColor()
	{
		RightBump rightBump = UnityEngine.Object.FindObjectOfType<RightBump>();
		rightBump.SetBumpColor(RightWall.currentColor);
	}
}
