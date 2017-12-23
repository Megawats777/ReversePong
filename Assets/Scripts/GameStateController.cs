using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{

	// External refrences
	private PlayerBouncingObject player;
	private HUDLayerController hudLayerController;


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
	IEnumerator startGame()
	{
		hudLayerController.showStartingHUDLayer();
		yield return new WaitForSeconds(3.0f);
		
		hudLayerController.hideStartingHUDLayer();
		hudLayerController.showGameplayHUDLayer();

		ScoreTargetController.generateScoreTarget();
		player.enable();
	}
}
