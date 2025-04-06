using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxSystem : MonoBehaviour
{
    [SerializeField] private float choiceTimer = 10f;
    private float timer;
    [SerializeField] TMP_Text playerText;
    [SerializeField] TMP_Text npcText;

    
    [SerializeField] DialogDataSO currentDialog;
    private int dialogLineIndex;
    public void StartDialog(DialogDataSO dialog)
    {
        //currentDialog = dialog;
        dialogLineIndex = 0;
        //ShowNextLine();
    }

    //void ShowNextLine()
    //{
    //    var line = currentDialog.lines[dialogLineIndex];

    //    if (line.choices != null && line.choices.Count > 0)
    //    {
    //        ShowChoices(line.choices);
    //    }
    //    else
    //    {
    //        DisplayLine(line);
    //        dialogLineIndex++;
    //    }
    //}

    //private void ExitDialog()
    //{
    //    dialogLineIndex = 0;
    //    DialogInit();
    //    gameObject.SetActive(false);
    //}

    //// function is called from another script that feeds the data to this script
    //public void DialogSystem(Lines[] dialogLinesPO)
    //{
    //    DialogInit();
    //    while (dialogLineIndex < dialogLines.Length)
    //    {
    //        DialogUpdate(dialogLinesPO);
    //    }
    //    ExitDialog();
    //}
    //// Start is called before the first frame update
    //void Start()
    //{
    //    //DialogSystem(dialogLines);
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    bool isTalking = true;
    [SerializeField] TMP_Text option1_choice;
    [SerializeField] TMP_Text option2_choice;

    [SerializeField] Button option1_choice_button;
    [SerializeField] Button option2_choice_button;

    [SerializeField] TMP_Text countdown;
    public void SetDialog(DialogDataSO dialog, int index = 0)
    {
        dialogLineIndex = 0;
        currentDialog = dialog;
    }
    bool startTimer = false;
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
                option1_choice_button.onClick.AddListener(() =>
                {
                    SetDialog(choice01.nextDialog);
                    startTimer = false;

                    Notification.Instance.AddNotifications(choice01.nerf);
                    Notification.Instance.AddNotifications(choice01.buff);
                    StartCoroutine(Notification.Instance.DisplayNotification());

                });

                option2_choice_button.onClick.AddListener(() =>
                {
                    SetDialog(choice02.nextDialog);
                    startTimer = false;
                   
                    Notification.Instance.AddNotifications(choice02.buff);
                    Notification.Instance.AddNotifications(choice02.nerf);
                    StartCoroutine(Notification.Instance.DisplayNotification());

                });
            } else
            {
                dialogLineIndex++;
            }

        }
    }
}
