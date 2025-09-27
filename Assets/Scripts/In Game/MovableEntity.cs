using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableEntity : MonoBehaviour
{
    public List<MovementEffect> allEffects;

    public Vector3 MovementAddend { get; private set; }
    public float MovementMultiplier { get; private set; }

    int effectIgnores;

    public void RecalculateMoveEffects()
    {
        var addend = Vector3.zero;
        var multiplier = 1f;

        int priority = int.MinValue;
        foreach (var effect in allEffects)
        {
            if (effectIgnores > 0 && !effect.force)
                continue;

            multiplier *= effect.multiplier;
            if (effect.priority > priority)
            {
                addend = Vector3.zero;
                priority = effect.priority;
            }
            addend += effect.addend;
        }

        MovementAddend = addend;
        MovementMultiplier = multiplier;
    }

    public void SetIgnoreEffects(bool val)
    {
        if (val)
        {
            effectIgnores++;
            return;
        }
        effectIgnores = Mathf.Max(effectIgnores - 1, 0);
    }
}