using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Drag your panels from the Hierarchy into this array in the Inspector.
    public GameObject[] panels;
    public GameObject mainMenuPanel;


    // This method will activate the panel at the given index and disable all others.
    public void ShowPanel(int index)
    {
        // Loop through all panels and set active state
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == index);
        }
        mainMenuPanel.SetActive(false);
    }

    public void QuitGame()
    {
        // If we are running in the editor, stop playing the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void BackToMainMenu()
    {
        // Deactivate all panels and show the main menu
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        mainMenuPanel.SetActive(true);
    }
}
