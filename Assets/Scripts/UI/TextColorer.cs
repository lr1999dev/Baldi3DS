using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextColorer : MonoBehaviour 
{
	[SerializeField] Color[] colors = new Color[2];

	Text text;

	void Awake()
	{
		text = GetComponent<Text>();
	}

	public void SetColor(int id)
	{
		text.color = colors[id];
	}
}
