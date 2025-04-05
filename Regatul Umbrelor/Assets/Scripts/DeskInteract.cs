using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public GameObject interactText;
    private bool isPlayerNear = false;

    void Start()
    {
        if (interactText != null)
            interactText.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (interactText != null)
                interactText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (interactText != null)
                interactText.SetActive(false);
        }
    }

    void Interact()
    {
        Debug.Log("Ai interacționat cu obiectul!");
        // Load the scene directly
        SceneManager.LoadScene("CutSceneBegin");
    }
}
