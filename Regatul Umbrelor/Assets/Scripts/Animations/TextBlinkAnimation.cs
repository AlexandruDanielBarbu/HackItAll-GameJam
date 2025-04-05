using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBlinkAnimation : MonoBehaviour
{
    [SerializeField] private float timeBetweenBlinks = 1f;

    private float timer;
    private TMP_Text tmpText;
    private bool isVisible = true;

    private void Awake()
    {
        tmpText = GetComponent<TMP_Text>();
        timer = timeBetweenBlinks;
        SetAlpha(1f);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = timeBetweenBlinks;
            isVisible = !isVisible;
            SetAlpha(isVisible ? 1f : 0f);
        }
    }

    private void SetAlpha(float alpha)
    {
        if (tmpText != null)
        {
            Color color = tmpText.color;
            color.a = alpha;
            tmpText.color = color;
        }
    }
}
