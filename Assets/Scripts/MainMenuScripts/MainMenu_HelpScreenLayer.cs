using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_HelpScreenLayer : MonoBehaviour
{

	// External references
	private MainMenu_LayerController mainMenu_LayerController;


	// Called before start
	void Awake()
	{
		mainMenu_LayerController = FindObjectOfType<MainMenu_LayerController>();
	}

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	// Show this layer
	public void show()
	{

	}

	// Hide this layer
	public void hide()
	{

	}
}
