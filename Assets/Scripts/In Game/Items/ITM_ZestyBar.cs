using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITM_ZestyBar : ItemBase 
{
    public override bool Use()
    {
        PlayerManager.Instance.ctrl.RefillStamina(2);
        return true;
    }
}