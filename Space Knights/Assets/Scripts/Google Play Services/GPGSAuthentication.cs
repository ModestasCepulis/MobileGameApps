using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GPGSAuthentication : MonoBehaviour
{

    public static PlayGamesPlatform platform;
    public GameObject SignInObject;

    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(SignInObject);
    }
    void Start()
    {
        if(platform == null)
        {

            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build(); //enabledsavesGames.build for cloud saves
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if(success)
            {
                Debug.Log("Logged in successfully");
            }
            else
            {
                Debug.Log("Failed to log in");
            }
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
