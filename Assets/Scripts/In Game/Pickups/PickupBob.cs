using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBob : MonoBehaviour 
{
	private void OnWillRenderObject()
    {
		transform.localPosition = Vector3.up * PickupBobValue.bobVal;
    }
}
