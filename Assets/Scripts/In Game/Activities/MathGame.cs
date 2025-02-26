using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathGame : Activity 
{
	public int maxProblems = 3;

	public override void Initialize(Notebook notebook)
	{
		base.Initialize(notebook);
		Time.timeScale = 0;
		PlayerManager.Instance.ctrl.plc.SetRendering(false);
		Debug.Log("MATH!!!!!!");
	}

	public void End()
	{
		Time.timeScale = 1;
		PlayerManager.Instance.ctrl.plc.SetRendering(true);
		Destroy(gameObject);
	}

	// Use this for initialization
	void Start () 
	{
		Invoke("End", 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
