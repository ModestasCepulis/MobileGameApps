using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPGSAchievements : MonoBehaviour
{

    public void OpenAchievementPanel()
    {
        Social.ShowAchievementsUI();
    }

    public void UpdateIncrementalDamageDealt()
    {
        //for incrementing stuff like damage
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.leaderboard_highest_damage_dealt_to_enemies, 1, null);
    }

    public void HitFirstEnemyAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_attack_an_enemy_ship_for_the_first_time, 100f, success =>
        {
            if (success) Debug.Log("The achievement was reached/gotten");
        });
    }

}
