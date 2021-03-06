﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHUDLayer : MonoBehaviour
{
    // HUD Elements
    [HeaderAttribute("HUD Elements")]
    [SerializeField]
    private Text bounceCountText;
    [SerializeField]
    private Text targetText;
    [SerializeField]
    private Text stageText;

    // Animation elements
    [SerializeField]
    private Animator animComp;

    // Alert text spawn points
    // Index 0: Left side, Index 1: Right Side
    [SerializeField]
    private Transform[] alertTextSpawnPoints;

    [SerializeField]
    private AlertText alertTextPrefab;

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

    }

    // Show this HUD layer
    public void show()
    {
        string stageTextAddition = string.Empty;
        stageTextAddition = StageSystemManager.isOnFinalStage() == true ? " (final)" : string.Empty;

        stageText.text = "Stage " + StageSystemManager.getCurrentStage().ToString() + stageTextAddition;

        animComp.SetBool("isShowing", true);
        animComp.SetBool("isHiding", false);
    }

    // Hide this HUD layer
    public void hide()
    {
        animComp.SetBool("isHiding", true);
        animComp.SetBool("isShowing", false);
    }

    // Update HUD elements
    public void updateHUDElements()
    {
        bounceCountText.text = player.getBounceCount().ToString();
        targetText.text = ScoreTargetController.getScoreTarget().ToString();
    }

    // Print alert text
    public void printAlertText(string message)
    {
        Vector3 spawnLocation = Vector3.zero;

        // If the player's location is greater than 0 on the z-axis
        // Set the spawn location to be the left side
        if (player.transform.position.z > 0)
        {
            spawnLocation = alertTextSpawnPoints[0].position;
        }

        // Otherwise set the spawn location to be the right side
        else
        {
            spawnLocation = alertTextSpawnPoints[1].position;
        }

        

        AlertText spawnedText = Instantiate(alertTextPrefab, spawnLocation,
            Quaternion.identity);

        spawnedText.setTextContent(message);
        spawnedText.gameObject.transform.SetParent(this.transform);
        spawnedText.gameObject.transform.localScale = Vector3.one;

        Destroy(spawnedText.gameObject, 20.0f);
    }

}
