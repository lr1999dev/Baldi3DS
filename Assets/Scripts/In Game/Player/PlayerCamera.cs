using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour 
{
	public Camera cam;

	Transform jumpscareTarget;
	float jumpscareOffset;

	int cullingMask;

	// Use this for initialization
	void Start()
	{
		float[] distances = new float[32];
		distances[8] = 32;
		cam.layerCullDistances = distances;
		
		cullingMask = cam.cullingMask;
	}

	public void SetRendering(bool val)
	{
		cam.cullingMask = val ? cullingMask : 0;
	}

	// Update is called once per frame
	void LateUpdate()
	{
	}
}
