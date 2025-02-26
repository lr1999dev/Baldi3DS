using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public MeshRenderer doorRenderer;
    public Material open, closed, locked;

    protected float openTime, lockTime;

    public bool Opened { get; protected set; }
    public bool Locked { get; protected set; }

    // Update is called once per frame
    void Update()
    {
        if (openTime > 0)
            openTime -= Time.deltaTime;
        else if (Opened)
            Close();

        if (lockTime > 0)
            lockTime -= Time.deltaTime;
        else if (Locked)
            Unlock();
    }

    public virtual void Open(float t)
    {
        if (t > openTime)
            openTime = t;
        if (!Opened)
            doorRenderer.sharedMaterial = open;
        Opened = true;
    }

    public virtual void Lock(float t)
    {
        if (Opened)
            Close();
        if (t > lockTime)
            lockTime = t;
        doorRenderer.sharedMaterial = locked;
        Locked = true;
    }

    public virtual void Close()
    {
        openTime = 0;
        Opened = false;
        doorRenderer.sharedMaterial = closed;
    }

    public virtual void Unlock()
    {
        lockTime = 0;
        Locked = false;
        doorRenderer.sharedMaterial = closed;
    }
}
