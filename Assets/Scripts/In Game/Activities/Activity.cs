using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour 
{
	protected Notebook notebook;

	public virtual void Initialize(Notebook notebook)
	{
		this.notebook = notebook;
	}
}