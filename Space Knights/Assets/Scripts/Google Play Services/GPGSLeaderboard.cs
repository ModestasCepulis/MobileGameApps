using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPGSLeaderboard : MonoBehaviour
{

    private static int totalDamagedone = 0;

    public void OpenLeaderboardPanel()
    {
        Social.ShowLeaderboardUI();
    }


    public void updateLeaderboardScore()
    {

        if(totalDamagedone == 0)
        {
            return;
        }

        Social.ReportScore(totalDamagedone, GPGSIds.leaderboard_highest_damage_dealt_to_enemies, success =>
        {
            if(success)
            {
                totalDamagedone = 0;
            }
        });
    }

    void Update()
    {
        //print("total damage done: " + totalDamagedone);
    }

    public void incrementTotalDamage(int value)
    {
        totalDamagedone += value;
    }

}
