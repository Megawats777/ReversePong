﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHUDLayer : MonoBehaviour
{
	// Text variables
	public Text titleText;
	public Text scoreGoalText;
	public Text playerBounceResultText;
	public Button restartButton;
	public Button quitButton;

	// External references
	private PlayerBouncingObject player;


	void Awake()
	{
		player = FindObjectOfType<PlayerBouncingObject>();
	}

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	// When this HUD layer is shown
	public void show()
	{
		restartButton.onClick.AddListener(delegate{
			SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
		});

		quitButton.onClick.AddListener(delegate{
			Application.Quit();
		});

		// Set the content of the title based on whether the player
		// reached the score target
		if (player.bounceCount == ScoreTargetController.scoreTarget)
		{
			titleText.text = "You Win!";
		}

		else
		{
			titleText.text = "You Lose";
		}

		scoreGoalText.text = "Bounce " + ScoreTargetController.scoreTarget + " time(s)";
		playerBounceResultText.text = "Bounced " + player.bounceCount + " time(s)";
	}
}
