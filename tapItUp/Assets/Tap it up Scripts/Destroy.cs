using System;
using UnityEngine;



//DESTROYING BALL/GAMEOBJECT WHEN BALL COLLIDES WITH WALL OF WRONG COLOR OR IT COLLIDES WITH OBSTACLE


public class Destroy : MonoBehaviour
{
	private void OnTriggerExit2D(Collider2D collider)
	{
        Debug.Log(collider.gameObject);
		UnityEngine.Object.Destroy(collider.transform.parent.gameObject);
	}

}
