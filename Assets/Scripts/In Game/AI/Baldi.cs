using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Baldi : NPC
{
	public Animator animator;

	public float baseTime = 3;

	float slapTimer;

	// Use this for initialization
	void Start () 
	{
		slapTimer = baseTime;
		// TargetPlayer();
	}
	
	// Update is called once per frame
	void Update () 
	{
		slapTimer -= Time.deltaTime;
		if (slapTimer <= 0)
		{
			animator.Play("Slap", -1, 0);
			slapTimer = 0.5f;
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
