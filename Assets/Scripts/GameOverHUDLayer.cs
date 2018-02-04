using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class GameOverHUDLayer : MonoBehaviour
{
	// HUD element variables
	[HeaderAttribute("HUD Elements")]
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text scoreGoalText;
    [SerializeField]
    private Text playerBounceResultText;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button quitButton;
	[SerializeField]
	private Text statusText;
    [SerializeField]
    private Text tooltipText;

	// Animation elements
	public Animator animComp;
	public Animator fadeImageAnimComp;

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
        tooltipText.text = string.Empty;

		continueButton.onClick.AddListener(delegate{
			StartCoroutine(reloadLevel());	
		});

		quitButton.onClick.AddListener(delegate{
			StartCoroutine(goToMainMenu());
		});

		// Set the content of the title based on whether the player
		// reached the score target
		if (player.getBounceCount() >= ScoreTargetController.scoreTarget)
		{
			titleText.text = "You Win";
		}

		else
		{
			titleText.text = "You Lose";
		}

		scoreGoalText.text = ScoreTargetController.scoreTarget.ToString();
		playerBounceResultText.text = player.getBounceCount().ToString();
	
		animComp.SetBool("isShowing", true);
		animComp.SetBool("isHiding", false);
	}

	// Hide this HUD layer
	public void hide()
	{
		continueButton.interactable = false;
		quitButton.interactable = false;
		animComp.SetBool("isShowing", false);
		animComp.SetBool("isHiding", true);
	}

	// Reload level
	private IEnumerator reloadLevel()
	{
		statusText.gameObject.SetActive(true);
		statusText.text = "Loading...";
		
		hide();
		fadeImageAnimComp.SetBool("isHiding", false);

		yield return new WaitForSeconds(3.0f);

		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
	}

	// Go to the main menu
	private IEnumerator goToMainMenu()
	{
		statusText.gameObject.SetActive(true);
		statusText.text = "Loading...";

		hide();
		fadeImageAnimComp.SetBool("isHiding", false);

		yield return new WaitForSeconds(3.0f);
	
		SceneManager.LoadSceneAsync("MainMenu");
	}

    // Set the tooltip text
    public void setTooltipText(string content)
    {
        tooltipText.text = content;
    }
}
