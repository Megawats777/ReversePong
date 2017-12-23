using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHUDLayer : MonoBehaviour
{
	// Text variables
	public Text bounceCountText;

	// External references
	BouncingObject player;

	void Awake()
	{
		player = FindObjectOfType<BouncingObject>();
	}


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		bounceCountText.text = "Bounces: " + player.bounceCount;
    }
}
