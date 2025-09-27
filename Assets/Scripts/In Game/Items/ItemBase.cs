using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public virtual bool Use()
    {
        return false;
    }

    public virtual void Select() { }
    public virtual void Deselect() { }
}