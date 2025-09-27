using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MovableEntity 
{
	[Space]
	public Looker looker;
	public Navigator navigator;
	public EnvironmentManager em;

	public PlayerManager Player { get { return PlayerManager.Instance; } }

    bool playerInSight;

    void OnEnable()
	{
		AIManager.AllNPCs.Add(this);
	}

	void OnDisable()
	{
		AIManager.AllNPCs.Remove(this);
	}
	
	public virtual void RaycastTick()
	{
        if (looker.Raycast(Player.ctrl.transform))
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

	protected virtual void TargetPlayer()
	{
		navigator.SetFollowTarget(Player.ctrl.transform);
	}

    protected virtual void Wander(WanderType type = WanderType.Any)
    {
		navigator.SetDestination(em.GetWanderPoint(type));
    }
}