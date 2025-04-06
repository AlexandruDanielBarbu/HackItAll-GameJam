using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string speaker;  // For example, "Me" or "Counselor"
    [TextArea(3, 10)]
    public string dialogueText;  // The dialogue line text

    // You can add extra fields like portrait image, sound clip, etc.
}
