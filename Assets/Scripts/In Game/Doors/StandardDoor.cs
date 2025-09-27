using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardDoor : Door, IClickable 
{
    [SerializeField] float timeOpen = 3;
	[SerializeField] Collider barrier;

	public AudioSource audioDevice;
	[SerializeField] AudioClip audOpen, audClose;

    void OnTriggerStay(Collider other)
    {
        if (!Locked && other.CompareTag("NPC"))
            Open(timeOpen);
    }

	public void OnClick()
    {
        if (!Locked)
            Open(timeOpen);
    }

    public override void Open(float t)
    {
		if (!Opened)
        {
			barrier.enabled = false;
			audioDevice.PlayOneShot(audOpen);
        }
        base.Open(t);
    }

    public override void Close()
    {
		barrier.enabled = true;
		audioDevice.PlayOneShot(audClose);
        base.Close();
    }
}
