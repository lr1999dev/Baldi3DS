using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;

public class Principal : NPC
{
	enum State
	{
		Wandering,
		Angry
	}

	State state;

	public AudioSource audioDevice, whistleAud;

	// Use this for initialization
	void Start () 
	{
		Wander();
    }
	
	void Update () 
	{
		if (state == State.Wandering && navigator.DestinationReached)
		{
			Wander();
            if (!whistleAud.isPlaying && Random.Range(0, 11) == 0)
				whistleAud.Play();
		}
    }
}