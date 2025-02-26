using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchManager : MonoBehaviour 
{
	public static List<TouchUI> AllTouchUI = new List<TouchUI>();
	public static bool paused;

	[SerializeField] EventSystem eventSystem;

	List<RaycastResult> results = new List<RaycastResult>();
	PointerEventData pointerEventData;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!paused && Input.touchCount > 0 && AllTouchUI.Count > 0)
		{
			var touch = Input.touches[0];

			pointerEventData = new PointerEventData(eventSystem) {
				position = touch.position
			};

			results.Clear();
			AllTouchUI[0].Raycast(pointerEventData, results);

			if (results.Count > 0 && results[0].gameObject != null && results[0].gameObject.CompareTag("Touch"))
			{
				var button = results[0].gameObject.GetComponent<ITouchable>();
				if (button != null)
                {
					button.Hover(touch);
					if (touch.phase == TouchPhase.Ended)
						button.Press(touch);
				}
			}
		}
	}
}