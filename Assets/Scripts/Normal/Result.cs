using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]
    private Text correctText = null, incorrectText = null;

    private void Start()
    {
        ResultUnit r = GameObject.Find("ResultObject").GetComponent<ResultUnit>();

        correctText.text += r.GetCorrect();
        incorrectText.text += r.GetIncorrect();
    }
}
