using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> 
{
	public int maxNotebooks = 7;

	int notebooks;

	// Use this for initialization
	protected virtual void Start() 
	{
		UpdateNotebookCount();
	}
	
	// Update is called once per frame
	protected virtual void Update() 
	{	
	}

	protected virtual void UpdateNotebookCount()
	{
		var count = "{0}";
		if (GameSettings.mode == GameMode.Story)
            count += "/{1}";
		PlayerManager.Instance.hud.UpdateNotebookText(string.Format(count, notebooks, maxNotebooks));
	}

	public virtual void CollectNotebook()
	{
		notebooks++;
		UpdateNotebookCount();
	}
}
