using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] int cutSceneId;
    [SerializeField] private GameObject fogOfWar;
    [SerializeField] private Vector3[] positions;

    [Header("Speech GameObjects")]
    public GameObject firstSpeech;
    public GameObject secondSpeech;
    public GameObject lastSpeech;

    public GameObject amulet;

    private GameObject[] speeches;

    private int positionIndex;
    private bool atTheEnd;
    private void Start()
    {
        fogOfWar.transform.position = positions[0];
        positionIndex = 0;
        atTheEnd = false;

        speeches = new GameObject[3];
        speeches[0] = firstSpeech;
        speeches[1] = secondSpeech;
        speeches[2] = lastSpeech;

        // Optionally, ensure all speech objects are inactive at the start
        foreach (GameObject speech in speeches)
        {
            if (speech != null)
                speech.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !atTheEnd)
        {
            positionIndex++;
            Debug.Log(positionIndex);

            fogOfWar.transform.position = positions[positionIndex];

            for (int i = 0; i < speeches.Length; i++)
            {
                speeches[i].SetActive(i == positionIndex - 1);
            }

            if (positionIndex == 2)
            {
                amulet.SetActive(true);
            }

            if (positionIndex == 3) {
                atTheEnd = true;
                return;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && atTheEnd)
        {
            positionIndex = 0;
            atTheEnd = false;

            if (cutSceneId == 0)
            {
                /*Load next scene*/
                SceneManager.LoadScene("Hallway01");
            }

            if (cutSceneId == 1)
            {
                /*Load credit scene*/
            }
        }
    }
}
