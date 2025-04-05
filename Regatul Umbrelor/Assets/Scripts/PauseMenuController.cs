using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static PauseMenuController Instance;

    [Tooltip("Assign your Pause Menu UI panel here.")]
    public GameObject pauseMenuUI;
    public GameObject mainMenuPanel;
    public GameObject defaultMainButton;
    public GameObject defaultPauseButton;
    public GameObject defaultOptionsButton;

    public GameObject optionsCanvas;

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
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (!pausingEnabled)
            return;

        pauseMenuUI.SetActive(true);

        pauseMenuUI.SetActive(true);
        if (EventSystem.current != null && defaultPauseButton != null)
        {
            EventSystem.current.SetSelectedGameObject(defaultPauseButton);
        }

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);

        if (EventSystem.current != null && defaultMainButton != null)
        {
            EventSystem.current.SetSelectedGameObject(defaultMainButton);
        }

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OpenOptionsPanel(bool comingFromPause)
    {
        if (!comingFromPause)
            mainMenuPanel.SetActive(false);
        optionsCanvas.SetActive(true);
        if (EventSystem.current != null && defaultOptionsButton != null)
        {
            EventSystem.current.SetSelectedGameObject(defaultOptionsButton);
        }
    }

    public void CloseOptionsPanel()
    {
        if (optionsCanvas != null)
        {
            optionsCanvas.SetActive(false);
        }

        if (isPaused)
        {
            pauseMenuUI.SetActive(true);
            if (EventSystem.current != null && defaultPauseButton != null)
            {
                EventSystem.current.SetSelectedGameObject(defaultPauseButton);
            }
        }
        else
        {
            mainMenuPanel.SetActive(true);
            // Set the default selected button (replace "defaultButton" with your actual button reference)
            if (EventSystem.current != null && defaultMainButton != null)
            {
                EventSystem.current.SetSelectedGameObject(defaultMainButton);
            }
        }
    }
}
