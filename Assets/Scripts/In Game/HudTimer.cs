using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudTimer : MonoBehaviour 
{
	[SerializeField] GameObject visual;
	[SerializeField] Slider slider;

	float initialTime, timeLeft;
	bool isActive;

	public void SetTime(float time)
	{
		if (!isActive)
			visual.SetActive(true);

        isActive = true;
        initialTime = timeLeft = time;
        UpdateValue();
	}

    void UpdateValue()
	{
		slider.value = Mathf.Round((timeLeft / initialTime) * slider.maxValue);
	}

    void Update()
	{
		if (timeLeft > 0)
		{
			timeLeft -= Time.deltaTime;
			UpdateValue();
		}
		else if (isActive)
		{
			visual.SetActive(false);
			isActive = false;
		}
	}
}