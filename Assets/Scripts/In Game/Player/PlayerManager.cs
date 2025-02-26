using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager> 
{
	public PlayerController ctrl;
	public PlayerInteract ic;
	public HudManager hud;

	// Use this for initialization
	void Start () 
	{
        Main.AdjustFramerate(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Teleport(Vector3 pos)
    {
		ctrl.transform.position = pos;
		CullingManager.updateNow = true;
    }
}
