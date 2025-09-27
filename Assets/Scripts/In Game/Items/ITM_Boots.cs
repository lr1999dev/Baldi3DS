using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITM_Boots : ItemBase
{
	public float time = 30;

	PlayerManager player;

    public override bool Use()
    {
		Instantiate(this).player = PlayerManager.Instance;
        return true;
    }

    void Start () 
	{
		player.ctrl.SetIgnoreEffects(true);
		player.hud.SetTimer(1, time);
	}
	
	void Update () 
	{
		time -= Time.deltaTime;
		if (time <= 0)
		{
            player.ctrl.SetIgnoreEffects(false);
			Destroy(gameObject);
        }
	}
}