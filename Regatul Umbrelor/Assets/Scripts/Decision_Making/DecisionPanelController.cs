using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DecisionPanelController : MonoBehaviour
{
    // Referințe la componentele UI din panel
    public Button button1;
    public Button button2;
    public TextMeshProUGUI button1Text; // Dacă folosești TextMeshPro, folosește TextMeshProUGUI
    public TextMeshProUGUI button2Text;
    public TextMeshProUGUI timerText;    // Pentru a afișa timerul, dacă ai
    public AudioSource audioSource;

    // Variabile pentru timer
    private float timer;
    private bool timerRunning = false;

    // Metodă de configurare ce primește datele unei decizii
    public void SetupDecision(DecisionData decisionData)
    {
        // Setează textele butoanelor
        button1Text.text = decisionData.button1Text;
        button2Text.text = decisionData.button2Text;

        // Resetăm și configurăm evenimentele butoanelor
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();

        button1.onClick.AddListener(() =>
        {
            Debug.Log("Ai apăsat primul buton");
            if (audioSource != null && decisionData.clickSoundButton1 != null)
                audioSource.PlayOneShot(decisionData.clickSoundButton1);
        });

        button2.onClick.AddListener(() =>
        {
            Debug.Log("Ai apăsat al doilea buton");
            if (audioSource != null && decisionData.clickSoundButton2 != null)
                audioSource.PlayOneShot(decisionData.clickSoundButton2);
        });

        // Configurează timerul
        timer = decisionData.timerDuration;
        timerRunning = true;
        UpdateTimerUI();
    }

    void Update()
    {
        if (timerRunning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                timerRunning = false;
                Debug.Log("Timer-ul s-a oprit!");
                // Aici poți declanșa o acțiune când timer-ul s-a terminat.
            }
            UpdateTimerUI();
        }
    }

    // Metodă pentru actualizarea textului timerului
    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
