using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour 
{
	[SerializeField] string scene = "MainMenu";
	[SerializeField] float time = 3;

	// Use this for initialization
	void Start () 
	{
		Invoke("LoadNextScene", time);
	}
	
	void LoadNextScene()
	{
		SceneManager.LoadScene(scene);
	}
}