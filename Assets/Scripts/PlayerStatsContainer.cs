using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStatsContainer
{
    // Variables
    private static int wins = 0;


    /*--Getters and Setters--*/

    public static int getWins()
    {
        return wins;
    }

    public static void setWins(int newWins)
    {
        wins = Mathf.Clamp(newWins, 0, 99);
    }

}
