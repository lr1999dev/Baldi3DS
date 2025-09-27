using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
	[SerializeField] float clickDistance = 2;
	public LayerMask clickLayers;

	RaycastHit hit;
	IClickable clickTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.timeScale == 0)
			return;

        if (InputManager.Instance.GetButton(InputAction.Interact, ButtonInputType.Down) && Raycast(clickLayers, out hit))
        {
            clickTarget = hit.transform.GetComponent<IClickable>();
            if (clickTarget != null)
                clickTarget.OnClick();
        }
	}

	public bool Raycast(LayerMask mask, out RaycastHit hit)
	{
		return Physics.Raycast(transform.position, transform.forward, out hit, clickDistance, mask);
	}
}