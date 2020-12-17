using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdMobScript : MonoBehaviour
{
    string App_ID = "ca-app-pub-9500067308309897~4743457652";
    string Interstitial_AD_ID = "ca-app-pub-9500067308309897/5408622317";

    private InterstitialAd interstitial;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        MobileAds.Initialize(App_ID);
        RequestInterstitial();
    }

    private void Update()
    {
        if(RabbitJump.instance.health <= 0)
        {
            ShowInterstitialAd();
        }
        else
        {
            Debug.Log("not working");
        }
    }

    public void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(Interstitial_AD_ID);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);


    }

    public void ShowInterstitialAd()
    {

        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();


        }
    }

    // FOR EVENTS AND DELEGATES FOR ADS
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("asdfasdf");



        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();


        }



    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("fail");
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }






}
