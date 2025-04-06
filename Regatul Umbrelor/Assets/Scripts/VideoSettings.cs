using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions;

    void Start()
    {
        // Get all supported resolutions.
        resolutions = Screen.resolutions;
        if (resolutions == null || resolutions.Length == 0)
        {
            Debug.LogError("No resolutions found!");
            return;
        }

        // Populate the TMP_Dropdown with resolution options.
        resolutionDropdown.ClearOptions();
        var options = new System.Collections.Generic.List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            // Check if this resolution matches the current screen resolution.
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);

        // Load saved settings or use defaults.
        int savedResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", currentResolutionIndex);
        bool savedFullscreen = PlayerPrefs.GetInt("Fullscreen", Screen.fullScreen ? 1 : 0) == 1;

        // Set the dropdown and toggle to the saved values.
        resolutionDropdown.value = savedResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        fullscreenToggle.isOn = savedFullscreen;

        // Apply the saved settings.
        ApplyResolution(savedResolutionIndex);
        ApplyFullscreen(savedFullscreen);
    }

    // Called when the user changes the resolution dropdown selection.
    public void OnResolutionChanged(int resolutionIndex)
    {
        if (resolutions == null || resolutions.Length == 0)
        {
            Debug.LogError("Resolutions not set.");
            return;
        }

        ApplyResolution(resolutionIndex);
        // Save the new resolution index.
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        PlayerPrefs.Save();
    }

    // Called when the user toggles fullscreen.
    public void OnFullscreenToggled(bool isFullscreen)
    {
        ApplyFullscreen(isFullscreen);
        // Save the fullscreen state (1 for true, 0 for false).
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void ApplyResolution(int resolutionIndex)
    {
        if (resolutions == null || resolutionIndex < 0 || resolutionIndex >= resolutions.Length)
        {
            Debug.LogError("Invalid resolution index");
            return;
        }
        Resolution chosenRes = resolutions[resolutionIndex];
        // Use the current fullscreen mode (or you can force a value here if desired).
        Screen.SetResolution(chosenRes.width, chosenRes.height, Screen.fullScreen);
    }

    private void ApplyFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
