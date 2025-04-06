using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] int cutSceneId;
    [SerializeField] private GameObject fogOfWar;
    [SerializeField] private Vector3[] positions;
    private int positionIndex;
    private bool atTheEnd;
    private void Start()
    {
        fogOfWar.transform.position = positions[0];
        positionIndex = 0;
        atTheEnd = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !atTheEnd)
        {
            positionIndex++;
            Debug.Log(positionIndex);

            fogOfWar.transform.position = positions[positionIndex];

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
