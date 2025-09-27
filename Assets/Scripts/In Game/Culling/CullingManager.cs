using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingManager : MonoBehaviour 
{
	public static List<CullingGroup> AllCullingGroups = new List<CullingGroup>();
	public static bool updateNow;

	public Camera cam;
	public float updateRate = 0.05f;

	float timer;

	// Use this for initialization
	void Start () 
	{
		timer = updateRate;
		UpdateCulling();
	}

	void Update()
	{
		timer -= Time.unscaledDeltaTime;
		if (timer <= 0 || updateNow)
		{
			UpdateCulling();
            timer = updateRate;
            updateNow = false;
        }
	}

	void UpdateCulling()
    {
        for (int i = 0; i < AllCullingGroups.Count; i++)
            AllCullingGroups[i].UpdateCullingState(cam.transform.position);
	}
}