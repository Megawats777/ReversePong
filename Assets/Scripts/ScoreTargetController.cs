using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTargetController : MonoBehaviour
{
    // Score target variables
	private static int minScoreTarget = 12;
	private static int maxScoreTarget = 15;
	private static int scoreTarget;

    private static int scoreIncreaseModifier = 9;



    /*--Getters and Setters--*/

    public static int getScoreTarget()
    {
        return scoreTarget;
    }

    public static void setScoreTarget(int newScoreTarget)
    {
        scoreTarget = newScoreTarget;
    }

    /*--Getters and Setters end--*/

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	// Generate score target
	public static void generateScoreTarget()
	{
		scoreTarget = Random.Range(minScoreTarget, maxScoreTarget);

        // Add to the score target based on the current round
        scoreTarget += scoreIncreaseModifier * (StageSystemManager.getCurrentStage() - 1);
    }
}
