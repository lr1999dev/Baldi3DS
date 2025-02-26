using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardManager : MonoBehaviour 
{
	public Camera cam;
	public static Quaternion camRotation;

	void LateUpdate()
	{
		camRotation = cam.transform.rotation;
	}
}