using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortCutConfirm : BaseShortCut
{
    [SerializeField]
    private Text resultText = null;

    private void Start()
    {
        resultText.text = sckName + "を押さずにショートカットを入力してね\n例：「" + sckName + " + C」　を 「C」と入力";
    }

    private void Update()
    {
        Confirm();
    }

    private void Confirm()
    {
        foreach (var sc in shortCutList)
        {
            if (Input.GetKeyDown(sc.keyCode))
            {
                resultText.text = sc.shortCutName;
                resultText.text += "\n" + sckName + " + " + sc.keyCode;
            }
        }
    }
}