using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;

public class InputManager : Singleton<InputManager>
{
    public InputActionSet actionSet;

    public Vector2 GetCirclePad()
    {
        if (!actionSet.disableCirclePad)
            return GamePad.CirclePad;
        return Vector2.zero;
    }

    public Vector2 GetCStick()
    {
        if (!actionSet.disableCStick)
            return GamePad.CirclePadPro;
        return Vector2.zero;
    }

    public bool GetButton(InputAction action, ButtonInputType type = ButtonInputType.Hold)
    {
        bool result;
        TryGetButton(action, out result, type);
        return result;
    }

    public bool TryGetButton(InputAction action, out bool result, ButtonInputType type = ButtonInputType.Hold)
    {
        var button = actionSet.buttons[(int)action];
        if (button == null)
        {
            result = false;
            return false;
        }
        result = button.GetPressedState(type);
        return true;
    }
}