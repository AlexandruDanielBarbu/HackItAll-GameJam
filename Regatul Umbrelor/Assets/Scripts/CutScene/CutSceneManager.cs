using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] int cutSceneId;
    [SerializeField] private GameObject fogOfWar;
    [SerializeField] private Vector3[] positions;
    private int positionIndex = 0;
    private void Awake()
    {
        fogOfWar.transform.position = positions[0];
        positionIndex++;
    }

    private bool atTheEnd = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !atTheEnd)
        {
            fogOfWar.transform.position = positions[positionIndex];
            positionIndex++;

            positionIndex %= positions.Length;

            if (positionIndex == 0)
            {
                atTheEnd = true;
            }
        } else if (Input.GetKeyDown(KeyCode.Mouse0) && atTheEnd)
        {
            if (cutSceneId == 0)
            {
                /*Load gameplay scene*/
                SceneLoading.Instance.TransitionToScene("AlexDevNextScene");
            }

            if (cutSceneId == 1)
            {
                /*Load credit scene*/
            }
        }
    }
}
