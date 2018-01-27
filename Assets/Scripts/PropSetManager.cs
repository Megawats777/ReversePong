using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSetManager : MonoBehaviour
{
    // List of prop sets
    [SerializeField]
    private GameObject[] propSets;


    // Use this for initialization
    void Start()
    {
        // Disable all prop sets
        foreach (GameObject currentSet in propSets)
        {
            if (currentSet)
            {
                currentSet.SetActive(false);
            }
        }

        // Select a random prop set to enable
        int selectionNum = Random.Range(0, propSets.Length);

        if (propSets[selectionNum])
        {
            propSets[selectionNum].SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
