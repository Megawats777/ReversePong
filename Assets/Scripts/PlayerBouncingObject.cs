﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBouncingObject : MonoBehaviour
{
    [HideInInspector]
    public bool isInputEnabled = false;


    // Movement variables
    public float direction = 1;
    public float speed = 5.0f;
    public float speedIncreaseFactor = 0.5f;

    [HideInInspector]
    public bool canMove = false;

    // Colour state variables
    public ColourStates currentColourState = ColourStates.Red;
    public Material[] colourStateMaterials; // Index 0: Red, Index 1: Green, Index 2, Blue


    // Bounce Count variables
    public int bounceCount = 0;


    // Components
    public Rigidbody rb;
    public Renderer meshRenderer;
    public Collider collider;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }


    // Use this for initialization
    void Start()
    {
        setColourState(ColourStates.Red);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInputEnabled == true)
        {
            // If the 1 key is pressed
            if (Input.GetKeyDown(KeyCode.A))
            {
                // Set the colour state to red
                setColourState(ColourStates.Red);
            }


            // If the 2 key is pressed
            else if (Input.GetKeyDown(KeyCode.S))
            {
                // Set the colour state to green
                setColourState(ColourStates.Green);
            }


            // If the 3 key is pressed
            else if (Input.GetKeyDown(KeyCode.D))
            {
                // Set the colour state to blue
                setColourState(ColourStates.Blue);
            }
        }
    }

    void FixedUpdate()
    {
        if (canMove == true)
        {
            rb.AddForce(transform.forward * direction * speed * Time.fixedDeltaTime);
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
                meshRenderer.material = colourStateMaterials[0];
                break;

            case ColourStates.Green:
                meshRenderer.material = colourStateMaterials[1];
                break;

            case ColourStates.Blue:
                meshRenderer.material = colourStateMaterials[2];
                break;

            default:
                meshRenderer.material = colourStateMaterials[0];
                break;
        }


    }

    // Reverse player movement
    public void reverseMovement()
    {
        direction *= -1;
        speed = Mathf.Clamp(speed + speedIncreaseFactor, 0.0f, 100.0f);
        increaseBounceCount();
    }

    // Increase the bounce count
    public void increaseBounceCount()
    {
        bounceCount += 1;

        // If the bounce count is equal to the target
        if (bounceCount == ScoreTargetController.scoreTarget)
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
        collider.enabled = false;
    }
}
