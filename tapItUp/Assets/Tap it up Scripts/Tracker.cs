using System;
using UnityEngine;

//CAMERA TRACKER

public class Tracker : MonoBehaviour
{
	public Transform ball;

	public Vector3 offset;

	private Vector3 finalPos;

	private void Start()
	{
	}

	private void LateUpdate()
	{
		if (this.ball != null)
		{
			this.finalPos = this.ball.position + this.offset;
			this.finalPos.x = 0f;
			base.transform.position = this.finalPos;
		}
	}
}
