using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingGroup : MonoBehaviour
{
    [SerializeField] CullingBox[] boxes = new CullingBox[0];

    Renderer[] allRenderers;
    bool visible = true;

    void OnEnable()
    {
        CullingManager.AllCullingGroups.Add(this);
    }

    void OnDisable()
    {
        CullingManager.AllCullingGroups.Remove(this);
    }

    void Awake()
    {
        allRenderers = GetComponentsInChildren<Renderer>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < boxes.Length; i++)
            Gizmos.DrawWireCube(transform.position + boxes[i].offset, boxes[i].size);
    }

    public bool WithinBounds(int boxIndex, Vector3 position)
    {
        var pos = transform.position + boxes[boxIndex].offset;
        var boxCenter = boxes[boxIndex].size / 2;

        var min = pos - boxCenter;
        var max = pos + boxCenter;

        return position.x >= min.x && position.x <= max.x &&
                position.y >= min.y && position.y <= max.y &&
                position.z >= min.z && position.z <= max.z;
    }

    public void UpdateCullingState(Vector3 position)
    {
        SetVisibility(IsTouching(position));
    }

    public bool IsTouching(Vector3 position)
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            if (WithinBounds(i, position)) 
                return true;
        }
        return false;
    }

	public void SetVisibility(bool val)
    {
        if (visible != val)
        {
            visible = val;
            for (int i = 0; i < allRenderers.Length; i++)
                allRenderers[i].gameObject.SetActive(val);
        }
    }
}
