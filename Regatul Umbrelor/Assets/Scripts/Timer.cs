using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {

        public TMPro.TextMeshProUGUI timerText;
        public float countdownTime = 10f;
        bool timerRunning = true;

        void Update()
        {
            if (timerRunning)
            {
                countdownTime -= Time.deltaTime;

                if (countdownTime <= 0f)
                {
                    countdownTime = 0f;
                    timerRunning = false;
                    timerText.text = "0";
                    Debug.Log("Countdown-ul s-a oprit!");
                }
                else
                {
                    int seconds = Mathf.FloorToInt(countdownTime % 60f);
                    timerText.text = string.Format("{0}", seconds);
                }
            }
        }
    }
}