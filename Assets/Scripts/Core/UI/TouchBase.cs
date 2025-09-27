using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TouchBase : MonoBehaviour 
{
    public abstract void Hover(Touch touch);
    public abstract void Press(Touch touch);
}
