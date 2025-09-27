using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPanel : MonoBehaviour 
{
	[SerializeField] GraphicRaycaster raycaster;

	public void Raycast(PointerEventData eventData, List<RaycastResult> results)
    {
        raycaster.Raycast(eventData, results);
    }

    void OnEnable()
    {
        Enabled();
        TouchManager.AllPanels.Add(this);
    }

    void OnDisable()
    {
        Disabled();
        TouchManager.AllPanels.Remove(this);
    }

    protected virtual void Enabled() { }
    protected virtual void Disabled() { }
}