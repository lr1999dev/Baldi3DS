using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchButton : TouchBase
{
    [SerializeField] UnityEvent onHighlight, onUnhighlight, onClick;

    bool wasHighlighted, highlighted;
    float holdTime;

    void Start() {
    }
	
	void Update()
    {
        if (!highlighted && wasHighlighted)
        {
            wasHighlighted = false;
            Unhighlight();
        }
        highlighted = false;
    }

    void Unhighlight()
    {
        onUnhighlight.Invoke();
    }

    public override void Hover(Touch touch)
    {
        if (!highlighted)
            onHighlight.Invoke();

        wasHighlighted = true;
        highlighted = true;
    }

    public override void Press(Touch touch)
    {
        onClick.Invoke();
        Unhighlight();
    }
}
