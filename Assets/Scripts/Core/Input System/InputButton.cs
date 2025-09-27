using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;

[System.Serializable]
public class InputButton
{
    public string displayName;
    public N3dsButton[] bindings;

    public string GetBindingName(int id = 0)
    {
        if (id >= bindings.Length)
            return "N/A";
        return bindings[id].ToString();
    }

    public bool GetPressedState(ButtonInputType type = ButtonInputType.Hold)
    {
        if (bindings.Length == 0)
            return false;

        for (int i = 0; i < bindings.Length; i++)
        {
            switch (type)
            {
                case ButtonInputType.Down:
                    if (GamePad.GetButtonTrigger(bindings[i])) return true;
                    break;
                case ButtonInputType.Up:
                    if (GamePad.GetButtonRelease(bindings[i])) return true;
                    break;
                default:
                    if (GamePad.GetButtonHold(bindings[i])) return true;
                    break;
            }
        }
        return false;
    }
}