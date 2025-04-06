using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DialogueWithBoy : MonoBehaviour
{
    [SerializeField] private GameObject dialogueGood;
    [SerializeField] private GameObject dialogueBad;
    private int currentLineIndex = 0;
    private GameObject currentDecision;
    private bool showGood;

    void Start()
    {
        showGood = Decisions.savedSchool;
        currentDecision = showGood ? dialogueGood : dialogueBad;

        dialogueGood.SetActive(showGood);
        dialogueBad.SetActive(!showGood);

        SetLineVisibility(currentDecision, 0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentLineIndex == 0)
            {
                // Show line 2
                SetLineVisibility(currentDecision, 0);
                currentLineIndex = 1;
            }
            else if (currentLineIndex == 1)
            {
                SetLineVisibility(currentDecision, 1);
                currentLineIndex = 2;
            }
            else
            {
                SceneManager.LoadScene("Hallway01");
            }
        }
    }

    private void SetLineVisibility(GameObject decisionObj, int lineToShow)
    {
        for (int i = 0; i < decisionObj.transform.childCount; i++)
        {
            Transform line = decisionObj.transform.GetChild(i);
            line.gameObject.SetActive(i == lineToShow);
        }
    }
}
