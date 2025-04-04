using UnityEngine;

public class DecisionManager : MonoBehaviour
{
    public DecisionPanelController panelController;
    public DecisionData[] decisions;
    private int currentDecisionIndex = 0;

    void Start()
    {
        if (decisions != null && decisions.Length > 0)
        {
            panelController.SetupDecision(decisions[currentDecisionIndex]);
        }
        else
        {
            Debug.LogError("Nu sunt decizii setate!");
        }
    }

    public void NextDecision()
    {
        currentDecisionIndex++;
        if (currentDecisionIndex < decisions.Length)
        {
            panelController.SetupDecision(decisions[currentDecisionIndex]);
        }
        else
        {
            Debug.Log("Nu mai sunt decizii de afișat!");
        }
    }
}
