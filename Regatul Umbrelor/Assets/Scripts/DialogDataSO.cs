using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog/Conversation")]
public class DialogDataSO : ScriptableObject
{
     public List<DialogLine> lines;
}

[System.Serializable]
public class DialogLine
{
    public enum Speaker { Player, NPC }
    public Speaker speaker;
    public string text;
    public List<DialogChoice> choices; // optional
}

[System.Serializable]
public class DialogChoice
{
    public string choiceText;
    public DialogDataSO nextDialog; // reference to another dialog asset
}
