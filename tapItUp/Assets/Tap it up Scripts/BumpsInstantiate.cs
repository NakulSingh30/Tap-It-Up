using System;
using UnityEngine;


// FOR INSTANTIATION OF OBSTACLES AT EQUAL INTERVALS OF DISTANCE

public class BumpsInstantiate : MonoBehaviour
{
	private Vector3 currentPosition;

	private Bumps[] BumpsArray;

	private Bumps[] LongBumpsArray;

	private int bumpDistance = 10;

	private float bumpTimer = 1f;

	private float longBumpTimer = 5f;

	private void Awake()
	{
		this.BumpsArray = Resources.LoadAll<Bumps>("Prefabs/Bumps");
		this.LongBumpsArray = Resources.LoadAll<Bumps>("Prefabs/LongBumps");
	}

	private void Start()
	{
		this.currentPosition = base.transform.position;
		this.BumpInstantiation();
		this.LongBumpInstantiation();
	}

	private void BumpInstantiation()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BumpsArray[UnityEngine.Random.Range(0, this.BumpsArray.Length)].gameObject, this.currentPosition, Quaternion.identity);
		this.CurrentPositionIncrement();
		gameObject.transform.SetParent(base.transform);
		base.Invoke("BumpInstantiation", this.bumpTimer);
	}

	private void LongBumpInstantiation()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LongBumpsArray[UnityEngine.Random.Range(0, this.LongBumpsArray.Length)].gameObject, this.currentPosition, Quaternion.identity);
		this.CurrentPositionIncrement();
		gameObject.transform.SetParent(base.transform);
		base.Invoke("LongBumpInstantiation", this.longBumpTimer);
	}

	private void CurrentPositionIncrement()
	{
        this.currentPosition.y += bumpDistance;
	}
}
