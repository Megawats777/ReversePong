using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHUDLayer : MonoBehaviour
{
	// Text variables
	public Text bounceResultText;
	public Button restartButton;
	public Button quitButton;

	// External references
	private BouncingObject player;


	void Awake()
	{
		player = FindObjectOfType<BouncingObject>();
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
			SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
		});

		quitButton.onClick.AddListener(delegate{
			Application.Quit();
		});


		bounceResultText.text = "You bounced " + player.bounceCount + " times";
	}
}
