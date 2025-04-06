using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [Header("Audio Mixer")]
    public AudioMixer audioMixer;  // Drag your AudioMixer here

    [Header("Volume Sliders")]
    public Slider masterVolumeSlider;
    public Slider voiceVolumeSlider;
    public Slider soundEffectsSlider;

    private void Start()
    {
        // Load saved volumes or use defaults (0.75f = 75% volume).
        float savedMasterVol = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        float savedVoiceVol = PlayerPrefs.GetFloat("VoiceVolume", 0.75f);
        float savedSFXVol = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

        // Set slider values
        masterVolumeSlider.value = savedMasterVol;
        voiceVolumeSlider.value = savedVoiceVol;
        soundEffectsSlider.value = savedSFXVol;

        // Apply volumes to the AudioMixer
        SetMasterVolume(savedMasterVol);
        SetVoiceVolume(savedVoiceVol);
        SetSFXVolume(savedSFXVol);
    }

    // Called by the Master Volume slider's OnValueChanged event
    public void SetMasterVolume(float value)
    {
        // Convert [0,1] slider value to decibels
        float dB = (value > 0) ? Mathf.Log10(value) * 20f : -80f;
        audioMixer.SetFloat("MasterVolume", dB);
        // Save
        PlayerPrefs.SetFloat("MasterVolume", value);
        PlayerPrefs.Save();
    }

    // Called by the Voice Volume slider's OnValueChanged event
    public void SetVoiceVolume(float value)
    {
        float dB = (value > 0) ? Mathf.Log10(value) * 20f : -80f;
        audioMixer.SetFloat("VoiceVolume", dB);
        PlayerPrefs.SetFloat("VoiceVolume", value);
        PlayerPrefs.Save();
    }

    // Called by the SFX Volume slider's OnValueChanged event
    public void SetSFXVolume(float value)
    {
        float dB = (value > 0) ? Mathf.Log10(value) * 20f : -80f;
        audioMixer.SetFloat("SFXVolume", dB);
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
}
