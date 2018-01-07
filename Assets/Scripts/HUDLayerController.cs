using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDLayerController : MonoBehaviour
{
	// HUD layer variables
	[HeaderAttribute("HUD Layer References"),SerializeField]
	private GameplayHUDLayer gameplayHUDLayer;
	[SerializeField]
	private GameOverHUDLayer gameOverHUDLayer;
	[SerializeField]
	private StartingHUDLayer startingHUDLayer;

	// Ui Elements
	[HeaderAttribute("Ui Elements"), SerializeField]
	private Text statusText;

    // Use this for initialization
    void Start()
    {
		statusText.gameObject.SetActive(false);
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
