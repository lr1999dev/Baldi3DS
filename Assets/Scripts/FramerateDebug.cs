using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateDebug : MonoBehaviour {
       
	public void Switch()
    {
        Application.targetFrameRate = Application.targetFrameRate == 60 ? 30 : 60;
    }
}
