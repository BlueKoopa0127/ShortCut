using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShortCut : MonoBehaviour
{
    protected static KeyCode sck;
    protected static string sckName;
    protected static List<Data.ShortCutUnit> shortCutList;

    private void Awake()
    {
        if (shortCutList == null)
        {
            Initialize();
        }
    }

    private void Initialize()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.OSXEditor:
                sck = KeyCode.LeftCommand;
                shortCutList = Resources.Load<Data.ShortCutList>("Mac").shortCutList;
                break;

            case RuntimePlatform.OSXPlayer:
                sck = KeyCode.LeftCommand;
                shortCutList = Resources.Load<Data.ShortCutList>("Mac").shortCutList;
                break;

            case RuntimePlatform.WindowsPlayer:
                sck = KeyCode.LeftControl;
                shortCutList = Resources.Load<Data.ShortCutList>("Windows").shortCutList;
                break;

            case RuntimePlatform.LinuxPlayer:
                sck = KeyCode.LeftControl;
                shortCutList = Resources.Load<Data.ShortCutList>("Linux").shortCutList;
                break;
        }

        sckName = sck.ToString().Substring(4);
    }
}