using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBoxSystem : MonoBehaviour
{
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
    private void Update()
    {
        if (isTalking && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (currentDialog.lines[dialogLineIndex].speaker == DialogLine.Speaker.Player)
            {
                playerText.text = currentDialog.lines[dialogLineIndex].text;
                npcText.text = string.Empty;
                dialogLineIndex++;
            }
            else
            {
                npcText.text = currentDialog.lines[dialogLineIndex].text;
                playerText.text = string.Empty;
                dialogLineIndex++;
            }


        }
    }
}
