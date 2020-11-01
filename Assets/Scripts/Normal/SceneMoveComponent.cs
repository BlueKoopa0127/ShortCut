using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMoveComponent : MonoBehaviour
{
    [SerializeField]
    private string moveSceneName = null;

    public void Move()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(moveSceneName);
    }
}
