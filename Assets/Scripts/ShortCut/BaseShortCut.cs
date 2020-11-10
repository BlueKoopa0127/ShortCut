using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShortCut : MonoBehaviour
{
    protected enum Version
    {
        Windows, Mac, Linux
    }
    protected static Version currentVersion;

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

    protected void ChangePlatform(RuntimePlatform platform)
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
    }

    private void OSX()
    {
        currentVersion = Version.Mac;
        sckName = KeyCode.LeftCommand.ToString().Substring(4);
        shortCutList = Resources.Load<Data.ShortCutList>("Mac").shortCutList;
    }

    private void Windows()
    {
        currentVersion = Version.Windows;
        sckName = KeyCode.LeftControl.ToString().Substring(4);
        shortCutList = Resources.Load<Data.ShortCutList>("Windows").shortCutList;
    }

    private void Linux()
    {
        currentVersion = Version.Linux;
        sckName = KeyCode.LeftControl.ToString().Substring(4);
        shortCutList = Resources.Load<Data.ShortCutList>("Linux").shortCutList;
    }
}