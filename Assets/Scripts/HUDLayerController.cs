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
    [SerializeField]
    private StageRunEndHUDLayer stageRunEndHUDLayer;

	// Ui Elements
	[HeaderAttribute("Ui Elements"), SerializeField]
	private Text statusText;

	/*--Getters and Setters--*/

	public GameplayHUDLayer getGameplayHUDLayer()
	{
		return gameplayHUDLayer;
	}

	public GameOverHUDLayer getGameOverHUDLayer()
	{
		return gameOverHUDLayer;
	}

    public StageRunEndHUDLayer getStageRunEndHUDLayer()
    {
        return stageRunEndHUDLayer;
    }

    // Use this for initialization
    void Start()
    {
		statusText.gameObject.SetActive(false);
		gameplayHUDLayer.gameObject.SetActive(false);
		gameOverHUDLayer.gameObject.SetActive(false);
        stageRunEndHUDLayer.gameObject.SetActive(false);
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


    // Stage run end HUD layer code
    public void showStageRunEndHUDLayer()
    {
        stageRunEndHUDLayer.gameObject.SetActive(true);
        stageRunEndHUDLayer.show();
    }

    public void hideStageRunEndHUDLayer()
    {
        stageRunEndHUDLayer.gameObject.SetActive(false);
    }
}
