using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;

public class Debugger : MonoBehaviour 
{
    bool isActive;

    void Update()
    {
        if (GamePad.GetButtonHold(N3dsButton.Start) && GamePad.GetButtonTrigger(N3dsButton.A))
            isActive = !isActive;
    }

    void OnGUI()
    {
        if (!isActive)
            return;

        GUI.color = Color.blue;
        GUI.Label(new Rect(0, 0, 150, 20), Mathf.Round(1f / Time.unscaledDeltaTime) + " FPS");

#if !UNITY_EDITOR && UNITY_N3DS
        GUI.Label(new Rect(0, 20, 150, 20), "New 3DS Mode: " + Main.IsNew3DS);
        GUI.Label(new Rect(0, 40, 150, 20), "System Mem: " + Main.FreeSystemMemory);
        GUI.Label(new Rect(0, 60, 150, 20), "Device Mem: " + Main.FreeDeviceMemory);
#endif
    }
}