using UnityEngine;
using UnityEngine.UI;

public class DecisionCouncil : MonoBehaviour
{
    public Button button1;
    public Button button2;

    public AudioSource audioSource;

    // Adaugă două AudioClip-uri pentru cele două butoane
    public AudioClip clickSoundButton1;
    public AudioClip clickSoundButton2;

    void Start()
    {
        if (button1 != null)
            button1.onClick.AddListener(OnButton1Clicked);
        else
            Debug.LogError("Button1 nu este setat!");

        if (button2 != null)
            button2.onClick.AddListener(OnButton2Clicked);
        else
            Debug.LogError("Button2 nu este setat!");
    }

    void OnButton1Clicked()
    {
        Debug.Log("Ai apăsat primul buton");
        if (audioSource != null && clickSoundButton1 != null)
            audioSource.PlayOneShot(clickSoundButton1);
    }

    void OnButton2Clicked()
    {
        Debug.Log("Ai apăsat al doilea buton");
        if (audioSource != null && clickSoundButton2 != null)
            audioSource.PlayOneShot(clickSoundButton2);
    }
}
