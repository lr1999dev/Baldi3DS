using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovableEntity
{
	[Space, SerializeField] 
	CharacterController cc;

	public PlayerManager pm;
	public PlayerCamera plc;

	public float walkSpeed = 2f, runSpeed = 3.2f;
	public float staminaDrop = 10, staminaRise = 15;
	public float maxStamina = 100;

	float stamina;
	bool running;

	void Start () 
	{
		stamina = maxStamina;
	}
	
	void Update () 
	{
		running = InputManager.Instance.GetButton(InputAction.Run);
		Move(InputManager.Instance.GetCirclePad());

		var lookVal = InputManager.Instance.GetCStick();
		if (lookVal.sqrMagnitude == 0)
        {
			if (InputManager.Instance.GetButton(InputAction.LookRight))
				lookVal.x += 1;
			if (InputManager.Instance.GetButton(InputAction.LookLeft))
				lookVal.x -= 1;
        }
		Look(lookVal * Time.deltaTime * 60);
	}

	public void Move(Vector2 input)
    {
		var moveX = transform.right * input.x;
		var moveZ = transform.forward * input.y;

		float speed = walkSpeed;
		if (running && stamina > 0)
			speed = runSpeed;

		var desiredMovement = (moveX + moveZ).normalized * speed;
		var movement = desiredMovement * Time.deltaTime;

		RecalculateMoveEffects();
        cc.Move(movement * MovementMultiplier + MovementAddend);

		UpdateStamina(desiredMovement.magnitude);
    }

	public void Look(Vector2 input)
    {
		transform.eulerAngles += input.x * 5 * Vector3.up; // 5 is a placeholder for the look sensitivity
    }

	public void RefillStamina(float multiplier = 1)
	{
		stamina = maxStamina * multiplier;
	}

	public void Teleport(Vector3 pos)
	{
		cc.enabled = false;
		if (pos.y < transform.position.y)
			pos.y = transform.position.y;
		transform.position = pos;
		cc.enabled = true;
	}

	void UpdateStamina(float rawSpeed)
    {
		if (rawSpeed > cc.minMoveDistance && cc.velocity.magnitude > 0)
		{
			if (stamina > 0 && running)
			{
                stamina -= staminaDrop * Time.deltaTime;
				pm.ApplyGuilt("Running", 0.1f);
            }
		}
		else if (stamina < maxStamina)
		{
			stamina += staminaRise * Time.deltaTime;
			if (stamina > maxStamina)
				stamina = maxStamina;
		}
		pm.hud.UpdateStamina(stamina);
	}
}