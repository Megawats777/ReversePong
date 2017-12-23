using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHUDLayer : MonoBehaviour
{
	// Text variables
	public Text bounceCountText;
	public Text targetText;

	// External references
	PlayerBouncingObject player;

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
		bounceCountText.text = "Bounces: " + player.bounceCount;
		targetText.text = "Target: " + ScoreTargetController.scoreTarget;
	}
}
