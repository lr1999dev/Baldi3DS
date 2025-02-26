using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementEffect
{
    public MovementEffect(Vector3 addend, float multiplier)
    {
        this.addend = addend;
        this.multiplier = multiplier;
    }

    public Vector3 addend;
    public float multiplier;
    public int priority;

    public bool forceTrigger;
}