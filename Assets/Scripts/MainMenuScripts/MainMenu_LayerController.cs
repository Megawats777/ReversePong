using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_LayerController : MonoBehaviour
{

	// Layer references
	[Header("Layer References"), SerializeField]
	private MainMenu_WelcomeLayer welcomeScreen;


    // Use this for initialization
    void Start()
    {
		welcomeScreen.gameObject.SetActive(true);
		show_welcomeScreen();
    }

    // Update is called once per frame
    void Update()
    {

    }

	/*--Show and Hide layer methods--*/

	public void show_welcomeScreen()
	{
		welcomeScreen.show();
	}

	public void hide_welcomeScreen()
	{
		welcomeScreen.hide();
	}

	/*--Show and Hide layer methods end--*/
}
