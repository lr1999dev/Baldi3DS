using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jumprope : Singleton<Jumprope>
{
	public bool InProgress { get; private set; }

	[SerializeField] MovementEffect moveEffect;
	[SerializeField] Canvas canvas;

	public Animator animator;
	public Text instText, scoreText;

    public int maxJumps = 5;
    public float swingSpeed = 1.5f;

	public float successTime = 1;
    public float failTime = 2;

    [SerializeField] float initVelocity = 1, 
		gravity = 2;

    public Playtime playtime;

    float velocity, height;
	Vector3 frozenPlayerPos, camOffset;

	int score;

    void Start()
    {
        instText.text = string.Format(instText.text, InputManager.Instance.GetBindingName(InputAction.Interact));
    }

    void Update()
    {
		if (!InProgress)
			return;

		if (Vector3.Distance(playtime.Player.ctrl.transform.position, frozenPlayerPos) >= 0.2f)
		{
			End(false);
			return;
		}

		if (InputManager.Instance.GetButton(InputAction.Interact) && height <= 0)
            velocity = initVelocity;

        velocity -= gravity * Time.deltaTime;
        height = Mathf.Max(height + velocity * Time.deltaTime, 0);

        camOffset.y = height;
        playtime.Player.ctrl.plc.SetPositionOffset(camOffset);
    }

    public void Restart(Playtime playtime)
    {
        if (InProgress)
            End(false);

        this.playtime = playtime;

        height = velocity = 0;
        score = 0;
        UpdateScore();

        frozenPlayerPos = playtime.Player.ctrl.transform.position;
        playtime.Player.ctrl.allEffects.Add(moveEffect);

        canvas.gameObject.SetActive(true);
        Invoke("Swing", 1);
        InProgress = true;
    }

    public void End(bool success)
    {
        playtime.EndJumprope(success);

        CancelInvoke("Swing");
        playtime.Player.ctrl.allEffects.Remove(moveEffect);
        playtime.Player.ctrl.plc.SetPositionOffset(Vector3.zero);

        canvas.gameObject.SetActive(false);
        InProgress = false;
    }

    void Swing()
	{
		animator.speed = swingSpeed;
        animator.Play("Swing", -1, 0);
    }

    public void SwingEnded()
	{
        if (height >= 0.2f)
			Success();
		else
			Fail();
		UpdateScore();
    }

	void Success()
	{
        playtime.Count(score++);
		if (score >= maxJumps)
		{
            Invoke("EndWait", 0.5f);
			return;
		}
		Invoke("Swing", successTime);
	}

	void Fail()
	{
		score = 0;
		playtime.Oops();
		Invoke("Swing", failTime);
	}

	void UpdateScore()
	{
		scoreText.text = string.Format("{0}/{1}", score, maxJumps);
	}

    void EndWait()
    {
        End(true);
    }
}