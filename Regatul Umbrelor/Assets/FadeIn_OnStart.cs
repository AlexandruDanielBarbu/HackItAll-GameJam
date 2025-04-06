using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn_OnActive : MonoBehaviour
{
    [SerializeField] private GameObject objectToFade;
    private float fadeDuration = 0.5f;
    private SpriteRenderer objectRenderer;
    private Color opaqueColor;

    private void Start()
    {
        objectRenderer = objectToFade.GetComponent<SpriteRenderer>();

        opaqueColor = objectRenderer.color;
        opaqueColor.a = 1f;

        Color transparentColor = opaqueColor;
        transparentColor.a = 0f;
        objectRenderer.color = transparentColor;

        StartCoroutine(FadeToOpaque());
    }

    private IEnumerator FadeToOpaque()
    {
        float elapsedTime = 0f;
        Color startColor = objectRenderer.color;
        Color targetColor = opaqueColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime / fadeDuration);
            objectRenderer.color = new Color(targetColor.r, targetColor.g, targetColor.b, alpha);
            yield return null;
        }

        objectRenderer.color = targetColor;
    }
}
