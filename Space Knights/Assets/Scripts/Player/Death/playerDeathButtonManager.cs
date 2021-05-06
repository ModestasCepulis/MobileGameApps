using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerDeathButtonManager : MonoBehaviour
{

     private GameObject playerObject;
     private PlayerHealthManager playerHealth;

     private GameObject mainCamera;
     private GameObject UIDeathObject;
     private Animator UIAnimator;
    private GameObject PauseMenuButton;

    private Animator playerAnimator;

    private overallAdManager Ad_Manager;

    public string animationName;

    private float intersAdCounter = 0;

    private void Awake()
    {

    }

    private void Start()
    {
        Ad_Manager = GameObject.FindGameObjectWithTag("Ad_Manager").GetComponent<overallAdManager>();
        findReferencesAgain();

/*        DontDestroyOnLoad(playerObject);
        DontDestroyOnLoad(playerHealth);
        DontDestroyOnLoad(UIDeathObject);
        DontDestroyOnLoad(UIAnimator);
        DontDestroyOnLoad(Ad_Manager);*/
    }

    private void Update()
    {

        if (intersAdCounter > 2)
        {
            intersAdCounter = 0;
        }

    }

    public void onExtraLifeButtonPressed()
    {
        Ad_Manager.playRandomRewardedAd();
    }

    public void OnRestartButtonPressed()
    {
        intersAdCounter++;
        print("interst time: " + intersAdCounter);
        if (intersAdCounter == 1)
        {
            Ad_Manager.playRandomInterstetialAd();
        }

        resetAllParametersForPlayer();



        // SceneManager.LoadScene(2);
    }

    public void findReferencesAgain()
    {


        PauseMenuButton = GameObject.FindGameObjectWithTag("UI_PauseMenu_Button");
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = playerObject.GetComponent<Animator>();

        playerHealth = playerObject.GetComponent<PlayerHealthManager>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        UIDeathObject = GameObject.FindGameObjectWithTag("UI_Player_Death");
        UIAnimator = UIDeathObject.GetComponent<Animator>();

    }
    public void resetAllParametersForPlayer()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<EnemyManager>().DestroyTheObject();
        }

        playerHealth.resetPlayerHealth();
        //resetAllParametersForPlayer();
        //UIAnimator.SetBool("isDead", false);
        UIAnimator.Play("UI_Player_Death_Idle");
        //playerAnimator.SetBool("isDead", false);
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        playerObject.GetComponent<Collider2D>().enabled = true;
        playerObject.transform.position = new Vector3(mainCamera.transform.position.x - 6.5f, 0, 0);

        PauseMenuButton.GetComponent<Image>().enabled = true;
        
        //UIDeathObject.SetActive(false);
        playerHealth.setUIControls(true);
        playerHealth.setHealthControls(true);


        // playerObject.GetComponent<simpleMovement>().enabled = true;
        // 

        //  playerObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void ExtraLifeAllParametersForPlayer()
    {

        playerHealth.resetPlayerHealth();
        //resetAllParametersForPlayer();
        //UIAnimator.SetBool("isDead", false);
        UIAnimator.Play("UI_Player_Death_Idle");
        //playerAnimator.SetBool("isDead", false);
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        playerObject.GetComponent<Collider2D>().enabled = true;
        playerObject.transform.position = new Vector3(mainCamera.transform.position.x - 6.5f, 0, 0);

        PauseMenuButton.GetComponent<Image>().enabled = true;

        //UIDeathObject.SetActive(false);
        playerHealth.setUIControls(true);
        playerHealth.setHealthControls(true);


        // playerObject.GetComponent<simpleMovement>().enabled = true;
        // 

        //  playerObject.GetComponent<SpriteRenderer>().enabled = true;
    }

}
