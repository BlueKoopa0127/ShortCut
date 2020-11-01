using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortCutLineUp : BaseShortCut
{
    [SerializeField]
    private RectTransform content = null;

    [SerializeField]
    private GameObject shortCutItem = null;

    private float sizeY;
    private Vector2 pos = new Vector2();

    private void Start()
    {
        sizeY = shortCutItem.GetComponent<RectTransform>().sizeDelta.y;

        foreach (var sc in shortCutList)
        {
            AddSCItem(sc);
        }
    }

    private void AddSCItem(Data.ShortCutUnit item)
    {
        var cSize = content.sizeDelta;
        cSize.y += sizeY;
        content.sizeDelta = cSize;


        GameObject obj = Instantiate(shortCutItem, content.transform);
        
        var rect = obj.GetComponent<RectTransform>();
        rect.localPosition = pos;
        pos.x = 0;
        pos.y -= sizeY;
        
        var size = rect.sizeDelta;
        size.x = 0;

        Text t = obj.GetComponentInChildren<Text>();
        t.text = item.shortCutName + " : " + sckName + " + " + item.keyCode;
    }
}
