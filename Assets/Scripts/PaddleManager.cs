using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleManager : MonoBehaviour
{
    // Reference to the paddles
    [SerializeField]
    private Paddle leftPaddle;
    [SerializeField]
    private Paddle rightPaddle;


    // External references
    private PlayerBouncingObject player;


    // Called before start
    private void Awake()
    {
        player = FindObjectOfType<PlayerBouncingObject>();
    }


    // Use this for initialization
    void Start()
    {
        // Select a random paddle to be the first paddle
        int selectionNum = Random.Range(0, 3);

        if (selectionNum == 0)
        {
            leftPaddle.setIsFirstPaddle(true);
            rightPaddle.setIsFirstPaddle(false);

            player.setMovementDirection(1);
        }

        else
        {
            rightPaddle.setIsFirstPaddle(true);
            leftPaddle.setIsFirstPaddle(false);

            player.setMovementDirection(-1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
