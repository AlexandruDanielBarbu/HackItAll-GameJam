using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    [Tooltip("Time delay between each character (in seconds).")]
    public float characterDelay = 0.05f;

    private bool skip;  // Flag to check if the user wants to skip
    private bool isTyping;  // Is typing in progress

    // Coroutine to show text on a given target TMP_Text
    public IEnumerator ShowText(string textToDisplay, TextMeshProUGUI targetText)
    {
        isTyping = true;
        skip = false;
        targetText.text = "";

        foreach (char c in textToDisplay)
        {
            if (skip)
            {
                targetText.text = textToDisplay;
                break;
            }
            targetText.text += c;
            yield return new WaitForSeconds(characterDelay);
        }
        isTyping = false;
    }

    public void Skip()
    {
        skip = true;
    }

    public bool IsComplete()
    {
        return !isTyping;
    }
}
