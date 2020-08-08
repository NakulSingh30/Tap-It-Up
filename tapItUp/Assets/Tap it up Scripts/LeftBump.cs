using System;
using UnityEngine;


//FOR RETREIVING LEFT BUMP AND ASSINGING IT A COLOR

public class LeftBump : MonoBehaviour
{
	public void SetBumpColor(Color32 bumpColor)
	{
		LeftBump[] array = UnityEngine.Object.FindObjectsOfType<LeftBump>();
		LeftBump[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			LeftBump leftBump = array2[i];
			leftBump.gameObject.GetComponent<SpriteRenderer>().color = bumpColor;
		}
	}
}
