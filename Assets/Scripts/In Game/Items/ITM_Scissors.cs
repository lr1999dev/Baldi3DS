using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITM_Scissors : ItemBase 
{
    public override bool Use()
    {
        if (Jumprope.Instance.InProgress)
        {
            Jumprope.Instance.End(false);
            return true;
        }
        return false;
    }
}