using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public float playerDamage;
    public bool firstTimeEnemyHit;

    private GPGSAchievements achievements;
    private GPGSLeaderboard leaderboard;


    private void Awake()
    {
        firstTimeEnemyHit = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        achievements = GameObject.FindGameObjectWithTag("Achievement_Manager").GetComponent<GPGSAchievements>();
        leaderboard = GameObject.FindGameObjectWithTag("LeaderBoard").GetComponent<GPGSLeaderboard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            float totalDamage = (playerDamage / 2);
            collision.gameObject.GetComponent<EnemyManager>().takeDamageFromPlayer(totalDamage);
            DestroyTheBullet();

            if(firstTimeEnemyHit)
            {
                achievements.HitFirstEnemyAchievement();
                firstTimeEnemyHit = false;
            }

            leaderboard.incrementTotalDamage((int)totalDamage);
        }
    }

    public void DestroyTheBullet()
    {
        Destroy(gameObject);
    }

}
