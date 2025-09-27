using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour 
{
    void OnWillRenderObject()
    {
        transform.rotation = BillboardManager.rotation;
    }
}