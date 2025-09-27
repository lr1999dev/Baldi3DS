using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardManager : MonoBehaviour 
{
	public Camera cam;
	public static Quaternion rotation;

	void Start()
	{
		if (cam == null)
			cam = Camera.main;
	}

	void LateUpdate()
	{
		rotation = Quaternion.LookRotation(cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
	}
}