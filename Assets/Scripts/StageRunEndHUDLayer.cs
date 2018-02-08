﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageRunEndHUDLayer : MonoBehaviour
{
    // Ui Elements
    [Header("UI Elements")]
    [SerializeField]
    private Text winsText;
    [SerializeField]
    private Text rankText;
    [SerializeField]
    private Button quitButton;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Show this layer
    public void show()
    {
        // Add on click listener
        quitButton.onClick.AddListener(delegate
        {
            SceneManager.LoadSceneAsync("MainMenu");
        });

        winsText.text = PlayerStatsContainer.getWins().ToString() + " / " + StageSystemManager.getFinalStage().ToString();
        rankText.text = StageSystemManager.getPlayerRank(PlayerStatsContainer.getWins());
    }

    // Hide this layer
    public void hide()
    {

    }
}
