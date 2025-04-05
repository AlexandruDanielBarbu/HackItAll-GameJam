using System.Collections;
using UnityEngine;

public class FadeOtherObject : MonoBehaviour
{
    // This script attaches to object A.
    // When touched by the player, it makes object B opaque.

    // Note: Object A should start opaque

    // Object B
    [SerializeField] private GameObject objectToFade;
    private float fadeDuration = 1f;
    private SpriteRenderer objectRenderer;
    private Color originalColor;

    private void Start()
    {
        objectRenderer = objectToFade.GetComponent<SpriteRenderer>();
        originalColor = objectRenderer.color;

        Color transparentColor = originalColor;
        transparentColor.a = 0f;
        objectRenderer.color = transparentColor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeToOpaque());
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
