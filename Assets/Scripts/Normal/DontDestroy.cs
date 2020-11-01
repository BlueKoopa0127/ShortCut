using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject obj;

    private void Awake()
    {
        if(obj == null)
        {
            DontDestroyOnLoad(gameObject);
            obj = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
