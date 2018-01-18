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
    [SerializeField]
    private Animator animComp;

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
        // updateHUDElements();
    }

    // Show this HUD layer
    public void show()
    {
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
        targetText.text = ScoreTargetController.scoreTarget.ToString();
    }
}
