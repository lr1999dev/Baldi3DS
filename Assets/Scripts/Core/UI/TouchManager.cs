using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchManager : MonoBehaviour 
{
	public static List<TouchPanel> AllPanels = new List<TouchPanel>();
	public static bool paused;

	[SerializeField] EventSystem eventSystem;

	List<RaycastResult> results = new List<RaycastResult>();
	PointerEventData pointerEventData;
	
	void Update () 
	{
		if (paused || Input.touchCount == 0 || AllPanels.Count == 0)
			return;

        var touch = Input.touches[0];
        pointerEventData = new PointerEventData(eventSystem) {
            position = touch.position
        };

        results.Clear();

		int i = AllPanels.Count - 1;
        AllPanels[i].Raycast(pointerEventData, results);

		if (results.Count == 0 || !results[0].gameObject.CompareTag("Touch"))
			return;

        var element = results[0].gameObject.GetComponent<TouchBase>();
        if (element != null)
        {
            element.Hover(touch);
            if (touch.phase == TouchPhase.Ended)
                element.Press(touch);
        }
    }
}