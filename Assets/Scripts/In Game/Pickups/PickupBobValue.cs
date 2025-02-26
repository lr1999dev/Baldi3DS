using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBobValue : MonoBehaviour
{
	public static float bobVal;
	public float speed = 2f;
	public float multiplier = 0.1f;

	float time;

	void Update()
	{
		time += Time.deltaTime;
		bobVal = Mathf.Sin(time * speed) * multiplier;
	}
}