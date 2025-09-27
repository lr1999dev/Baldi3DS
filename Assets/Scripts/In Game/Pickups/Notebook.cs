using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : PickupBase 
{
	public Activity activity;

	public override void OnClick()
	{
		if (activity != null)
			Instantiate(activity).Initialize(this);

		SetEnabled(false);
		GameController.Instance.CollectNotebook();
	}
}