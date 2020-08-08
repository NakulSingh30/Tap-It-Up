using System;
using UnityEngine;

//ALL FUNTIONS OF OBSTACLES

public class Bump : MonoBehaviour
{
	private SpriteRenderer bumpSprite;
    int index;

	private void Awake()
	{
        index = 0;
		this.bumpSprite = base.GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
        if (collider.GetComponent<Ball>() && index == 0) 
		{
			GameOver gameOver = UnityEngine.Object.FindObjectOfType<GameOver>();
			gameOver.TriggerResetAnimation();
            index++;
		}
		if (collider.gameObject.tag == "LeftCollider")
		{
			this.ColorChange(collider.gameObject);
		}
		else if (collider.gameObject.tag == "RightCollider")
		{
			this.ColorChange(collider.gameObject);
		}
	}

	private void ColorChange(GameObject wall)
	{
		if (wall.GetComponent<Wall>())
		{
			this.bumpSprite.color = wall.GetComponent<SpriteRenderer>().color;
		}
	}
}
