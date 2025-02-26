﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchable 
{
    void Hover(Touch touch);
    void Press(Touch touch);
}