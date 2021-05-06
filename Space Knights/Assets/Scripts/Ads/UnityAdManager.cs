using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour, IUnityAdsListener
{

    private string playStoreID = "4043071";
    private string appStoreID = "4043070";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    private string bannerAd = "banner";

    public bool isTargetPlayStore;
    private bool isTestAd = false;

    //reference to death/reward button
    private playerDeathButtonManager playerDeathButtonMan;
    private GameObject extraLifeButton;
    public GameObject bottomLayerPicture;

    //UI information animator 
    private Animator animator;

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
        Advertisement.Initialize(playStoreID, isTestAd);
        //StartCoroutine(ShowBannerWhenInitialized());

        playerDeathButtonMan = GameObject.FindGameObjectWithTag("UI_Player_Death").GetComponent<playerDeathButtonManager>();
        extraLifeButton = GameObject.FindGameObjectWithTag("UI_Extra_Health");

        animator = GameObject.FindGameObjectWithTag("Attention").GetComponent<Animator>();

       // DontDestroyOnLoad(playerDeathButtonMan);


    }

    private void Update()
    {
        if(!Advertisement.IsReady(rewardedVideoAd))
        {
            extraLifeButton.SetActive(false);
            bottomLayerPicture.SetActive(false);
        }
        else if (Advertisement.IsReady(rewardedVideoAd))
        {
            bottomLayerPicture.SetActive(true);
            extraLifeButton.SetActive(true);
        }
    }

    public bool isRewardedUnityAdAvailable()
    {
        return Advertisement.IsReady(rewardedVideoAd);
    }

    public bool isInterstitialUnityAdAvailable()
    {
        return Advertisement.IsReady(interstitialAd);
    }

    private void InitializeAdvertisement()
    {
        if(isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;
        }
    }

    public void playInterstitialAd()
    {
        if(!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        Advertisement.Show(interstitialAd);

    }

    public void PlayRewardedVideoAd()
    {
        if(!Advertisement.IsReady(rewardedVideoAd))
        {
            return;
        }
        Advertisement.Show(rewardedVideoAd);

    }

    public void PlayBannerAd()
    {
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(bannerAd);
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    //throw user error if it didnt work
    public void OnUnityAdsDidError(string message)
    {

    }

    //to mute the audio of the game
    public void OnUnityAdsDidStart(string placementId)
    {

    }


    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult)
        {
            case ShowResult.Failed:
                if (placementId == rewardedVideoAd)
                {
                    OnSomethingWentWrong();

                }
                if (placementId == interstitialAd)
                {
                    OnSomethingWentWrong();
                }
                break;
            case ShowResult.Skipped:
                if (placementId == rewardedVideoAd)
                {
                    OnSomethingWentWrong();
                }
                if (placementId == interstitialAd)
                {
                    OnSomethingWentWrong();
                }
                break;
            case ShowResult.Finished:
                if(placementId == rewardedVideoAd)
                {
                    playerDeathButtonMan.ExtraLifeAllParametersForPlayer();
                }
                if(placementId == interstitialAd)
                {

                }
                break;

        }
    }
    public void OnAttentionOkButtonPressed()
    {
        animator.Play("Attention_Go_Down");
        playerDeathButtonMan.resetAllParametersForPlayer();
    }

    private IEnumerator OnAttentionOKButtonTimePassed(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        animator.Play("Attention_Go_Down");
    }

    public void OnSomethingWentWrong()
    {
        animator.Play("Attention_Go_Up");
        StartCoroutine(OnAttentionOKButtonTimePassed(2));
    }
}
