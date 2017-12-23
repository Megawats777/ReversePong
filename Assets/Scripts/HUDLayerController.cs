using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDLayerController : MonoBehaviour
{
	// HUD layer variables
	public GameplayHUDLayer gameplayHUDLayer;
	public GameOverHUDLayer gameOverHUDLayer;
	public StartingHUDLayer startingHUDLayer;

    // Use this for initialization
    void Start()
    {
		gameplayHUDLayer.gameObject.SetActive(false);
		gameOverHUDLayer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


	// Starting HUD code
	public void showStartingHUDLayer()
	{
		startingHUDLayer.gameObject.SetActive(true);
	}

	public void hideStartingHUDLayer()
	{
		StartCoroutine(startingHUDLayer.hide());
	}



	// Gameplay HUD code
	public void showGameplayHUDLayer()
	{
		gameplayHUDLayer.gameObject.SetActive(true);
	}

	public void hideGameplayHUDLayer()
	{
		gameplayHUDLayer.gameObject.SetActive(false);
	}


	// Game Over HUD code
	public void showGameOverHUDLayer()
	{
		gameOverHUDLayer.gameObject.SetActive(true);
		gameOverHUDLayer.show();
	}

	public void hideGameOverHUDLayer()
	{
		gameOverHUDLayer.gameObject.SetActive(false);
	}
}
