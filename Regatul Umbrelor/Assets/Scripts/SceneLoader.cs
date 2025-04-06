using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Call this method from your button's OnClick event.

    public string sceneToLoad;
    public void LoadSceneByName()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
