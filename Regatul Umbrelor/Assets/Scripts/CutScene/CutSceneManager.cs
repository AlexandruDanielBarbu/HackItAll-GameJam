using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject fogOfWar;
    [SerializeField] private Vector3[] positions;
    private int positionIndex = 0;
    private void Awake()
    {
        fogOfWar.transform.position = positions[0];
        positionIndex++;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fogOfWar.transform.position = positions[positionIndex];
            positionIndex++;
            positionIndex %= positions.Length; 
        }
    }
}
