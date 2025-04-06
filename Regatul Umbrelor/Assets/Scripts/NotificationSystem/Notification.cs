using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public static Notification Instance { get; private set; }
    public Queue<string> NotificationQueue = new Queue<string>();

    [SerializeField] private TMP_Text notificationText;

    public void Hide()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void Show()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void AddNotifications(string text)
    {
        Debug.Log(text);    
        NotificationQueue.Enqueue(text);
        Debug.Log(text);
    }
    public IEnumerator DisplayNotification()
    {
        Show();

        while (NotificationQueue.Count >= 0)
        {
            notificationText.text = NotificationQueue.Dequeue();
            yield return new WaitForSeconds(2f);
        }

        Hide();
    }
    private void Awake()
    {
        Hide();
        // Basic singleton check
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Avoid duplicates
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Optional: Persist across scenes
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
