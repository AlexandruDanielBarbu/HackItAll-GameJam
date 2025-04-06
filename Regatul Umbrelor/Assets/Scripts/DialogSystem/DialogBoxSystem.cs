using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogBoxSystem : MonoBehaviour
{
    [Header("Speakers' text")]
    [SerializeField] TMP_Text playerText;
    [SerializeField] TMP_Text npcText;

    [Header("Dialogue Data")]
    [SerializeField] DialogDataSO currentDialog;

    [Header("Choice Timer")]
    [SerializeField] private float choiceTimer = 10f;
                     private float timer;
    
    [SerializeField] TMP_Text countdown;
    [SerializeField] GameObject fadeTrigger;

    [Header("Choice Object")]
    [SerializeField] GameObject choicesPanel;
    [SerializeField] TMP_Text option1_choice;
    [SerializeField] Button option1_choice_button;
    [SerializeField] TMP_Text option2_choice;
    [SerializeField] Button option2_choice_button;


    bool startTimer = false;
    bool isTalking = true;
    private int dialogLineIndex;

    public void SetDialog(DialogDataSO dialog, int index = 0)
    {
        dialogLineIndex = 0;
        currentDialog = dialog;
        choicesPanel.SetActive(false);
    }
    private void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = choiceTimer;
                Debug.Log(timer);
            }
            Debug.Log(timer);
            countdown.text = ((int)timer).ToString();
        }

        if (isTalking && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (dialogLineIndex < currentDialog.lines.Count)
            {
                DialogLine currentLine = currentDialog.lines[dialogLineIndex];

                if (currentLine.speaker == DialogLine.Speaker.Player)
                {
                    playerText.text = currentLine.text;
                    npcText.text = string.Empty;
                }
                else
                {
                    npcText.text = currentLine.text;
                    playerText.text = string.Empty;
                }

                    if (currentLine.choices.Count > 0 &&
                        currentLine.speaker == DialogLine.Speaker.NPC)
                    {
                        DialogChoice choice01 = currentLine.choices[0];
                        DialogChoice choice02 = currentLine.choices[1];

                        option1_choice.text = choice01.choiceText;
                        option2_choice.text = choice02.choiceText;

                        startTimer = true;

                        choicesPanel.SetActive(true);
                        option1_choice_button.onClick.AddListener(() =>
                        {
                            Decisions.savedSchool = true;

                            SetDialog(choice01.nextDialog);
                            startTimer = false;

                            Notification.Instance.AddNotifications(choice01.nerf);
                            Notification.Instance.AddNotifications(choice01.buff);
                            StartCoroutine(Notification.Instance.DisplayNotification());

                        });

                        option2_choice_button.onClick.AddListener(() =>
                        {
                            Decisions.savedSchool = false;
                            SetDialog(choice02.nextDialog);
                            startTimer = false;

                            Notification.Instance.AddNotifications(choice02.buff);
                            Notification.Instance.AddNotifications(choice02.nerf);
                            StartCoroutine(Notification.Instance.DisplayNotification());

                        });
                    }
                    else
                    {
                        dialogLineIndex++;
                    }
            }
            else
            {
                fadeTrigger.SetActive(true);
                StartCoroutine(LoadSceneAfterDelay("BeforeBattle01", 1f));
            }
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
