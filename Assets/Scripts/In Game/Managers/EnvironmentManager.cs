using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WanderType
{
    Hall,
    Room,
    Any
}

public class EnvironmentManager : MonoBehaviour 
{
	public Transform[] hallPoints, roomPoints;

	public Vector3 GetWanderPoint(WanderType type)
	{
		if (type == WanderType.Hall)
			return hallPoints.Choice().position;
		if (type == WanderType.Room)
			return roomPoints.Choice().position;
		return GetWanderPoint((WanderType)Random.Range(0, 2));
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
