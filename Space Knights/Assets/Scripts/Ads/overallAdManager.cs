using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overallAdManager : MonoBehaviour
{
    private GameObject adManagerObject;
    private adMobManager googleAdManager;
    private UnityAdManager unityAdManager;

    private playerDeathButtonManager playerDeathButtonMan;

    // Start is called before the first frame update
    void Start()
    {
        adManagerObject = GameObject.FindGameObjectWithTag("Ad_Manager");
        googleAdManager = adManagerObject.GetComponent<adMobManager>();
        unityAdManager = adManagerObject.GetComponent<UnityAdManager>();
        playerDeathButtonMan = GameObject.FindGameObjectWithTag("UI_Player_Death").GetComponent<playerDeathButtonManager>();

        float randomNumber = Random.Range(1, 3);


        if(IAPManager.returnShouldAdsBeEnabled())
        {
            if (randomNumber == 1)
            {
                googleAdManager.RequestBanner();
            }
            if (randomNumber == 2)
            {
                unityAdManager.PlayBannerAd();
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playRandomRewardedAd()
    {
        if (IAPManager.returnShouldAdsBeEnabled())
        {

            float randomNumber = Random.Range(1, 3);
            if (randomNumber == 1)
            {
                googleAdManager.RequestRewardBasedVideo();
                //unityAdManager.PlayRewardedVideoAd();
            }
            if (randomNumber == 2)
            {
                unityAdManager.PlayRewardedVideoAd();
            }
        }
        else
        {
            playerDeathButtonMan.ExtraLifeAllParametersForPlayer();
        }


    }

    public void playRandomInterstetialAd()
    {
        if (IAPManager.returnShouldAdsBeEnabled())
        {
            float randomNumber = Random.Range(1, 3);
            if (randomNumber == 1)
            {
                googleAdManager.RequestInterstitial();
            }
            if (randomNumber == 2)
            {
                unityAdManager.playInterstitialAd();
            }
        }
        else
        {
            playerDeathButtonMan.resetAllParametersForPlayer();
        }
    }
}
