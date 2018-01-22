using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertText : MonoBehaviour
{
	private float movementSpeed = 25.0f;

	// Component references
	private Text textComp;

	// Called before start
	void Awake()
	{
		textComp = GetComponent<Text>();
	}

    // Use this for initialization
    void Start()
    {
        // Increase the speed of other spawned alert text objects
        foreach (AlertText currentAlertText in FindObjectsOfType<AlertText>())
        {
            if (currentAlertText)
            {
                if (currentAlertText != this)
                {
                    currentAlertText.movementSpeed += 10.0f;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
    }

	// Set the content of the text object
	public void setTextContent(string content)
	{
		textComp.text = content;
	}
}
