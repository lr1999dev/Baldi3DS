using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Baldi : NPC
{
	public Animator animator;

	public float baseTime = 3;

	float slapTimer;

	void Start () 
	{
		slapTimer = baseTime;
		// TargetPlayer();
	}
	
	void Update () 
	{
		slapTimer -= Time.deltaTime;
		if (slapTimer <= 0)
		{
			animator.Play("Slap", -1, 0);
			slapTimer = 3;
		}
	}

    protected override void PlayerSighted()
    {
		Debug.Log("I see you!");
		TargetPlayer();
    }

    protected override void PlayerLost()
    {
		Debug.Log("Bye bye!");
		navigator.SetFollowTarget(null);
    }
}