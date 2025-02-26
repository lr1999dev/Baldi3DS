using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour 
{
	public UnityEvent[] events;

	public void CallEvent(int i)
	{
		events[i].Invoke();
	}
}