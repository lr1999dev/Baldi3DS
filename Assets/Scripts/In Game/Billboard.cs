using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour 
{
    void OnWillRenderObject()
    {
        transform.LookAt(transform.position + BillboardManager.camRotation * Vector3.forward);
    }
}
