using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour 
{
    [SerializeField] int id;
    [SerializeField] Image bg, icon;

    public Color normalColor = Color.white, 
        selectedColor = Color.red;

    public void SetSelected(bool val)
    {
        bg.color = val ? selectedColor : normalColor;
    }

    public void SetItemIcon(Sprite spr)
    {
        icon.sprite = spr;
    }

    public void Pressed()
    {
        PlayerManager.Instance.itm.SetSelection(id);
    }
}