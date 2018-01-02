using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	// Global ui elements
	[HeaderAttribute("Global UI Elements")]
	public Text currentScreenIndicator;
	public Text loadingText;


	// HUD layers
	[HeaderAttribute("HUD Layers")]
	public GameObject welcomeScreen;
	public GameObject helpScreen;
	public GameObject optionsScreen;
	public GameObject creditsScreen;


	// Welcome screen elements
	[HeaderAttribute("Welcome Screen Elements")]
	public Button playButton;
	public Button helpButton;
	public Button optionsButton;
	public Button creditsButton;
	public Button quitButton;

    // Use this for initialization
    void Start()
    {
		loadingText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

	// UI visibiliy functions

	void welcomeScreen_show()
	{

	}

	void welcomeScreen_hide()
	{

	}



	void helpScreen_show()
	{

	}

	void helpScreen_hide()
	{

	}



	void optionsScreen_show()
	{

	}

	void optionsScreen_hide()
	{

	}


	void creditsScreen_show()
	{

	}

	void creditsScreen_hide()
	{
		
	}
}
