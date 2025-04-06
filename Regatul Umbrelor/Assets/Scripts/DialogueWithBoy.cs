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
            currentLineIndex++;
            if (currentLineIndex < 2)
            {
                SetLineVisibility(currentDecision, currentLineIndex);
            }
            else
            {
                StartCoroutine(LoadSceneAfterDelay("Hallway01", 1f));
            }
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
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
