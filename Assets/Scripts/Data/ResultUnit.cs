using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUnit : MonoBehaviour
{
    private int correct, incorrect;

    private static GameObject obj;

    private void Awake()
    {
        if(obj != null)
        {
            Destroy(obj);
        }

        obj = gameObject;

        DontDestroyOnLoad(gameObject);
    }

    public void SetResult(int co, int inco)
    {
        correct = co;
        incorrect = inco;
    }

    public int GetCorrect()
    {
        return correct;
    }

    public int GetIncorrect()
    {
        return incorrect;
    }
}
