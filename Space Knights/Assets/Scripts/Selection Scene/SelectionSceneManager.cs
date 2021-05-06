using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionSceneManager : MonoBehaviour
{
    private GPGSAchievements achievements_manager;
    private GPGSLeaderboard leaderboard_manager;
    private Animator animator;

    public GameObject Attention_UI_Object;
    public AttentionUIManager Attention_UI_Manager;

    public GameHandler LoadSaveHandler;


    // Start is called before the first frame update
    void Start()
    {
        achievements_manager = GameObject.FindGameObjectWithTag("Achievement_Manager").GetComponent<GPGSAchievements>();
        leaderboard_manager = GameObject.FindGameObjectWithTag("Leaderboards_Manager").GetComponent<GPGSLeaderboard>();
        animator = GameObject.FindGameObjectWithTag("BlackFadeOut").GetComponent<Animator>();

        Attention_UI_Object = GameObject.FindGameObjectWithTag("Attention");
        Attention_UI_Manager = Attention_UI_Object.GetComponent<AttentionUIManager>();

        LoadSaveHandler = GameObject.FindGameObjectWithTag("LoadSaveHandler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onNewGameButtonClicked()
    {
        string mobilePath = Application.persistentDataPath;

        if (File.Exists((mobilePath + "/" + "saveData" + ".json")))
        {
            GameHandler.SaveObject saveObject = LoadSaveHandler.LoadGameFile("saveData");

            if (saveObject != null)
            {

                Attention_UI_Manager.fileAlreadyExistsAttention();
                //
            }
        }
        else
        {
                animator.SetBool("fadeOut", true);
                Invoke("LoadScene", 1.5f);
        }

    }

    public void LoadScene()
    {
        SceneManager.LoadScene("IconSelectionScene");

    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void onContinueButtonClicked()
    {
        string mobilePath = Application.persistentDataPath;

        if(File.Exists((mobilePath + "/" + "saveData" + ".json")))
        {
            GameHandler.SaveObject saveObject = LoadSaveHandler.LoadGameFile("saveData");

            if (saveObject != null)
            {
                ShipSelectionToSpawn.shipName = saveObject.shipName;
                ShipSelectionToSpawn.shipHealth = saveObject.health;
                ShipSelectionToSpawn.shipPosition = saveObject.playerPosition;
                ShipSelectionToSpawn.shipCanvas = saveObject.canvasName;

                animator.SetBool("fadeOut", true);
                Invoke("LoadMainScene", 1.5f);
            }
        }
        else
        {
            Attention_UI_Manager.fileDoesNotExistAttention();
        }

    }

    public void onAchievementsButtonClicked()
    {
        achievements_manager.OpenAchievementPanel();
    }

    public void onLeaderboardsButtonClicked()
    {
        leaderboard_manager.OpenLeaderboardPanel();
    }

    public void onShopButtonClicked()
    {
        shopMenuUIManager.instance.onShopButtonPressed();
    }

    public void onExitButtonClicked()
    {
        //check if it has been saved in 5 mins first
        Debug.Log("Program shoulve quit");
        Application.Quit();
    }
}
