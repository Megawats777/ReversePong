using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_HelpScreenLayer : MonoBehaviour
{
    // Element references
    [Header("Element References"), SerializeField]
    private Button backButton;

    // External references
    private MainMenu_LayerController mainMenu_LayerController;


    // Called before start
    void Awake()
    {
        mainMenu_LayerController = FindObjectOfType<MainMenu_LayerController>();

        // Add functions to buttons
        backButton.onClick.AddListener(delegate
        {
            mainMenu_LayerController.show_welcomeScreen();
            mainMenu_LayerController.hide_helpScreen();
        });
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
