using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Global ui elements
    [HeaderAttribute("Global UI Elements")]
    public Text currentScreenIndicator;
    public Text loadingText;
    public Image background;
    public Animator fadeImageAnimator;

    // HUD layers
    [HeaderAttribute("HUD Layers")]
    public GameObject welcomeScreen;
    public GameObject helpScreen;
    public GameObject creditsScreen;


    // Welcome screen elements
    [HeaderAttribute("Welcome Screen Elements")]
    public Button playButton;
    public Button helpButton;
    public Button creditsButton;
    public Button quitButton;

    // Use this for initialization
    void Start()
    {
		welcomeScreen_assignButtonFunctions();
        loadingText.gameObject.SetActive(false);
        welcomeScreen_show();
    }

    // Update is called once per frame
    void Update()
    {

    }

	// Start the game
	private IEnumerator startGame()
	{
		float startDelay = 2.0f;

		welcomeScreen_hide();
		currentScreenIndicator.gameObject.SetActive(false);
		loadingText.gameObject.SetActive(true);
        background.enabled = false;
        fadeImageAnimator.SetBool("isShowing", true);

		yield return new WaitForSeconds(startDelay);
	
		SceneManager.LoadSceneAsync("GameArea");
	}


	// Welcome screen functions
	private void welcomeScreen_assignButtonFunctions()
	{
		playButton.onClick.AddListener(delegate{
			StartCoroutine(startGame());
		});

        quitButton.onClick.AddListener(delegate{
            Application.Quit();
        });
	}


    // UI visibiliy functions

    void welcomeScreen_show()
    {
        string screenMessage = "Welcome";

        // Set the text of the screen indicator object
        // Set the layer to be active
        currentScreenIndicator.text = screenMessage;
        welcomeScreen.SetActive(true);
    }

    void welcomeScreen_hide()
    {
        welcomeScreen.SetActive(false);
    }



    void helpScreen_show()
    {
        string screenMessage = "Welcome";

        // Set the text of the screen indicator object
        // Set the layer to be active
        currentScreenIndicator.text = screenMessage;
        helpScreen.SetActive(true);
    }

    void helpScreen_hide()
    {
        helpScreen.SetActive(false);
    }

    

    void creditsScreen_show()
    {
        string screenMessage = "Welcome";

        // Set the text of the screen indicator object
        // Set the layer to be active
        currentScreenIndicator.text = screenMessage;
        creditsScreen.SetActive(true);
    }

    void creditsScreen_hide()
    {
        creditsScreen.SetActive(false);
    }
}
