using System.Collections;
using TMPro;
using UnityEngine;

public class TextFadeLeftToRight : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private float delayBetweenChars = 0.1f;
    [SerializeField] private bool autoFadeOut = true;

    private void Start()
    {
        StartCoroutine(FadeText());
    }

    private IEnumerator FadeText()
    {
        tmpText.ForceMeshUpdate();
        TMP_TextInfo textInfo = tmpText.textInfo;
        int totalChars = textInfo.characterCount;

        // Set all character alphas to 0
        for (int i = 0; i < totalChars; i++)
        {
           SetCharAlpha(i, 0f);
        }

        tmpText.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

        // Fade in one by one
        for (int i = 0; i < totalChars; i++)
        {
            StartCoroutine(FadeCharacter(i, 1f, 0.2f));
            yield return new WaitForSeconds(delayBetweenChars);
        }

        yield return new WaitForSeconds(3 * delayBetweenChars);

        if (autoFadeOut)
        {
            // Fade out all at once
            for (int i = 0; i < totalChars; i++)
            {
                StartCoroutine(FadeCharacter(i, 0f, 0.2f));
            }
        }
    }

    private IEnumerator FadeCharacter(int index, float targetAlpha, float duration)
    {
        float time = 0f;
        float startAlpha;

        if (targetAlpha == 1f)
            startAlpha = 0f;
        else
            startAlpha = 1f;

        while (time < duration)
        {
            float t = time / duration;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            SetCharAlpha(index, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        SetCharAlpha(index, targetAlpha);
    }

    private void SetCharAlpha(int index, float alpha)
    {
        TMP_TextInfo textInfo = tmpText.textInfo;
        if (index >= textInfo.characterCount) return;

        var charInfo = textInfo.characterInfo[index];
        if (!charInfo.isVisible) return;

        int matIndex = charInfo.materialReferenceIndex;
        int vertIndex = charInfo.vertexIndex;

        Color32[] newVertexColors = textInfo.meshInfo[matIndex].colors32;
        for (int i = 0; i < 4; i++)
        {
            newVertexColors[vertIndex + i].a = (byte)(alpha * 255);
        }

        tmpText.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
    }
}
