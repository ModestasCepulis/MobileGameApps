using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class adMobManager : MonoBehaviour
{
    string app_Id = "ca-app-pub-2082355473024309~2767756610";
    string banner_ad_Id = "ca-app-pub-2082355473024309/5926208310";
    string interstitial_ad_Id = "ca-app-pub-2082355473024309/3491616664";
    string rewarded_ad_Id = "ca-app-pub-2082355473024309/1981288554";

    private BannerView bannerView;
    private InterstitialAd InterstitialAd;
    private RewardedAd rewardBasedVideo;

    //reference to death/reward button
    private playerDeathButtonManager playerDeathButtonMan;
    private GameObject extraLifeButton;
    public GameObject bottomLayerPicture;

    //UI information animator 
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(app_Id);

        playerDeathButtonMan = GameObject.FindGameObjectWithTag("UI_Player_Death").GetComponent<playerDeathButtonManager>();
        extraLifeButton = GameObject.FindGameObjectWithTag("UI_Extra_Health");
        animator = GameObject.FindGameObjectWithTag("Attention").GetComponent<Animator>();
    }

    public void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(banner_ad_Id, AdSize.Banner, AdPosition.Bottom);

        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);

    }



    //interstetial ad handles:
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("Ad has been loaded");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        OnSomethingWentWrong();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("Ad Has been opened");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("Ad Has been closed");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        OnSomethingWentWrong();
    }

    public void RequestInterstitial()
    {

        // Initialize an InterstitialAd.
        this.InterstitialAd = new InterstitialAd(interstitial_ad_Id);

        // Called when an ad request has successfully loaded.
        this.InterstitialAd.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.InterstitialAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.InterstitialAd.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.InterstitialAd.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.InterstitialAd.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        this.InterstitialAd.LoadAd(request);

        if (this.InterstitialAd.IsLoaded())
        {
            this.InterstitialAd.Show();
        }

    }

    public void RequestRewardBasedVideo()
    {
        this.rewardBasedVideo = new RewardedAd(rewarded_ad_Id);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardBasedVideo.LoadAd(request);

        // Called when an ad request has successfully loaded.
        this.rewardBasedVideo.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardBasedVideo.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardBasedVideo.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardBasedVideo.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardBasedVideo.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardBasedVideo.OnAdClosed += HandleRewardedAdClosed;

        if (this.rewardBasedVideo.IsLoaded())
        {
            this.rewardBasedVideo.Show();
        }
    }

    //rewarded ad handles
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Rewarded ad loaded");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        OnSomethingWentWrong();
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        Debug.Log("Rewarded ad opened");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        OnSomethingWentWrong();
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        Debug.Log("Rewarded ad closed");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;

        print("user should be rewarded");

        playerDeathButtonMan.ExtraLifeAllParametersForPlayer();
    }


    // Update is called once per frame
    void Update()
    {
/*        if(!rewardBasedVideo.IsLoaded())
        {
            extraLifeButton.SetActive(false);
            bottomLayerPicture.SetActive(false);
        }
        else if(rewardBasedVideo.IsLoaded())
        {
            extraLifeButton.SetActive(true);
            bottomLayerPicture.SetActive(true);
        }*/
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
