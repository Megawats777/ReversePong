﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDLayerController : MonoBehaviour
{
	// HUD layer variables
	[HeaderAttribute("HUD Layer References"),SerializeField]
	private GameplayHUDLayer gameplayHUDLayer;
	[SerializeField]
	private GameOverHUDLayer gameOverHUDLayer;
	[SerializeField]
	private StartingHUDLayer startingHUDLayer;

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


	// Starting HUD layer code
	public void showStartingHUDLayer()
	{
		startingHUDLayer.gameObject.SetActive(true);
		startingHUDLayer.show();
	}

	public void hideStartingHUDLayer()
	{
		StartCoroutine(startingHUDLayer.hide());
	}



	// Gameplay HUD layer code
	public void showGameplayHUDLayer()
	{
		gameplayHUDLayer.gameObject.SetActive(true);
		gameplayHUDLayer.show();
	}

	public void hideGameplayHUDLayer()
	{
		gameplayHUDLayer.hide();
	}


	// Game Over HUD layer code
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
