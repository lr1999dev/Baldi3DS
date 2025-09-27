using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public PlayerManager pm;
    public ItemAsset nothing;
    public ItemAsset[] items = new ItemAsset[3];

    int maxItems;
    int selection;

    int prevSelection;

    void Start()
    {
        maxItems = items.Length;
        for (int i = 0; i < maxItems; i++)
            items[i] = nothing;
        UpdateSelect();
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (InputManager.Instance.GetButton(InputAction.ItemRight, ButtonInputType.Down))
            IncrementSelect(1);
        else if (InputManager.Instance.GetButton(InputAction.ItemLeft, ButtonInputType.Down))
            IncrementSelect(-1);

        if (InputManager.Instance.GetButton(InputAction.UseItem, ButtonInputType.Down))
            UseItem();
    }

    public void IncrementSelect(int val)
    {
        selection += val;
        if (selection < 0)
            selection = maxItems - 1;
        else if (selection >= maxItems)
            selection = 0;
        UpdateSelect();
    }

    public void SetSelection(int val)
    {
        selection = val;
        UpdateSelect();
    }

    public void UpdateSelect()
    {
        if (selection != prevSelection)
            items[prevSelection].item.Deselect();
        prevSelection = selection;

        items[selection].item.Select();
        pm.hud.SetItemSelect(selection, items[selection].displayName);
    }

    public void AddItem(ItemAsset item)
    {
        if (items[selection] == nothing)
        {
            SetItem(selection, item);
            return;
        }

        for (int i = 0; i < maxItems; i++)
        {
            if (items[i] == nothing)
            {
                SetItem(i, item);
                return;
            }
        }

        SetItem(selection, item);
    }

    public void RemoveItem(int slot)
    {
        SetItem(slot, nothing);
    }

    public void SetItem(int slot, ItemAsset item)
    {
        items[slot] = item;
        pm.hud.SetItemIcon(slot, item.sprite);
        if (slot == selection)
            UpdateSelect();
    }

    public void UseItem()
    {
        var selectedItem = items[selection];
        if (InsertItem(selectedItem) || selectedItem.item.Use())
            RemoveItem(selection);
    }

    public bool Full()
    {
        for (int i = 0; i < maxItems; i++)
        {
            if (items[i] == nothing)
                return false;
        }
        return true;
    }

    public bool Take(string itemName)
    {
        for (int i = 0; i < maxItems; i++)
        {
            if (items[i].name == itemName)
            {
                RemoveItem(i);
                return true;
            }
        }
        return false;
    }

    bool InsertItem(ItemAsset item)
    {
        var layerMask = item.acceptLayers;
        if (layerMask == 0) layerMask = pm.ic.clickLayers;

        RaycastHit hit;
        if (pm.ic.Raycast(layerMask, out hit))
        {
            var acceptor = hit.transform.GetComponent<IItemAcceptor>();
            if (acceptor != null && acceptor.ItemFits(item.name))
            {
                acceptor.InsertItem(item.name);
                return true;
            }
        }
        return false;
    }
}