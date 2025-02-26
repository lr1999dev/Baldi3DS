using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
	[SerializeField] float clickDistance = 2;
	[SerializeField] LayerMask clickLayers;

	RaycastHit hit;
	IClickable clickTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.timeScale != 0 && InputManager.Instance.GetButton(InputAction.Interact, ButtonInputType.Down))
        {
			if (Physics.Raycast(transform.position, transform.forward, out hit, clickDistance, clickLayers))
			{
                clickTarget = hit.transform.GetComponent<IClickable>();
                if (clickTarget != null)
                    clickTarget.OnClick();
            }
        }
	}
}