using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortCutVersionChange : BaseShortCut
{
    [SerializeField]
    private Text versionText = null;

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        versionText.text = "現在は" + currentVersion + "版です";
    }

    public void ChangeWindows()
    {
        ChangePlatform(RuntimePlatform.WindowsPlayer);
        UpdateText();
    }

    public void ChangeOSX()
    {
        ChangePlatform(RuntimePlatform.OSXPlayer);
        UpdateText();
    }

    public void ChangeLinux()
    {
        ChangePlatform(RuntimePlatform.LinuxPlayer);
        UpdateText();
    }
}
