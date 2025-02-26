using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    [SerializeField] bool ignoreMultiplier;
    public List<MovementEffect> list = new List<MovementEffect>();

    public Vector3 Addend
    {
        get
        {
            int priority = int.MinValue;
            var addend = Vector3.zero;
            foreach (var effect in list)
            {
                if (effect.priority > priority)
                {
                    addend = Vector3.zero;
                    priority = effect.priority;
                }
                addend += effect.addend;
            }
            return addend;
        }
    }

    public float Multiplier
    {
        get
        {
            if (ignoreMultiplier)
                return 1;

            float multipler = 1;
            foreach (var effect in list)
                multipler *= effect.multiplier;
            return multipler;
        }
    }
}