using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playtime : NPC 
{
	enum State
	{
		Wandering,
		Pursuing,
		Playing
	}

	public Animator animator;

	[Space]
	public AudioSource audioDevice;
    [SerializeField] AudioClip[] audCount, audCallouts;
    [SerializeField] AudioClip audLetsPlay, audReady, 
		audOops, audCongrats, audSad;

	[Space]
	public float normalSpeed = 3;
	public float runSpeed = 4;
    public float initCooldown = 15;

    float coolDown;
	State state;

	void Start () 
	{
		Wander();
	}
	
	void Update () 
	{
		if (state == State.Playing) 
			return;

		if (state == State.Wandering)
		{
			coolDown = Mathf.Max(coolDown - Time.deltaTime, 0);
			if (coolDown <= 0)
				animator.SetBool("Sad", false);
		}

        if (navigator.DestinationReached)
			Wander();
	}

    protected override void Wander(WanderType type = WanderType.Hall)
    {
        state = State.Wandering;
        navigator.Speed = normalSpeed;
		// audioDevice.PlayOneShot(audCallouts.Choice());
        base.Wander(type);
    }

    protected override void PlayerInSight()
    {
        if (state == State.Wandering && coolDown <= 0)
		{
			state = State.Pursuing;
            navigator.Speed = runSpeed;
			audioDevice.PlayOneShot(audLetsPlay);
            TargetPlayer();
        }
    }

    protected override void PlayerLost()
    {
        if (state == State.Pursuing)
		{
			navigator.ClearFollowTarget();
        }
    }

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player") && state == State.Pursuing)
		{
			navigator.Speed = 0;
			navigator.ClearFollowTarget();
            navigator.Warp(transform.position - transform.forward * 1.5f);

            BeginJumprope();
		}
	}

	void BeginJumprope()
	{
        state = State.Playing;
		audioDevice.PlayOneShot(audReady);
        Jumprope.Instance.Restart(this);
    }

	public void Count(int num)
	{
		audioDevice.PlayOneShot(audCount[num]);
	}

	public void Oops()
	{
		audioDevice.PlayOneShot(audOops);
	}

	public void EndJumprope(bool success)
	{
		if (success)
		{
			audioDevice.PlayOneShot(audCongrats);
		}
		else
		{
			audioDevice.PlayOneShot(audSad);
			animator.SetBool("Sad", true);
        }
		coolDown = initCooldown;
		Wander();
	}
}