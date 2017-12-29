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
    
    // Animation elements
    private Animation animComp;
    public AnimationClip showAnimClip;

    // External references
    PlayerBouncingObject player;

    void Awake()
    {
        animComp = GetComponent<Animation>();
        player = FindObjectOfType<PlayerBouncingObject>();
    }


    // Use this for initialization
    void Start()
    {
        animComp.clip = showAnimClip;
        animComp.Play();
    }

    // Update is called once per frame
    void Update()
    {
        updateHUDElements();
    }

    // Show this HUD layer
    public void show()
    {
        animComp.clip = showAnimClip;
        animComp.Play();
    }

    // Hide this HUD layer
    public void hide()
    {

    }

    // Update HUD elements
    private void updateHUDElements()
    {
        bounceCountText.text = player.bounceCount.ToString();
        targetText.text = ScoreTargetController.scoreTarget.ToString();
    }
}
