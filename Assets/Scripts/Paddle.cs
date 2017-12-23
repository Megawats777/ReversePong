using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // State materials
    // Index 0: Red
    // Index 1: Green
    // Index 2: Blue
    [SerializeField]
    private Material[] stateMaterials;

    // Current colour state
    public ColourStates currentColourState = ColourStates.Red;
    private ColourStates previousColourState = ColourStates.Red;

    // Components
    Renderer renderer;


    // External references
    PlayerBouncingObject player;
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
        setColourState();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // Set colour state
    private void setColourState()
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

        if (currentColourState == previousColourState)
        {
            setColourState();
        }
        else
        {
            if (currentColourState == opositePaddle.currentColourState)
            {
                setColourState();
            }

            else
            {
                previousColourState = currentColourState;

                // Depending on the colour state determine the material for this paddle
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
                opositePaddle.setColourState();
            }
        }

        // Otherwise
		else
		{
			player.disable();

            hudLayerController.hideGameplayHUDLayer();
            hudLayerController.showGameOverHUDLayer();
		}
    }
}
