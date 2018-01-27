// The player bouncing object class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBouncingObject : MonoBehaviour
{
    [HideInInspector]
    public bool isInputEnabled = false;


    // Movement variables
    [HeaderAttribute("Movement Variables")]

    [SerializeField]
    private float direction = 1;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float speedIncreaseFactor = 0.5f;
    [SerializeField]
    private float speedCap = 100.0f;

    [HideInInspector]
    private bool canMove = false;

    // Colour state variables
    [HeaderAttribute("Colour State Variables"), SpaceAttribute(2.0f)]

    [SerializeField]
    private ColourStates currentColourState = ColourStates.Red;
    [SerializeField]
    private Material[] colourStateMaterials; // Index 0: Red, Index 1: Green, Index 2, Blue
    private int colourSwitchCount = 0;


    // Visual colour variables
    [SerializeField]
    private float colourBlendSpeed = 10.0f;
    private Color targetVisualColour = Color.black;
    private Color[] possibleVisualColourTargets = new Color[3]; // Index 0: Red, Index 1: Green, Index 2, Blue


    // Bounce Count variables
    [HideInInspector]
    private int bounceCount = 0;

    [SerializeField]
    private GameObject destructionEffect;

    // Explosion audio source
    [SerializeField]
    private PlayerExplosionSoundScript explosionAudioSource;

    // Components
    private Rigidbody rb;
    private Renderer meshRenderer;
    private Collider colliderComp;

    // External references
    private HUDLayerController hudLayerController;

    /*--Getters and Setters--*/

    public int getBounceCount()
    {
        return bounceCount;
    }

    public void setBounceCount(int bounceCount)
    {
        this.bounceCount = bounceCount;
    }


    public ColourStates getCurrentColourState()
    {
        return currentColourState;
    }

    public void setCurrentColourState(ColourStates currentColourState)
    {
        this.currentColourState = currentColourState;
    }


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<Renderer>();
        colliderComp = GetComponent<Collider>();
        hudLayerController = FindObjectOfType<HUDLayerController>();
    }


    // Use this for initialization
    void Start()
    {
        // Set the possible target colours
        for (int i = 0; i < possibleVisualColourTargets.Length; i++)
        {
            possibleVisualColourTargets[i] = colourStateMaterials[i].color;
        }

        // Set the starting colour state of the player
        int selectionNum = Random.Range(0, 3);

        if (selectionNum == 0)
        {
            setColourState(ColourStates.Red);
        }

        else if (selectionNum == 1)
        {
            setColourState(ColourStates.Green);
        }

        else if (selectionNum == 2)
        {
            setColourState(ColourStates.Blue);
        }

        else
        {
            setColourState(ColourStates.Blue);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInputEnabled == true)
        {
            // If the A key is pressed
            if (Input.GetKeyDown(KeyCode.A) && (currentColourState != ColourStates.Red))
            {
                // Set the colour state to red
                setColourState(ColourStates.Red);
                colourSwitchCount++;
            }


            // If the S key is pressed
            else if (Input.GetKeyDown(KeyCode.S) && (currentColourState != ColourStates.Green))
            {
                // Set the colour state to green
                setColourState(ColourStates.Green);
                colourSwitchCount++;
            }


            // If the D key is pressed
            else if (Input.GetKeyDown(KeyCode.D) && (currentColourState != ColourStates.Blue))
            {
                // Set the colour state to blue
                setColourState(ColourStates.Blue);
                colourSwitchCount++;
            }
        }

        // Blend to the target visual colour
        meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, targetVisualColour, Time.deltaTime * colourBlendSpeed);
    }

    void FixedUpdate()
    {
        if (canMove == true)
        {
            rb.AddForce(Vector3.forward * direction * speed * Time.fixedDeltaTime, ForceMode.Force);
        }
    }

    // Set the colour state
    private void setColourState(ColourStates newColourState)
    {
        // Set the current colour state as the new colour state parameter
        currentColourState = newColourState;

        // Set the material of the mesh based on the new colour state
        switch (newColourState)
        {
            case ColourStates.Red:
                targetVisualColour = possibleVisualColourTargets[0];
                break;

            case ColourStates.Green:
                targetVisualColour = possibleVisualColourTargets[1];
                break;

            case ColourStates.Blue:
                targetVisualColour = possibleVisualColourTargets[2];
                break;

            default:
                targetVisualColour = possibleVisualColourTargets[0];
                break;
        }


    }

    // Reverse player movement
    public void reverseMovement()
    {
        direction *= -1;
        speed = Mathf.Clamp(speed + speedIncreaseFactor, 0.0f, speedCap);
        increaseBounceCount();
    }

    // Increase the bounce count
    public void increaseBounceCount()
    {
        // If the colour switch count is less than 2
        if (colourSwitchCount < 2)
        {
            // Add 2 to the player's score
            setBounceCount(getBounceCount() + 2);

            // Spawn the alert text
            hudLayerController.getGameplayHUDLayer().printAlertText("Switch Bonus");
        }

        // Otherwise
        else
        {
            // Add 1 to the player's score
            setBounceCount(getBounceCount() + 1);
        }

        colourSwitchCount = 0;
        hudLayerController.getGameplayHUDLayer().updateHUDElements();

        // If the bounce count is equal to the target
        if (bounceCount >= ScoreTargetController.scoreTarget)
        {
            // End the game
            StartCoroutine(GameStateController.endGame());
        }
    }



    // Enable the player
    public void enable()
    {
        isInputEnabled = true;
        canMove = true;
    }

    // Disable the player
    public void disable()
    {
        canMove = false;
        isInputEnabled = false;
        meshRenderer.enabled = false;
        colliderComp.enabled = false;
        Instantiate(destructionEffect, transform.position, Quaternion.identity);
        explosionAudioSource.playSound();
    }
}
