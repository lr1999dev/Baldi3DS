using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorBaldi : MonoBehaviour 
{
	public AudioSource audioDevice;
    [SerializeField] AudioClip audPrize;
	[SerializeField] GameObject quarter;

    public void Silence()
    {
        audioDevice.Stop();
    }

    public void GiveQuarter()
	{
		quarter.SetActive(true);
		audioDevice.PlayOneShot(audPrize);
	}
}
