using System;
using UnityEngine;

//// FOR INSTANTIATION OF WALLS AT EQUAL INTERVALS OF DISTANCE

public class Instantiate : MonoBehaviour
{
	private GameObject WallsParent;

	private void Start()
	{
		this.WallsParent = GameObject.Find("WallsParent");
		if (!this.WallsParent)
		{
			this.WallsParent = new GameObject("WallsParent");
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.GetComponent<Ball>())
		{
			this.Instantiation();
		}
	}

	private void Instantiation()
	{
		GameObject gameObject = base.transform.parent.gameObject;
		Vector3 position = gameObject.transform.position;
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject, this.IncrementPos(position), Quaternion.identity);
		gameObject2.transform.SetParent(this.WallsParent.transform);
	}

	private Vector3 IncrementPos(Vector3 newPosition)
	{
		newPosition.y += 10f;
		return newPosition;
	}
}
