using UnityEngine;
using TMPro;

public class Age : MonoBehaviour
{
    // Drag the TextMeshProUGUI component here in the Inspector.
    public TextMeshProUGUI ageText;

    void Start()
    {
        // Check that GameManager.Instance is available.
        if (GameManager.Instance != null)
        {
            ageText.text = "Age: " + GameManager.Instance.mainCharacterAge;
        }
        else
        {
            Debug.LogWarning("GameManager instance not found!");
        }
    }

    void Update()
    {
        if (GameManager.Instance != null)
        {
            ageText.text = "Age: " + GameManager.Instance.mainCharacterAge;
        }
    }

}
