using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwingDoor : Door
{
    [SerializeField] Collider barrier;
    [SerializeField] NavMeshObstacle obstacle;

    [SerializeField] AudioSource audioDevice;
    [SerializeField] AudioClip audOpen;

    void OnTriggerStay(Collider other)
    {
        if (Locked)
            return;

        if (!Opened)
        {
            audioDevice.PlayOneShot(audOpen);
            if (other.CompareTag("Player"))
            {
                // hearing code here
            }
        }
        Open(3);
    }

    public override void Lock(float t)
    {
        barrier.enabled = true;
        obstacle.enabled = true;
        base.Lock(t);
    }

    public override void Unlock()
    {
        barrier.enabled = false;
        obstacle.enabled = false;
        base.Unlock();
    }
}
