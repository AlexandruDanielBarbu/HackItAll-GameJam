using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public GameObject interactText;
    private TextMeshProUGUI tmpText;
    private bool isPlayerNear = false;
    private Coroutine fadeCoroutine;

    public float fadeDuration = 0.5f;

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
        Debug.Log("Ai interacționat cu obiectul!");
        // Load the scene directly
        SceneManager.LoadScene("CutSceneBegin");
    }
}
