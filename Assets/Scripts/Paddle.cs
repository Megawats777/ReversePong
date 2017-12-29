using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField]
    private Material disabledMaterial;
    [SerializeField]
    private bool isFirstPaddle;

    // State materials
    // Index 0: Red
    // Index 1: Green
    // Index 2: Blue
    [HeaderAttribute("Colour State Variables"), SerializeField]
    private Material[] stateMaterials;

    // Current colour state
    public ColourStates currentColourState = ColourStates.Red;

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

        if (isFirstPaddle == false)
        {
            renderer.material = disabledMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {

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
    public void selectNewColourState()
    {
        Random.InitState((int)System.DateTime.Now.Millisecond);
        ColourStates chosenColourState;

        do
        {
            // Select a random colour state
            int result = Random.Range(0, 3);
            switch (result)
            {
                case 0:
                    chosenColourState = ColourStates.Red;
                    break;

                case 1:
                    chosenColourState = ColourStates.Blue;
                    break;

                case 2:
                    chosenColourState = ColourStates.Green;
                    break;


                default:
                    chosenColourState = ColourStates.Red;
                    break;
            }
            
        } while (chosenColourState == player.currentColourState);

        // Set the chosen colour state as the current one
        // Apply colour state settings
        currentColourState = chosenColourState;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            if (currentColourState == player.currentColourState)
            {
                player.reverseMovement();

                if (opositePaddle)
                {
                    renderer.material = disabledMaterial;
                    opositePaddle.selectNewColourState();
                }
            }

            else
            {
                StartCoroutine(GameStateController.endGame());
            }

        }
    }
}
