using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHUDLayer : MonoBehaviour
{
    // HUD Elements
    [HeaderAttribute("HUD Elements")]
    public Text bounceCountText;
    public Text targetText;

    // Animation elements
    [SerializeField]
    private Animator animComp;

    // Alert text spawn point
    [SerializeField]
    private Transform alertTextSpawnPoint;

    [SerializeField]
    private AlertText alertTextPrefab;

    // External references
    PlayerBouncingObject player;


    /*--Getters and Setters--*/

    public Vector3 getAlertTextSpawnPoint()
    {
        return alertTextSpawnPoint.position;
    }

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

    // Show this HUD layer
    public void show()
    {
        animComp.SetBool("isShowing", true);
        animComp.SetBool("isHiding", false);
    }

    // Hide this HUD layer
    public void hide()
    {
        animComp.SetBool("isHiding", true);
        animComp.SetBool("isShowing", false);
    }

    // Update HUD elements
    public void updateHUDElements()
    {
        bounceCountText.text = player.getBounceCount().ToString();
        targetText.text = ScoreTargetController.scoreTarget.ToString();
    }

    // Print alert text
    public void printAlertText(string message)
    {
        AlertText spawnedText = Instantiate(alertTextPrefab, getAlertTextSpawnPoint(),
            Quaternion.identity);

        spawnedText.setTextContent(message);
        spawnedText.gameObject.transform.SetParent(this.transform);
        spawnedText.gameObject.transform.localScale = Vector3.one;
    }

}
