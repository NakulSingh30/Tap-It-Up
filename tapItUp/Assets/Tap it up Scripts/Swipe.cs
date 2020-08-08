using System;
using UnityEngine;

//FOR DETECTING SWIPE FROM THE USER

public class Swipe : MonoBehaviour
{
	private bool tap;

	private bool swipeLeft;

	private bool swipeRight;

	private bool swipeUp;

	private bool swipeDown;

	private Vector2 startingPosition;

	private Vector2 swipeDelta;

	private bool isDragging;

	public bool SwipeLeft
	{
		get
		{
			return this.swipeLeft;
		}
	}

	public bool SwipeRight
	{
		get
		{
			return this.swipeRight;
		}
	}

	public bool SwipeUp
	{
		get
		{
			return this.swipeUp;
		}
	}

	public bool SwipeDown
	{
		get
		{
			return this.swipeDown;
		}
	}

	public bool Tap
	{
		get
		{
			return this.tap;
		}
	}

	private void Update()
	{
		this.swipeDown = false; this.tap = (this.swipeLeft = (this.swipeRight = (this.swipeUp = (this.swipeDown ))));
		if (Input.touchCount > 0)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				this.tap = true;
				this.startingPosition = Input.GetTouch(0).position;
				this.isDragging = true;
			}
			else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
			{
				this.SwipeReset();
			}
		}
		this.swipeDelta = Vector2.zero;
		if (this.isDragging && Input.touchCount > 0)
		{
			this.swipeDelta = Input.GetTouch(0).position - this.startingPosition;
		}
		if (this.swipeDelta.magnitude > 25f)
		{
			this.Calculate();
			this.SwipeReset();
		}
	}

	private void Calculate()
	{
		float x = this.swipeDelta.x;
		float y = this.swipeDelta.y;
		if (Mathf.Abs(x) > Mathf.Abs(y))
		{
			if (x < 0f)
			{
				this.swipeLeft = true;
			}
			else
			{
				this.swipeRight = true;
			}
		}
		else if (y < 0f)
		{
			this.swipeDown = true;
		}
		else
		{
			this.swipeUp = true;
		}
	}

	private void SwipeReset()
	{
		this.swipeDelta = Vector2.zero; this.startingPosition = (this.swipeDelta );
		this.isDragging = false;
	}
}
