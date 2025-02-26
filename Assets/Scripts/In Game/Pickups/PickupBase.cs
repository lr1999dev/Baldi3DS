using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupBase : MonoBehaviour, IClickable
{
    protected bool isEnabled = true;

    [SerializeField] protected Collider trigger;
    [SerializeField] protected SpriteRenderer sprite;

    public void SetEnabled(bool val)
    {
        sprite.enabled = val;
        trigger.enabled = val;
        
        isEnabled = val;
    }
    
    public abstract void OnClick();
}