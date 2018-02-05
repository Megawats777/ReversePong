using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{

    // External refrences
    private static PlayerBouncingObject player;
    private static HUDLayerController hudLayerController;


    void Awake()
    {
        player = FindObjectOfType<PlayerBouncingObject>();
        hudLayerController = FindObjectOfType<HUDLayerController>();
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(startGame());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Start the game
    public static IEnumerator startGame()
    {
        hudLayerController.showStartingHUDLayer();
        yield return new WaitForSeconds(3.0f);

        hudLayerController.hideStartingHUDLayer();
        hudLayerController.showGameplayHUDLayer();

        ScoreTargetController.generateScoreTarget();
        player.enable();

        hudLayerController.getGameplayHUDLayer().updateHUDElements();
    }

    // End the game
    public static IEnumerator endGame()
    {
        player.disable();
        hudLayerController.hideGameplayHUDLayer();

        yield return new WaitForSeconds(2.0f);

        // If the player is on the final stage
        // Show the stage run end HUD layer
        if (StageSystemManager.isOnFinalStage() == true)
        {
            hudLayerController.showStageRunEndHUDLayer();
        }

        // Otherwise
        // Show the game over HUD layer
        else
        {
            hudLayerController.showGameOverHUDLayer();
        }
    }
}
