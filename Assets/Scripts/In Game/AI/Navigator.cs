using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Navigator : MonoBehaviour
{
	public NPC npc;
	[SerializeField] float speed = 2;

	public NavMeshAgent Agent { get; private set; }
	public float Speed
	{
		get { return speed; }
		set { speed = value; }
	}

	public bool DestinationEmpty 
	{
		get { return !Agent.hasPath; } 
	}

	public bool DestinationReached
	{
		get 
		{
			if (Agent.pathPending)
				return false;
			return Agent.remainingDistance <= Mathf.Max(0.1f, Agent.stoppingDistance); 
		}
	}

    Transform followTarget;
	int currentPriority;

    void Awake() 
	{
        Agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		npc.RecalculateMoveEffects();

		Agent.speed = speed * npc.MovementMultiplier;
		if (npc.MovementAddend.sqrMagnitude > 0)
			Agent.Move(npc.MovementAddend);
	}

    public void SetDestination(Vector3 target, int priority = 0)
    {
        if (priority >= currentPriority || DestinationEmpty)
        {
            currentPriority = priority;
            Agent.SetDestination(target);
        }
    }

	public void ClearDestination()
	{
		Agent.ResetPath();
	}

	public void Warp(Vector3 target, bool forget = false)
	{
		Agent.Warp(target);
		if (forget)
			ClearDestination();
	}

    public void SetFollowTarget(Transform target)
	{
        if (followTarget != target)
            followTarget = target;
    }

	public void ClearFollowTarget()
	{
		followTarget = null;
	}

	public void UpdateToFollowTarget()
	{
		if (followTarget != null)
			Agent.SetDestination(followTarget.position);
	}
}
