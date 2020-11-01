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

    private int correctCount = 0, incorrectCount = 0;
    private int count = -1;
    private Data.ShortCutUnit CurrentSC { get { return shortCutList[count]; } }

    private void Start()
    {
        shortCutList = shortCutList.OrderBy(a => Guid.NewGuid()).ToList();

        NextQuestion();
    }

    private void Update()
    {
        if (inputReceive)
        {
            if (Input.GetKey(sck))
            {
                inputText.text = sckName + " + ";

                if (!Input.GetKeyDown(sck) && Input.anyKeyDown)
                {
                    inputReceive = false;

                    inputText.text += Input.inputString;

                    if (Input.GetKeyDown(CurrentSC.keyCode))
                    {
                        Invoke("Correct", 1f);
                    }
                    else
                    {
                        Invoke("Incorrect", 1f);
                    }
                }
            }
        }
    }

    private void NextQuestion()
    {
        count++;

        if (shortCutList.Count <= count)
        {
            GameObject.Find("ResultObject").GetComponent<ResultUnit>().SetResult(correctCount, incorrectCount);

            UnityEngine.SceneManagement.SceneManager.LoadScene("ResultScene");
        }
        else
        {
            inputText.text = "正しいショートカットを入力してね";

            inputReceive = true;

            questionText.text = CurrentSC.shortCutName;
        }
    }

    private void Correct()
    {
        CorrectIncorrect(true);
        correctCount++;
    }

    private void Incorrect()
    {
        CorrectIncorrect(false);
        incorrectCount++;
    }

    private void CorrectIncorrect(bool co)
    {
        inputText.text = co ? "正解" : "不正解";

        Invoke("NextQuestion", 1f);
    }
}
