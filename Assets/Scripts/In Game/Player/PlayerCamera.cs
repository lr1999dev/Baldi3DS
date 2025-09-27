using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour 
{
	public Camera cam, mapCam;

	Transform scareTarget;
	float scareOffset;

	int cullingMask, mapCamMask;

	Vector3 basePosition, positionOffset;

	// Use this for initialization
	void Start()
	{
		float[] distances = new float[32];
		distances[8] = 32;
		cam.layerCullDistances = distances;
		
		cullingMask = cam.cullingMask;
		mapCamMask = mapCam.cullingMask;

		basePosition = transform.localPosition;
	}

	public void SetRendering(bool val)
	{
		cam.cullingMask = val ? cullingMask : 0;
		mapCam.cullingMask = val ? mapCamMask : 0;
	}

	public void SetPositionOffset(Vector3 offset)
	{
		positionOffset = offset;
	}

	public void Scare(Transform target, float offset)
	{
		scareTarget = target;
		scareOffset = offset;
	}

	// Update is called once per frame
	void Update()
	{
		if (scareTarget != null)
		{
			var up = Vector3.up * scareOffset;
            transform.position = scareTarget.position + scareTarget.forward * 3 + up;
            transform.LookAt(scareTarget.position + up);
            return;
		}

		int lb = InputManager.Instance.GetButton(InputAction.LookBehind) ? 180 : 0;
		transform.localRotation = Quaternion.Euler(0, lb, 0);
		transform.localPosition = basePosition + positionOffset;
	}
}