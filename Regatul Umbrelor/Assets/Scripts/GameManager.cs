using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Global variable for the main character's age.
    public int mainCharacterAge = 20; // Set a default age

    private void Awake()
    {
        // Ensure that there's only one instance of GameManager.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes.
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
