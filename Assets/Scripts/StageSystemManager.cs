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


    // Is on the final stage
    public static bool isOnFinalStage()
    {
        return currentStage == finalStage;
    }
}
