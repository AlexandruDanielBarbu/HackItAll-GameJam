using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [Header("Audio Settings")]
    // Reference to your AudioMixer (assign in Inspector)
    public AudioMixer audioMixer;

    // Reference to the slider controlling the master volume (assign in Inspector)
    public Slider masterVolumeSlider;

    private void Start()
    {
        // Optionally, initialize the slider value with a saved preference.
        // For example, get from PlayerPrefs if you have stored a previous volume.
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        masterVolumeSlider.value = savedVolume;
        SetMasterVolume(savedVolume);
    }

    // This method is called when the slider value changes.
    // Attach this to the slider's OnValueChanged event.
    public void SetMasterVolume(float sliderValue)
    {
        // Convert slider value (range 0 to 1) to decibels.
        // If the slider value is 0, set a minimum decibel value (e.g., -80 dB)
        float dB = sliderValue > 0 ? Mathf.Log10(sliderValue) * 20 : -80f;
        audioMixer.SetFloat("MasterVolume", dB);

        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
    }
}
