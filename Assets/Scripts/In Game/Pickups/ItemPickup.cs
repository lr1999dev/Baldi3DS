using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : PickupBase
{
	[SerializeField] ItemAsset itemAsset;

    public void AssignItem(ItemAsset item)
	{
		if (item == null)
		{
			Debug.LogWarning("Attempted to assign a null ItemAsset", gameObject);
			return;
		}
		itemAsset = item;
		sprite.sprite = item.sprite;
	}

    public override void OnClick()
    {
		SetEnabled(false);
		PlayerManager.Instance.itm.AddItem(itemAsset);
    }
}