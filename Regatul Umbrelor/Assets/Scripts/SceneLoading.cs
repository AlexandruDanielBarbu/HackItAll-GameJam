using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public static SceneLoading Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // kill the duplicate
            return;
        }

        Instance = this;
    }
    public void TransitionToScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
