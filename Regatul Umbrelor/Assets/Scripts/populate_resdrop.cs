using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ResolutionPopulator : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    void Start()
    {
        // Get all supported resolutions
        resolutions = Screen.resolutions;

        // Prepare a list to hold resolution options as strings
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        // Loop through all resolutions and format them as strings
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRateRatio + "Hz";
            options.Add(option);

            // Check if this resolution is the current one
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Clear any existing options and add the new ones
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(options);

        // Set the dropdown value to the current resolution index and refresh the shown value
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
}
