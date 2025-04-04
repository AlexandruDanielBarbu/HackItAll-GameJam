using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIControllerSetup : MonoBehaviour
{
    [SerializeField] private Button firstButton;

    void Start()
    {
        // Check if a button is assigned and select it
        if (firstButton != null)
        {
            EventSystem.current.SetSelectedGameObject(firstButton.gameObject);
        }
    }
}
