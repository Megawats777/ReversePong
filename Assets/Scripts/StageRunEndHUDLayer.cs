using System.Collections;
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
    [SerializeField]
    private Text toolTipText;

    // Component references
    [Header("Component References"), SerializeField]
    private Animator animComp;


    // External refernces
    [Header("External References"), SerializeField]
    private Animator fadeImage;
    [SerializeField]
    private Text statusText;

    private MusicPlayer musicPlayer;

    // Called before start
    private void Awake()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
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
        Cursor.visible = true;

        toolTipText.text = string.Empty;
        animComp.SetBool("isShowing", true);

        // Add on click listener
        quitButton.onClick.AddListener(delegate
        {
            musicPlayer.fadeOut();
            StartCoroutine(transitionToMainMenu());
        });

        winsText.text = PlayerStatsContainer.getWins().ToString() + " / " + StageSystemManager.getFinalStage().ToString();
        rankText.text = StageSystemManager.getPlayerRank(PlayerStatsContainer.getWins());
    }

    // Hide this layer
    public void hide()
    {
        Cursor.visible = false;
        animComp.SetBool("isShowing", false);
    }


    // Transition to main menu
    private IEnumerator transitionToMainMenu()
    {
        float delay = 3.0f;

        quitButton.interactable = false;
        hide();

        yield return new WaitForSeconds(1.1f);

        fadeImage.SetBool("isHiding", false);

        statusText.gameObject.SetActive(true);
        statusText.text = "Loading...";

        yield return new WaitForSeconds(delay);

        SceneManager.LoadSceneAsync("MainMenu");
    }
}
