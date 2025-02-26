using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AdjustmentKnob : MonoBehaviour 
{
	[SerializeField] Image image;
	[SerializeField] Sprite[] sprites;

	public AnimationCurve valueCurve;
	public UnityEventFloat onValueChanged;

	int intVal;

	public float FloatVal
    {
		get { return valueCurve.Evaluate((float)intVal / sprites.Length); }
    }

	// Use this for initialization
	void Start () 
	{
		UpdateSprite();
		Adjust(0);
	}

	public void Adjust(int dir)
	{
		intVal += dir;
		if (intVal < 0)
			intVal = sprites.Length - 1;
		else if (intVal >= sprites.Length)
			intVal = 0;
		onValueChanged.Invoke(FloatVal);
		UpdateSprite();
	}

	public void Set(float val)
    {
		for (int i = 0; i < sprites.Length; i++)
        {
			intVal = i;
			if (FloatVal >= val)
				break;
        }
		UpdateSprite();
    }

	void UpdateSprite()
    {
		image.sprite = sprites[intVal];
    }
}
