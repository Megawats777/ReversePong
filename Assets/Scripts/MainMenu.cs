using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	// Global ui elements
	public Text currentScreenIndicator;
	public Text loadingText;

    // Use this for initialization
    void Start()
    {
		loadingText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
