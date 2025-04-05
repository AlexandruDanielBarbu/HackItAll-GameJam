using UnityEngine;
using UnityEngine.EventSystems;
public class UIControllerSetup : MonoBehaviour
{
    // Drag your default button from the Hierarchy to this field in the Inspector.
    public GameObject firstSelectedButton;

    void Start()
    {
        if (firstSelectedButton != null)
        {
            EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        }
        else
        {
            Debug.LogError("First Selected Button is not assigned!");
        }
    }
}
