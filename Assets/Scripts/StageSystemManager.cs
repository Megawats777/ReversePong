using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StageSystemManager
{
    // Variables
    private static int currentStage = 1;
    private static int finalStage = 5;

    /*--Getters and Setters--*/

    public static int getCurrentStage()
    {
        return currentStage;
    }

    public static void setCurrentStage(int newStage)
    {
        currentStage = Mathf.Clamp(newStage, 0, 99);
    }

    public static int getFinalStage()
    {
        return finalStage;
    }


    // Is on the final stage
    public static bool isOnFinalStage()
    {
        return currentStage == finalStage;
    }
    
    // Get player rank
    public static string getPlayerRank(int wins)
    {
        // Based on the number of wins
        // Return a certain grade
        switch(wins)
        {
            case 0:
                return "Absolute Failure";
                break;

            case 1:
                return "D";
                break;

            case 2:
                return "C";
                break;

            case 3:
                return "B";
                break;

            case 4:
                return "A";
                break;

            case 5:
                return "S";
                break;

            default:
                return "Absolute Failure";
                break;
        }

    }
}
