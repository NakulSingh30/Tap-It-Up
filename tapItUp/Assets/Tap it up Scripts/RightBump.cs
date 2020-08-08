using System;
using UnityEngine;

//FOR RETREIVING RIGHT BUMP AND ASSINGING IT A COLOR

public class RightBump : MonoBehaviour
{
	public void SetBumpColor(Color32 bumpColor)
	{
		RightBump[] array = UnityEngine.Object.FindObjectsOfType<RightBump>();
		RightBump[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RightBump rightBump = array2[i];
			rightBump.gameObject.GetComponent<SpriteRenderer>().color = bumpColor;
		}
	}
}
