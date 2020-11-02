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
        ChangePlatform(Application.platform);
    }

    private void ChangePlatform(RuntimePlatform platform)
    {
        switch (platform)
        {
            case RuntimePlatform.OSXEditor:
                OSX();
                break;

            case RuntimePlatform.OSXPlayer:
                OSX();
                break;

            case RuntimePlatform.WindowsPlayer:
                Windows();
                break;

            case RuntimePlatform.LinuxPlayer:
                Linux();
                break;
        }

        sckName = sck.ToString().Substring(4);
    }

    private void OSX()
    {
        sck = KeyCode.LeftCommand;
        shortCutList = Resources.Load<Data.ShortCutList>("Mac").shortCutList;
    }

    private void Windows()
    {
        sck = KeyCode.LeftControl;
        shortCutList = Resources.Load<Data.ShortCutList>("Windows").shortCutList;
    }

    private void Linux()
    {
        sck = KeyCode.LeftControl;
        shortCutList = Resources.Load<Data.ShortCutList>("Linux").shortCutList;
    }
}