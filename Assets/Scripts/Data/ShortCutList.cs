using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "OS_Name", menuName = "ShortCutList")]
    public class ShortCutList : ScriptableObject
    {
        public List<ShortCutUnit> shortCutList;
    }

    [System.Serializable]
    public struct ShortCutUnit
    {
        public string shortCutName;
        public KeyCode keyCode;
    }
}