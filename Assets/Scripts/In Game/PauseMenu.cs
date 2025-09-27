using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour 
{
	public void Resume()
	{
		GameController.Instance.SetPause(false);
	}

	public void Quit()
	{
		GameController.Instance.QuitGame();
	}
}