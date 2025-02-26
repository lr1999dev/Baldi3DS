using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
	public static List<NPC> AllNPCs = new List<NPC>();

	public float raycastRate = 0.05f;
	public float navUpdateRate = 0.1f;

    float raycastDelay, navUpdateDelay;

    // Use this for initialization
    void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (AllNPCs.Count == 0 || Time.timeScale == 0)
		{
			raycastDelay = 0;
			navUpdateDelay = 0;
			return;
		}

		raycastDelay -= Time.unscaledDeltaTime;
		navUpdateDelay -= Time.unscaledDeltaTime;

        for (int i = 0; i < AllNPCs.Count; i++)
		{
			if (raycastDelay <= 0)
                AllNPCs[i].RaycastTick();
			if (navUpdateDelay <= 0)
                AllNPCs[i].NavigatorUpdateTick();
        }

        if (raycastDelay <= 0) raycastDelay = raycastRate;
        if (navUpdateDelay <= 0) navUpdateDelay = navUpdateRate;
    }
}