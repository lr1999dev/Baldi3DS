using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardDoor : Door, IClickable {
	[SerializeField] Collider barrier;

	[SerializeField] AudioSource audioDevice;
	[SerializeField] AudioClip audOpen, audClose;

    /*
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("NPC"))
            Open(3);
    }
    */

	public void OnClick()
    {
        if (!Locked)
            Open(3);
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
