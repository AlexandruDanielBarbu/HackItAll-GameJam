using System.Collections;
using UnityEngine;

public class FadeIn_OnInteraction : MonoBehaviour
{
    [SerializeField] private GameObject objectToFade;
    private float fadeDuration = 0.5f;
    private SpriteRenderer objectRenderer;
    private Color originalColor;

    private bool isPlayerNear = false;
    private bool hasFadedIn = false;

    private void Start()
    {
        objectRenderer = objectToFade.GetComponent<SpriteRenderer>();
        originalColor = objectRenderer.color;

        Color transparentColor = originalColor;
        transparentColor.a = 0f;
        objectRenderer.color = transparentColor;
    }

    private void Update()
    {
        if (isPlayerNear && !hasFadedIn && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(FadeToOpaque());
            hasFadedIn = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private IEnumerator FadeToOpaque()
    {
        float elapsedTime = 0f;
        Color startColor = objectRenderer.color;
        Color targetColor = originalColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime / fadeDuration);
            objectRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        objectRenderer.color = targetColor;
    }
}
