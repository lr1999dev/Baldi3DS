using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour 
{
	[SerializeField] Text notebookCount;
	[SerializeField] Slider staminaBar;
	
	public void UpdateStamina(float stamina)
    {
		staminaBar.value = Mathf.Round(stamina);
    }

	public void UpdateNotebookText(string text)
	{
		notebookCount.text = text;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
