using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField] Text[] texts;
    [SerializeField] ItemSlot[] itemSlots;
    [SerializeField] HudTimer[] timers;

    [SerializeField] Slider staminaBar;

    int curItemSlot = 0;

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateText(int id, string text)
    {
        texts[id].text = text;
    }

    public void SetItemSelect(int slot, string itemName)
    {
        itemSlots[curItemSlot].SetSelected(false);
        itemSlots[slot].SetSelected(true);
        UpdateText(1, itemName);

        curItemSlot = slot;
    }

    public void SetItemIcon(int slot, Sprite spr)
    {
        itemSlots[slot].SetItemIcon(spr);
    }

    public void UpdateStamina(float val)
    {
        staminaBar.value = Mathf.Round(val);
    }

    public void SetTimer(int id, float time)
    {
        timers[id].SetTime(time);
    }
}