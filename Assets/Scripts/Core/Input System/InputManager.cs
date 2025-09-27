using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;

public class InputManager : Singleton<InputManager>
{
    public InputActionSet actionSet;

    public Vector2 GetCirclePad()
    {
        if (actionSet.disableCirclePad)
            return Vector2.zero;
        return GamePad.CirclePad;
    }

    public Vector2 GetCStick()
    {
        if (actionSet.disableCStick)
            return Vector2.zero;
        return GamePad.CirclePadPro;
    }

    public bool GetButton(InputAction action, ButtonInputType type = ButtonInputType.Hold)
    {
        bool result;
        TryGetButton(action, out result, type);
        return result;
    }

    public bool TryGetButton(InputAction action, out bool result, ButtonInputType type = ButtonInputType.Hold)
    {
        InputButton button;
        if (!TryGetActionButton(action, out button))
        {
            result = false;
            return false;
        }
        result = button.GetPressedState(type);
        return true;
    }

    public InputButton GetActionButton(InputAction action)
    {
        InputButton button;
        TryGetActionButton(action, out button);
        return button;
    }

    public bool TryGetActionButton(InputAction action, out InputButton result)
    {
        int i = (int)action;
        if (i < 0 || i >= actionSet.buttons.Length)
        {
            result = null;
            return false;
        }

        result = actionSet.buttons[i];
        return result != null;
    }

    public string GetBindingName(InputAction action, int id = 0)
    {
        InputButton button;
        if (!TryGetActionButton(action, out button))
            return "N/A";
        return button.GetBindingName(id);
    }
}