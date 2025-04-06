//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;
//using System.Collections;
//using System.Collections.Generic;

//public class DialogueManager : MonoBehaviour
//{
//    [Header("Dialogue Data")]
//    [Tooltip("Insert your dialogue lines here (in order).")]
//    public List<DialogueLine> dialogueLines = new List<DialogueLine>();

//    private int currentLineIndex = 0;

//    [Header("UI References")]
//    [Tooltip("Text field on the left for your dialogue.")]
//    public TextMeshProUGUI leftDialogueText;

//    [Tooltip("Text field on the right for the counselor dialogue.")]
//    public TextMeshProUGUI rightDialogueText;

//    [Tooltip("Button to advance dialogue.")]
//    public Button nextButton;

//    [Header("Typewriter Effect")]
//    [Tooltip("Reference to the TypewriterEffect component.")]
//    public TypewriterEffect typewriterEffect;

//    [Header("Auto Advance Settings")]
//    [Tooltip("Time (in seconds) to wait after finishing a dialogue line before automatically advancing.")]
//    public float autoAdvanceDelay = 2.0f;

//    // Reference to the auto-advance coroutine, so it can be cancelled if needed.
//    private Coroutine autoAdvanceCoroutine;

//    private void Start()
//    {
//        if (dialogueLines.Count > 0)
//        {
//            currentLineIndex = 0;
//            ShowCurrentLine();
//        }

//        nextButton.onClick.AddListener(AdvanceDialogue);
//    }

//    void ShowCurrentLine()
//    {
//        // Clear both text fields
//        leftDialogueText.text = "";
//        rightDialogueText.text = "";

//        DialogueLine currentLine = dialogueLines[currentLineIndex];

//        // Start typewriter effect on the appropriate text field based on speaker.
//        if (currentLine.speaker.ToLower().Contains("me"))
//        {
//            StartCoroutine(typewriterEffect.ShowText(currentLine.dialogueText, leftDialogueText));
//        }
//        else // Assume counselor or any other speaker is on the right.
//        {
//            StartCoroutine(typewriterEffect.ShowText(currentLine.dialogueText, rightDialogueText));
//        }

//        // Start the auto-advance coroutine after the text finishes typing.
//        if (autoAdvanceCoroutine != null)
//            StopCoroutine(autoAdvanceCoroutine);
//        autoAdvanceCoroutine = StartCoroutine(AutoAdvanceAfterDelay());
//    }

//    IEnumerator AutoAdvanceAfterDelay()
//    {
//        // Wait until the typewriter effect is complete.
//        // (This assumes that IsComplete() returns true when typing is finished.)
//        while (!typewriterEffect.IsComplete())
//        {
//            yield return null;
//        }
//        // Wait for the specified auto-advance delay.
//        yield return new WaitForSeconds(autoAdvanceDelay);
//        // Advance dialogue automatically.
//        AdvanceDialogue();
//    }

//    public void AdvanceDialogue()
//    {
//        // If the typewriter effect is still in progress, skip to complete the text.
//        if (!typewriterEffect.IsComplete())
//        {
//            typewriterEffect.Skip();
//            // Also cancel the auto-advance coroutine so we don't advance twice.
//            if (autoAdvanceCoroutine != null)
//            {
//                StopCoroutine(autoAdvanceCoroutine);
//                autoAdvanceCoroutine = null;
//            }
//        }
//        else
//        {
//            // Cancel any pending auto-advance coroutine.
//            if (autoAdvanceCoroutine != null)
//            {
//                StopCoroutine(autoAdvanceCoroutine);
//                autoAdvanceCoroutine = null;
//            }

//            currentLineIndex++;
//            if (currentLineIndex < dialogueLines.Count)
//            {
//                ShowCurrentLine();
//            }
//            else
//            {
//                Debug.Log("Dialogue complete.");
//                nextButton.interactable = false;
//            }
//        }
//    }
//}
