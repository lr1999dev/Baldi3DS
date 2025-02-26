using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchPad : MonoBehaviour, ITouchable
{
	public UnityEventVector2 onDrag;

	public void Hover(Touch touch)
    {
        onDrag.Invoke(touch.deltaPosition);
    }

    public void Press(Touch touch) { }
}