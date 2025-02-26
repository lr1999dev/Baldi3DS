using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchUI : MonoBehaviour 
{
	[SerializeField] GraphicRaycaster raycaster;

	public void Raycast(PointerEventData eventData, List<RaycastResult> results)
    {
        raycaster.Raycast(eventData, results);
    }

    void OnEnable()
    {
        Enabled();
        TouchManager.AllTouchUI.Insert(0, this);
    }

    void OnDisable()
    {
        Disabled();
        TouchManager.AllTouchUI.Remove(this);
    }

    protected virtual void Enabled() { }
    protected virtual void Disabled() { }
}