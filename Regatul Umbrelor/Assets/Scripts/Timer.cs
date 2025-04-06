using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {
        public TextMeshProUGUI timerText;
        public float countdownTime = 10f;
        bool timerRunning = true;

        // Eveniment invocat când timerul ajunge la 0
        public UnityEvent onTimerFinished;

        void Update()
        {
            if (timerRunning)
            {
                countdownTime -= Time.deltaTime;

                if (countdownTime <= 0f)
                {
                    countdownTime = 0f;
                    timerRunning = false;

                    if (timerText != null)
                        timerText.text = "0";

                    Debug.Log("Timer-ul a ajuns la 0!");
                    if (onTimerFinished != null)
                        onTimerFinished.Invoke();
                }
                else
                {
                    int seconds = Mathf.FloorToInt(countdownTime % 60f);
                    if (timerText != null)
                        timerText.text = seconds.ToString();
                }
            }
        }

        public void ResetTimer(float newTime)
        {
            Debug.Log("ResetTimer apelat cu newTime = " + newTime);
            countdownTime = newTime;
            timerRunning = true;

            // Actualizează imediat textul, dacă vrei
            if (timerText != null)
            {
                int seconds = Mathf.FloorToInt(countdownTime % 60f);
                timerText.text = seconds.ToString();
            }
        }
    }
}
