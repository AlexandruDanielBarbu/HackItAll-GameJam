using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DecisionPanelController : MonoBehaviour
{
    // Referințe la componentele UI din panel
    public Button button1;
    public Button button2;
    public TextMeshProUGUI button1Text;
    public TextMeshProUGUI button2Text;
    public TextMeshProUGUI timerText;
    public AudioSource audioSource;

    // Referință la componenta Timer existentă
    public Assets.Scripts.Timer timerComponent;

    // Referință opțională la managerul de decizii
    public DecisionManager decisionManager;

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

            // Trecem la următoarea decizie
            if (decisionManager != null)
                decisionManager.NextDecision();
        });

        button2.onClick.AddListener(() =>
        {
            Debug.Log("Ai apăsat al doilea buton");
            if (audioSource != null && decisionData.clickSoundButton2 != null)
                audioSource.PlayOneShot(decisionData.clickSoundButton2);
        });

        // Configurează și resetează Timer-ul existent
        if (timerComponent != null)
        {
            // Setează referința la Text-ul timerului
            timerComponent.timerText = timerText;

            // Resetează timerul la durata specificată în decizie
            timerComponent.ResetTimer(decisionData.timerDuration);

            // Elimină evenimentele anterioare și abonează o metodă nouă pentru evenimentul când timer-ul se termină
            timerComponent.onTimerFinished.RemoveAllListeners();
            timerComponent.onTimerFinished.AddListener(() =>
            {
                Debug.Log("Timer-ul a finalizat, trecem la următoarea decizie");
                if (decisionManager != null)
                    decisionManager.NextDecision();
            });
        }
    }
}
