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

    // Colour state explosition particle effect
    [SerializeField]
    private GameObject effectSpawnPoint;
    [SerializeField]
    private ParticleSystem[] colourStateExplosionEffect;

    // Target visual colour
    private Color targetVisualColour = Color.black;
    private Color redPaddleColour;
    private Color greenPaddleColour;
    private Color bluePaddleColour;
    private Color disabledPaddleColour;

    // Components
    Renderer rendererComp;

    // Audio Source
    [SerializeField]
    private PaddleCollisionSoundScript collisionAudioSource;

    float colourBlendSpeed = 10.0f;


    // External references
    PlayerBouncingObject player;
    [HeaderAttribute("External References")]
    public Paddle opositePaddle;
    private HUDLayerController hudLayerController;

    void Awake()
    {
        rendererComp = GetComponent<Renderer>();
        player = FindObjectOfType<PlayerBouncingObject>();
        hudLayerController = FindObjectOfType<HUDLayerController>();
    }

    // Use this for initialization
    void Start()
    {
        redPaddleColour = stateMaterials[0].color;
        greenPaddleColour = stateMaterials[1].color;
        bluePaddleColour = stateMaterials[2].color;
        disabledPaddleColour = disabledMaterial.color;

        setRandomColourState();

        if (isFirstPaddle == false)
        {
            targetVisualColour = disabledPaddleColour;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Always blend to the target colour
        rendererComp.material.color = Color.Lerp(rendererComp.material.color, targetVisualColour, Time.deltaTime * colourBlendSpeed);
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
            targetVisualColour = redPaddleColour;
        }

        else if (currentColourState == ColourStates.Green)
        {
            targetVisualColour = greenPaddleColour;
        }

        else if (currentColourState == ColourStates.Blue)
        {
            targetVisualColour = bluePaddleColour;
        }
    }

    // Spawn particle effect
    private void spawnParticleEffect()
    {
        int selectedIndex = 0;

        switch (currentColourState)
        {
            case ColourStates.Red:
                selectedIndex = 0;
                break;

            case ColourStates.Green:
                selectedIndex = 1;
                break;

            case ColourStates.Blue:
                selectedIndex = 2;
                break;

            default:
                selectedIndex = 0;
                break;
        }

        GameObject spawnedEffect = Instantiate(colourStateExplosionEffect[selectedIndex], effectSpawnPoint.transform.position, Quaternion.identity).gameObject;
        Destroy(spawnedEffect, 10.0f);
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
                    collisionAudioSource.playSound();
                    spawnParticleEffect();
                    targetVisualColour = disabledPaddleColour;
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
