using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class ShortCutTest : BaseShortCut
{
    [SerializeField]
    private Text questionText = null, inputText = null;

    private bool inputReceive = true;

    private List<Data.ShortCutUnit> randomShortCutList;

    private int correctCount = 0, incorrectCount = 0;
    private int count = -1;
    private Data.ShortCutUnit CurrentSC { get { return randomShortCutList[count]; } }

    private void Start()
    {
        randomShortCutList = new List<Data.ShortCutUnit>(shortCutList);

        randomShortCutList = randomShortCutList.OrderBy(a => Guid.NewGuid()).ToList();

        NextQuestion();
    }

    private void Update()
    {
        if (inputReceive)
        {
            if (Input.anyKeyDown)
            {
                inputReceive = false;

                inputText.text = sckName + " + " + GetKeyCode();

                if (Input.GetKeyDown(CurrentSC.keyCode))
                {
                    Invoke("Correct", 0.5f);
                }
                else
                {
                    Invoke("Incorrect", 0.5f);
                }
            }
        }
    }

    private void NextQuestion()
    {
        count++;

        if (randomShortCutList.Count <= count)
        {
            TestFinish();
        }
        else
        {
            inputText.text = sckName + "を押さずにショートカットを入力してね";

            inputReceive = true;

            questionText.text = CurrentSC.shortCutName;
        }
    }

    private string GetKeyCode()
    {
        foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(code))
            {
                return code.ToString();
            }
        }

        return string.Empty;
    }

    private void Correct()
    {
        AddResult(true);
        correctCount++;
    }

    private void Incorrect()
    {
        AddResult(false);
        incorrectCount++;
    }

    private void AddResult(bool co)
    {
        inputText.text = co ? "正解" : "不正解";
        inputText.text += "\n" + sckName + " + " + CurrentSC.keyCode;

        Invoke("NextQuestion", 1f);
    }

    private void TestFinish()
    {
        GameObject.Find("ResultObject").GetComponent<ResultUnit>().SetResult(correctCount, incorrectCount);

        UnityEngine.SceneManagement.SceneManager.LoadScene("ResultScene");
    }
}
