using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathGame : Activity 
{
	public int maxProblems = 3;
	public float endTime = 5;

	public Text questionText, answerText;

	int currentProblem = 0;
	int problemsWrong;

	int solution;
	bool impossible;

	bool ending;

	public override void Initialize(Notebook notebook)
	{
		base.Initialize(notebook);
		Time.timeScale = 0;
		PlayerManager.Instance.ctrl.plc.SetRendering(false);

		NewProblem();
	}

	void Update()
	{
		if (ending)
		{
			endTime -= Time.unscaledDeltaTime;
			if (endTime <= 0)
				End();
		}
	}

	void NewProblem(bool impossible = false)
	{
		answerText.text = string.Empty;

		if (++currentProblem > maxProblems)
		{
            ending = true;
            questionText.text = "WOW! YOU EXIST!";
			return;
        }

        this.impossible = impossible;
        if (impossible)
        {
            questionText.text = "haha!";
			return;
        }

        int num1 = Random.Range(0, 10);
        int num2 = Random.Range(0, 10);
        int op = Random.Range(0, 2);

        solution = op == 0 ? num1 + num2 : num1 - num2;

        var sign = op == 0 ? "+" : "-";
        questionText.text = string.Concat(new object[]
        {
			"SOLVE MATH Q",
			currentProblem,
			":\n\n",
			num1, sign, num2, "="
        });
    }

	public void ButtonPressed(int val)
	{
		if (val >= 0 && val <= 9)
		{
            answerText.text += val.ToString();
			return;
		}
		if (val == -1)
		{
			answerText.text += "-";
			return;
		}
		answerText.text = string.Empty;
	}

	public void SubmitAnswer()
	{
		if (currentProblem > maxProblems)
			return;

		if (!impossible && answerText.text == solution.ToString())
		{
			Debug.Log("good");
		}
		else
		{
			problemsWrong++;
		}
        NewProblem(currentProblem == maxProblems - 1);
    }

    public void End()
    {
        Time.timeScale = 1;
        PlayerManager.Instance.ctrl.plc.SetRendering(true);
        Destroy(gameObject);
    }
}
