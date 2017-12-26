using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHUDLayer : MonoBehaviour
{
    // HUD Elements
    [HeaderAttribute("HUD Elements")]
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
        updateHUDElements();
    }

    // Update HUD elements
    private void updateHUDElements()
    {
        bounceCountText.text = "Bounces: " + player.bounceCount;
        targetText.text = "Target: " + ScoreTargetController.scoreTarget;
    }
}
