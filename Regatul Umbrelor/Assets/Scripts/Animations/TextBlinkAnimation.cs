using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBlinkAnimation : MonoBehaviour
{
    [SerializeField] float timeBetweenBlinks = 1f;

    float timer;

    private void Awake()
    {
        timer = timeBetweenBlinks;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if (timer < 0)
        {
            timer = timeBetweenBlinks;
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
