using UnityEngine;

public class OptionsPanelManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject videoPanel;
    public GameObject audioPanel;
    public GameObject controlsPanel;

    // Called when the "Video" button is clicked
    public void ShowVideoPanel()
    {
        videoPanel.SetActive(true);
        audioPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    // Called when the "Audio" button is clicked
    public void ShowAudioPanel()
    {
        videoPanel.SetActive(false);
        audioPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }

    // Called when the "Controls" button is clicked
    public void ShowControlsPanel()
    {
        videoPanel.SetActive(false);
        audioPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }
}
