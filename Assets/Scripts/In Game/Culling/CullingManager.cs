using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingManager : MonoBehaviour 
{
	public static List<CullingGroup> AllCullingGroups = new List<CullingGroup>();
	public static bool updateNow;

	public Camera cam;
	public float updateRate = 0.05f;

	float timeUntilUpdate;

	// Use this for initialization
	void Start () 
	{
		timeUntilUpdate = updateRate;
		UpdateCulling();
	}

	void Update()
	{
		timeUntilUpdate -= Time.unscaledDeltaTime;
		if (timeUntilUpdate <= 0 || updateNow)
		{
			UpdateCulling();
            timeUntilUpdate = updateRate;
            updateNow = false;
        }
	}

	void UpdateCulling()
    {
        for (int i = 0; i < AllCullingGroups.Count; i++)
            AllCullingGroups[i].UpdateCullingState(cam.transform.position);
	}
}