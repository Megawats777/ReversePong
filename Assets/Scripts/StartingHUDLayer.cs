using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingHUDLayer : MonoBehaviour
{
	// HUD Elements
	[HeaderAttribute("HUD Elements")]
	public Text statusText;

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

	}

	// Hide this layer
	public IEnumerator hide()
	{
		int fontSizeIncreaseFactor = 20;

		statusText.text = "Start!";
		statusText.fontSize += fontSizeIncreaseFactor;
		yield return new WaitForSeconds(1.0f);
		statusText.enabled = false;
	}
}
