using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour 
{
	void OnGUI()
    {
        GUI.color = Color.blue;
        GUI.Label(new Rect(0, 0, 60, 20), Mathf.Round(1f / Time.unscaledDeltaTime).ToString());
    }
}
