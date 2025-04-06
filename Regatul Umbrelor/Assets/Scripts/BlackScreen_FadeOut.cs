using System.Collections;
using UnityEngine;

public class BlackScreen_FadeOut : MonoBehaviour
{
    // fade out an object on scene load

    [SerializeField] private GameObject objectToFade;
    private float fadeDuration = 1.5f;
    private SpriteRenderer objectRenderer;

    private void Start()
    {
        objectRenderer = objectToFade.GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Color startColor = objectRenderer.color;
        Color targetColor = startColor;
        targetColor.a = 0f;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime / fadeDuration);
            objectRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        objectRenderer.color = targetColor;
    }
}
