using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;

[System.Serializable]
public class InputButton
{
    public string displayName;
    public N3dsButton[] bindings;

    public bool GetPressedState(ButtonInputType type = ButtonInputType.Hold)
    {
        for (int i = 0; i < bindings.Length; i++)
        {
            if (type == ButtonInputType.Down)
                return GamePad.GetButtonTrigger(bindings[i]);
            if (type == ButtonInputType.Up)
                return GamePad.GetButtonRelease(bindings[i]);
            return GamePad.GetButtonHold(bindings[i]);
        }
        return false;
    }
}