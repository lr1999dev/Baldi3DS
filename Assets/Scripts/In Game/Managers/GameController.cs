using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController> 
{
    [SerializeField] GameObject pauseMenu;
    public int maxNotebooks = 7;

	int notebooks;

	bool gamePaused;

	// Use this for initialization
	protected virtual void Start() 
	{
		UpdateNotebookCount();
	}
	
	// Update is called once per frame
	protected virtual void Update() 
	{	
		if (GamePad.GetButtonTrigger(N3dsButton.Start))
		{
			SetPause(!gamePaused);
		}
	}

	protected virtual void UpdateNotebookCount()
	{
		var count = "{0}";
		if (GameSettings.mode == GameMode.Story)
            count += "/{1}";
		PlayerManager.Instance.hud.UpdateText(0, string.Format(count, notebooks, maxNotebooks));
	}

	public virtual void CollectNotebook()
	{
		notebooks++;
		UpdateNotebookCount();
	}

	public virtual void SetPause(bool val)
	{
		Time.timeScale = val ? 0 : 1;
		pauseMenu.SetActive(val);
        gamePaused = val;
    }

	public virtual void QuitGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}
}