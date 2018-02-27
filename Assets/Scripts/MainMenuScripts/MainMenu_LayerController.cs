using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_LayerController : MonoBehaviour
{

	// Layer references
	[Header("Layer References"), SerializeField]
	private MainMenu_WelcomeLayer welcomeScreen;
	[SerializeField]
	private MainMenu_HelpScreenLayer helpScreen;

    // Use this for initialization
    void Start()
    {
		welcomeScreen.gameObject.SetActive(true);
		helpScreen.gameObject.SetActive(false);
		show_welcomeScreen();
    }

    // Update is called once per frame
    void Update()
    {

    }

	/*--Show and Hide layer methods--*/

	public void show_welcomeScreen()
	{
		welcomeScreen.gameObject.SetActive(true);
		welcomeScreen.show();
	}

	public void hide_welcomeScreen()
	{
		welcomeScreen.hide();
		welcomeScreen.gameObject.SetActive(false);
	}


	public void show_helpScreen()
	{
		helpScreen.gameObject.SetActive(true);
		helpScreen.show();
	}

	public void hide_helpScreen()
	{
		helpScreen.hide();
		helpScreen.gameObject.SetActive(false);
	}

	/*--Show and Hide layer methods end--*/
}
