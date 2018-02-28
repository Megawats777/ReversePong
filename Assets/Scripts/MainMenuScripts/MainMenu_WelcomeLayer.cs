using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu_WelcomeLayer : MonoBehaviour
{
    // Element references
    [Header("Element References"), SerializeField]
    private GameObject contentRoot;
    [SerializeField]
    private Text loadingText;
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button helpButton;
    [SerializeField]
    private Button creditsButton;
    [SerializeField]
    private Button quitButton;
    [SerializeField]
    private Animator fadeImage;

    // External references
    private MainMenu_LayerController mainMenu_LayerController;

    // Called before start
    void Awake()
    {
        mainMenu_LayerController = FindObjectOfType<MainMenu_LayerController>();

        // Assign functions to buttons
        playButton.onClick.AddListener(delegate
        {
            StartCoroutine(startGame());
        });

        helpButton.onClick.AddListener(delegate
        {
            mainMenu_LayerController.show_helpScreen();
            mainMenu_LayerController.hide_welcomeScreen();
        });

        quitButton.onClick.AddListener(delegate
        {
            Application.Quit();
        });
    }

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
        contentRoot.SetActive(true);
        loadingText.gameObject.SetActive(false);
    }

    // Hide the layer
    public void hide()
    {
        contentRoot.SetActive(false);
    }

    // Start the game
    private IEnumerator startGame()
    {
        float delay = 2.0f;

        hide();
        PlayerStatsContainer.resetValues();
        StageSystemManager.resetValues();
        ScoreTargetController.resetValues();

        loadingText.gameObject.SetActive(true);



        yield return new WaitForSeconds(delay);

        fadeImage.SetBool("isShowing", true);

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadSceneAsync("Scene_GameArea_Sanctuary");
    }
}
