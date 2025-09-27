using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : MonoBehaviour 
{
	[SerializeField] LayerMask layerMask;

	public float maxDistance = 2000;
	public float nearSightDistance = 0.6f;

	LayerMask playerMask, npcMask;
	Ray ray; RaycastHit hit;

	void Start () 
	{
		playerMask = layerMask | LayerMask.GetMask("Player");
        npcMask = layerMask | LayerMask.GetMask("Non-Player");
    }

    public bool Raycast(Transform target)
    {
		LayerMask mask = target.CompareTag("Player") ? playerMask : npcMask;
        if (mask != (mask | (1 << target.gameObject.layer)))
            return false;

        float dist = Vector3.Distance(transform.position, target.position);
        if (dist > maxDistance)
            return false;
        if (dist <= nearSightDistance)
            return true;

        ray.origin = transform.position;
        ray.direction = target.position - transform.position;
        return Physics.Raycast(ray, out hit, maxDistance, mask) && hit.transform == target;
    }
}
