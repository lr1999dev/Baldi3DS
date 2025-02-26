using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour 
{
	public Looker looker;
	public Navigator navigator;

	bool playerInSight;

	public static int activeNPCs;

	void OnEnable()
	{
		AIManager.AllNPCs.Add(this);
	}

	void OnDisable()
	{
		AIManager.AllNPCs.Remove(this);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	public virtual void RaycastTick()
	{
        if (looker.Raycast(PlayerManager.Instance.ctrl.transform))
        {
            if (!playerInSight)
            {
                playerInSight = true;
                PlayerSighted();
            }
            PlayerInSight();
        }
        else if (playerInSight)
        {
            PlayerLost();
            playerInSight = false;
        }
    }

	public virtual void NavigatorUpdateTick()
	{
		navigator.UpdateToFollowTarget();
	}

	protected virtual void PlayerSighted()
	{
	}

	protected virtual void PlayerInSight() 
	{
	}

	protected virtual void PlayerLost()
	{
	}

	protected void TargetPlayer()
	{
		navigator.SetFollowTarget(PlayerManager.Instance.ctrl.transform);
	}
}
