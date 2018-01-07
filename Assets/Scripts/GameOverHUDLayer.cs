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
	[SerializeField]
	private Text statusText;

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
		restartButton.onClick.AddListener(delegate{
			StartCoroutine(reloadLevel());	
		});

		quitButton.onClick.AddListener(delegate{
			StartCoroutine(goToMainMenu());
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

	// Reload level
	private IEnumerator reloadLevel()
	{
		statusText.gameObject.SetActive(true);
		statusText.text = "Restarting...";
		
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
}
