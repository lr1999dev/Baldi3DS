using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.N3DS;
using System.IO;

public class SaveTest : MonoBehaviour {
	public string rootPath = "data:/";
	public Text text;

	int val;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GamePad.GetButtonTrigger(N3dsButton.Up))
			val += 1;
		else if (GamePad.GetButtonTrigger(N3dsButton.Down))
			val -= 1;

		if (GamePad.GetButtonTrigger(N3dsButton.A))
			Save();
		else if (GamePad.GetButtonTrigger(N3dsButton.B))
			Load();

		text.text = val.ToString();
	}

	void Save()
    {
		File.WriteAllText(rootPath + "/test.dat", val.ToString());
    }

	void Load()
    {
		var path = rootPath + "/test.dat";
		if (File.Exists(path))
        {
			val = int.Parse(File.ReadAllText(path));
        }
    }
}
