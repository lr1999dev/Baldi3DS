using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager> 
{
	public PlayerController ctrl;
	public PlayerInteract ic;

	public ItemManager itm;
	public HudManager hud;

    public bool Disobeying { get { return guilt > 0; } }
    public string GuiltType { get; private set; }

    float guilt;

    void Start () 
	{
        Main.AdjustFramerate(true);
    }
	
	void Update () 
	{
		if (guilt > 0)
			guilt -= Time.deltaTime;
	}

    public void ApplyGuilt(string type, float amount, bool force = false)
    {
        if (amount >= guilt || force)
        {
            guilt = Mathf.Max(amount, 0);
            GuiltType = type;
        }
    }

    public void ClearGuilt()
    {
        guilt = 0;
        GuiltType = "";
    }
}
