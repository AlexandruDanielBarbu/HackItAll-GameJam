using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interact_conference : MonoBehaviour
{
    [Header("Interaction Settings")]
    [Tooltip("List of GameObjects to disable when interacting.")]
    public List<GameObject> objectsToDisable;

    [Tooltip("Main GameObject to enable when interacting.")]
    public GameObject mainObjectToEnable;

    [Tooltip("Background object that will be moved upward on interaction.")]
    public GameObject backgroundObject;

    [Tooltip("The amount to move the background object upward.")]
    public Vector3 backgroundOffset = new Vector3(0, 50, 0);

    [Header("Interaction Text Settings")]
    public GameObject interactText;  // This should have a TextMeshProUGUI component
    private TextMeshProUGUI tmpText;

    [Header("Fade Settings")]
    public float fadeDuration = 0.5f;
    private Coroutine fadeCoroutine;

    private bool isPlayerNear = false;

    void Start()
    {
        if (interactText != null)
        {
            tmpText = interactText.GetComponent<TextMeshProUGUI>();
            if (tmpText != null)
            {
                Color c = tmpText.color;
                c.a = 0f;
                tmpText.color = c;
            }
            interactText.SetActive(false);
        }
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
            {
                interactText.SetActive(true);
                if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
                fadeCoroutine = StartCoroutine(FadeTextToAlpha(1f));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (interactText != null && tmpText != null)
            {
                if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
                fadeCoroutine = StartCoroutine(FadeTextToAlpha(0f, () => interactText.SetActive(false)));
            }
        }
    }

    IEnumerator FadeTextToAlpha(float targetAlpha, System.Action onComplete = null)
    {
        float startAlpha = tmpText.color.a;
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            tmpText.color = new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, alpha);
            yield return null;
        }
        tmpText.color = new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, targetAlpha);
        onComplete?.Invoke();
    }

    void Interact()
    {
        // Disable all specified objects.
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        // Enable the main object.
        if (mainObjectToEnable != null)
        {
            mainObjectToEnable.SetActive(true);
        }

        // Move the background object upward by the specified offset.
        if (backgroundObject != null)
        {
            backgroundObject.transform.position += backgroundOffset;
        }
    }
}
