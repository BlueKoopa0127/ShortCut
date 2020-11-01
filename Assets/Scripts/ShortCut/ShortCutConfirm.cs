using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortCutConfirm : BaseShortCut
{
    [SerializeField]
    private Text resultText = null;

    private void Update()
    {
        if (Input.GetKey(sck))
        {
            foreach (var sc in shortCutList)
            {
                if (Input.GetKeyDown(sc.keyCode))
                {
                    resultText.text = sc.shortCutName;
                    resultText.text += "\n\n" + sckName + " + " + sc.keyCode;
                }
            }
        }
    }
}