using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // State materials
    // Index 0: Red
    // Index 1: Green
    // Index 2: Blue
    [HeaderAttribute("Colour State Variables"), SerializeField]
    private Material[] stateMaterials;

    // Current colour state
    public ColourStates currentColourState = ColourStates.Red;
    private ColourStates previousColourState = ColourStates.Red;

    // Components
    Renderer renderer;


    // External references
    PlayerBouncingObject player;
    [HeaderAttribute("External References")]
    public Paddle opositePaddle;
    private HUDLayerController hudLayerController;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        player = FindObjectOfType<PlayerBouncingObject>();
        hudLayerController = FindObjectOfType<HUDLayerController>();
    }

    // Use this for initialization
    void Start()
    {
        setRandomColourState();
    }

    // Update is called once per frame
    void Update()
    {
        Random.InitState((int)Time.realtimeSinceStartup);
    }

    // Set random colour state
    private void setRandomColourState()
    {
        int selectionNum = Random.Range(0, 3);

        // Depending on the selection num determine the current colour state
        switch (selectionNum)
        {
            case 0:
                currentColourState = ColourStates.Red;
                break;

            case 1:
                currentColourState = ColourStates.Green;
                break;

            case 2:
                currentColourState = ColourStates.Blue;
                break;

            default:
                currentColourState = ColourStates.Red;
                break;
        }

        // Depending on the colour state determine the material for this paddle
        applyColourStateSettings(currentColourState);
    }


    // Select new colour state
    public void selectNewColourState(ColourStates colourStateTold)
    {

        // Based on what the other paddle told you
        // about its colour state

        // If the colour state told was red
        if (colourStateTold == ColourStates.Red)
        {
            // Select either blue or green as your new colour state
            int result = (int)Random.value;

            switch (result)
            {
                case 0:
                    currentColourState = ColourStates.Blue;
                    break;

                case 1:
                    currentColourState = ColourStates.Green;
                    break;

                default:
                    currentColourState = ColourStates.Blue;
                    break;
            }
        }

        // If the colour state told was green
        else if (colourStateTold == ColourStates.Green)
        {
            // Select either red or blue as your new colour state
            int result = (int)Random.value;

            switch (result)
            {
                case 0:
                    currentColourState = ColourStates.Red;
                    break;

                case 1:
                    currentColourState = ColourStates.Blue;
                    break;

                default:
                    currentColourState = ColourStates.Red;
                    break;
            }
        }

        // If the colour state told was blue
        else if (colourStateTold == ColourStates.Blue)
        {
            // Select either red or green as your new colour state
            int result = (int)Random.value;

            switch (result)
            {
                case 0:
                    currentColourState = ColourStates.Red;
                    break;

                case 1:
                    currentColourState = ColourStates.Green;
                    break;

                default:
                    currentColourState = ColourStates.Red;
                    break;
            }
        }

        // Apply colour state settings
        applyColourStateSettings(currentColourState);
    }

    // Apply Colour state settings
    private void applyColourStateSettings(ColourStates colourState)
    {
        if (currentColourState == ColourStates.Red)
        {
            renderer.material = stateMaterials[0];
        }

        else if (currentColourState == ColourStates.Green)
        {
            renderer.material = stateMaterials[1];
        }

        else if (currentColourState == ColourStates.Blue)
        {
            renderer.material = stateMaterials[2];
        }
    }


    // On Collision
    void OnCollisionEnter(Collision collision)
    {
        // If the colliding object is the player
        // and the player's colour state is the same as this one
        if (collision.gameObject.CompareTag("Player") && currentColourState == player.currentColourState)
        {
            player.reverseMovement();

            if (opositePaddle)
            {
                opositePaddle.selectNewColourState(currentColourState);
            }
        }

        // Otherwise
        else
        {
            StartCoroutine(GameStateController.endGame());
        }
    }
}
