using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public static PauseMenuController Instance;

    [Tooltip("Assign your Pause Menu UI panel here.")]
    public GameObject pauseMenuUI;

    [Tooltip("Assign your Options Panel GameObject here.")]
    public GameObject optionsPanel;

    [Tooltip("Assign the main UI background that should be hidden when showing options.")]
    public GameObject mainCanvasBackground;

    public bool pausingEnabled = true;
    private bool isPaused = false;

    private void Awake()
    {
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

    void Update()
    {
        if (!pausingEnabled)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        if (!pausingEnabled)
            return;

        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);
        if (mainCanvasBackground != null)
            mainCanvasBackground.SetActive(false);

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);
        if (mainCanvasBackground != null)
            mainCanvasBackground.SetActive(true);

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OpenOptionsPanel()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);
        if (mainCanvasBackground != null)
            mainCanvasBackground.SetActive(false);
        if (optionsPanel != null)
            optionsPanel.SetActive(true);
    }

    public void CloseOptionsPanel()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(false);
        if (mainCanvasBackground != null)
            mainCanvasBackground.SetActive(true);
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);
    }
}
