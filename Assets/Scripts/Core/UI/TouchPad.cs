using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchPad : TouchBase
{
	public UnityEvent_Vector2 onDrag;

	public override void Hover(Touch touch)
    {
        onDrag.Invoke(touch.deltaPosition);
    }

    public override void Press(Touch touch) { }
}