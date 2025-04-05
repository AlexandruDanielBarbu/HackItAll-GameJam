using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GlobalUIManager : MonoBehaviour
{
    public static GlobalUIManager Instance;

    [Header("Global Options Canvas")]
    [Tooltip("Drag the 'Options_canvas' GameObject here.")]
    public GameObject optionsCanvas;

    private void Awake()
    {
        // Singleton pattern: persist across scene loads
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this method from any menu button to open the global options.
    public void OpenOptions()
    {
        if (optionsCanvas != null)
        {
            optionsCanvas.SetActive(true);
            // Optional: clear the current selection for controller nav
            // EventSystem.current.SetSelectedGameObject(null);
            // If you have a default button in the Options_panel:
            // EventSystem.current.SetSelectedGameObject(defaultButton);
        }
    }

    // Call this method to close the options overlay.
    public void CloseOptions()
    {
        if (optionsCanvas != null)
        {
            optionsCanvas.SetActive(false);
        }
        SceneManager.UnloadSceneAsync("Options_Global");
    }   
}
