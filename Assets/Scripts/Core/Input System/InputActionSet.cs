using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Input Action Set", menuName = "Custom Assets/Input Action Set")]
public class InputActionSet : ScriptableObject 
{
    public bool disableCirclePad, disableCStick;
    public InputButton[] buttons = new InputButton[8];
}