using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Navigator : MonoBehaviour
{
	NavMeshAgent agent;

	Transform followTarget;
	float followUpdateRate, followTimer;

	public bool DestinationEmpty 
	{  
		get { return !agent.hasPath; } 
	}

	// Use this for initialization
	void Start() 
	{
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{
		if (followTarget != null)
		{
			followTimer -= Time.deltaTime;
			if (followTimer <= 0)
			{
				agent.SetDestination(followTarget.position);
				followTimer = followUpdateRate;
			}
		}
	}

	public void SetFollowTarget(Transform target, float updateRate = 0.1f)
	{
        followTarget = target;
		followUpdateRate = updateRate;
		followTimer = 0;
	}

	public void UpdateToFollowTarget()
	{
		if (followTarget != null)
			agent.SetDestination(followTarget.position);
	}
}
