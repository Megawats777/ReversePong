using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHUDLayer : MonoBehaviour
{
	// HUD element variables
	[HeaderAttribute("HUD Elements")]
	public Text titleText;
	public Text scoreGoalText;
	public Text playerBounceResultText;
	public Button restartButton;
	public Button quitButton;


	// Animation elements
	public Animator animComp;

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
			hide();
			SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
		});

		quitButton.onClick.AddListener(delegate{
			hide();
			Application.Quit();
		});

		// Set the content of the title based on whether the player
		// reached the score target
		if (player.bounceCount == ScoreTargetController.scoreTarget)
		{
			titleText.text = "You Win";
		}

		else
		{
			titleText.text = "You Lose";
		}

		scoreGoalText.text = ScoreTargetController.scoreTarget.ToString();
		playerBounceResultText.text = player.bounceCount.ToString();
	
		animComp.SetBool("isShowing", true);
		animComp.SetBool("isHiding", false);
	}

	// Hide this HUD layer
	public void hide()
	{
		restartButton.interactable = false;
		quitButton.interactable = false;
		animComp.SetBool("isShowing", false);
		animComp.SetBool("isHiding", true);
	}
}
