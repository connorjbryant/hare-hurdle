using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public Text scoreDisplay;
    public Text livesDisplay;
    public GameObject livesDisplayText;
    public GameObject hat;
    public GameObject flipButton;
    public GameObject floatButton;
    public GameObject plane;

    /*public GameObject achievementOne1;
    public GameObject achievementTwo2;
    public GameObject achievementThree3;
    public GameObject achievementFour4;
    public GameObject achievementFive5;
    public GameObject achievementSix6;
    public GameObject achievementSeven7;
    public GameObject achievementEight8;
    public GameObject achievementNine9;
    public GameObject achievementTen10;*/

    public Text highScore;
    //string App_ID = "ca-app-pub-9500067308309897~4743457652";
    //string Interstitial_AD = "ca-app-pub-3940256099942544/1033173712";

    private InterstitialAd interstitial;
    //public GameObject myPrefab;
    //public GameObject achievement;

    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        hat.SetActive(PlayerPrefs.GetInt("hat", 0) == 1);
        flipButton.SetActive(PlayerPrefs.GetInt("flipButton", 0) == 1);
        floatButton.SetActive(PlayerPrefs.GetInt("floatButton", 0) == 1);
        plane.SetActive(PlayerPrefs.GetInt("plane", 0) == 1);

        /*floatButton.SetActive(PlayerPrefs.GetInt("achievementOne1", 0) == 1);
        floatButton.SetActive(PlayerPrefs.GetInt("achievementTwo2", 0) == 1);
        floatButton.SetActive(PlayerPrefs.GetInt("achievementThree3", 0) == 1);
        floatButton.SetActive(PlayerPrefs.GetInt("achievementFour4", 0) == 1);
        floatButton.SetActive(PlayerPrefs.GetInt("achievementFive5", 0) == 1);
        floatButton.SetActive(PlayerPrefs.GetInt("achievementSix6", 0) == 1);
        floatButton.SetActive(PlayerPrefs.GetInt("achievementSeven7", 0) == 1);
        floatButton.SetActive(PlayerPrefs.GetInt("achievementEight8", 0) == 1);
        floatButton.SetActive(PlayerPrefs.GetInt("achievementNine9", 0) == 1);
        floatButton.SetActive(PlayerPrefs.GetInt("achievementTen10", 0) == 1);*/
        //MobileAds.Initialize(App_ID);
        //DontDestroyOnLoad(hat.gameObject);
    }

    private void Update()
    {
        scoreDisplay.text = score.ToString();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
            //GameServices.Instance.SubmitScore(PlayerPrefs.GetInt("HighScore"), LeaderboardNames.HighScoreLeaderboard);
        }
        if (RabbitJump.instance.health > 1)
        {
            livesDisplay.text = RabbitJump.instance.health.ToString();
            livesDisplayText.SetActive(true);
        }

        if(PlayerPrefs.GetInt("HighScore") >= 10)
        {
            //GameServices.Instance.SubmitAchievement(AchievementNames.Terrifictenpoints);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 20)
        {
            //GameServices.Instance.SubmitAchievement(AchievementNames.Tremendoustwentypoints);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 30)
        {
            //GameServices.Instance.SubmitAchievement(AchievementNames.Thirtypointsaward);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 40)
        {
            //GameServices.Instance.SubmitAchievement(AchievementNames.Fantasticfortypoints);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 50)
        {
            //GameServices.Instance.SubmitAchievement(AchievementNames.Fiftypoints);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 60)
        {
            //GameServices.Instance.SubmitAchievement(AchievementNames.Superbsixtypoints);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 70)
        {
            //GameServices.Instance.SubmitAchievement(AchievementNames.Sickseventypoints);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 80)
        {
            //GameServices.Instance.SubmitAchievement(AchievementNames.Eliteeightypoints);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 90)
        {
            //GameServices.Instance.SubmitAchievement(AchievementNames.Niceninetypoints);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 100)
        {
            //GameServices.Instance.SubmitAchievement(AchievementNames.ONEHUNDREDPOINTS);
        }

        else {
            livesDisplay.text = RabbitJump.instance.health.ToString();
            livesDisplayText.SetActive(true);
            /*if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }*/
        }


    }

    //for events and delegates
    /*public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
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

    public void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(Interstitial_AD);

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

    /*public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle") && RabbitJump.instance.health >= 1)
        {
            //increase score
            score++;
            Debug.Log(score);
        }
        
        else
        {
            score = score + 0;
            /*if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }*/
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
        //scoreDisplay.text = "0";
        //highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }


    public void Hat()
    {
        if (PlayerPrefs.GetInt("HighScore") >= 10)
        {
            hat.SetActive(true);
            //SaveSystem.GetBool();
            PlayerPrefs.SetInt("hat", 1);

        }
    }

    public void hatDisable()
    {
        if (PlayerPrefs.GetInt("HighScore") >= 10)
        {
            hat.SetActive(false);
            //SaveSystem.GetBool();
            PlayerPrefs.SetInt("hat", 0);
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        }
    }

    public void flipButton2()
    {
        if (PlayerPrefs.GetInt("HighScore") >= 20)
        {
            flipButton.SetActive(true);
            //SaveSystem.GetBool();
            PlayerPrefs.SetInt("flipButton", 1);

        }
    }

    public void flipButton2Disable()
    {
        if (PlayerPrefs.GetInt("HighScore") >= 20)
        {
            flipButton.SetActive(false);
            //SaveSystem.GetBool();
            PlayerPrefs.SetInt("flipButton", 0);
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        }
    }

    public void floatButton2()
    {
        if (PlayerPrefs.GetInt("HighScore") >= 30)
        {
            floatButton.SetActive(true);
            //SaveSystem.GetBool();
            PlayerPrefs.SetInt("floatButton", 1);

        }
    }

    public void floatButton2Disable()
    {
        if (PlayerPrefs.GetInt("HighScore") >= 30)
        {
            floatButton.SetActive(false);
            //SaveSystem.GetBool();
            PlayerPrefs.SetInt("floatButton", 0);
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        }
    }

    public void planeUnlock()
    {
        if (PlayerPrefs.GetInt("HighScore") >= 40)
        {
            plane.SetActive(true);
            //SaveSystem.GetBool();
            PlayerPrefs.SetInt("plane", 1);

        }
    }

    public void planeUnlockDisable()
    {
        if (PlayerPrefs.GetInt("HighScore") >= 40)
        {
            plane.SetActive(false);
            //SaveSystem.GetBool();
            PlayerPrefs.SetInt("plane", 0);
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        }
    }

    /*public void showAchievements()
    {
        if (PlayerPrefs.GetInt("HighScore") >= 10)
        {
            achievementOne1.SetActive(true);
            PlayerPrefs.SetInt("achievementOne1", 1);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 20)
        {
            achievementTwo2.SetActive(true);
            PlayerPrefs.SetInt("achievementTwo2", 1);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 30)
        {
            achievementThree3.SetActive(true);
            PlayerPrefs.SetInt("achievementThree3", 1);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 40)
        {
            achievementFour4.SetActive(true);
            PlayerPrefs.SetInt("achievementFour4", 1);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 50)
        {
            achievementFive5.SetActive(true);
            PlayerPrefs.SetInt("achievementFive5", 1);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 60)
        {
            achievementSix6.SetActive(true);
            PlayerPrefs.SetInt("achievementSix6", 1);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 70)
        {
            achievementSeven7.SetActive(true);
            PlayerPrefs.SetInt("achievementSeven7", 1);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 80)
        {
            achievementEight8.SetActive(true);
            PlayerPrefs.SetInt("achievementEight8", 1);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 90)
        {
            achievementNine9.SetActive(true);
            PlayerPrefs.SetInt("achievementNine9", 1);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 100)
        {
            achievementTen10.SetActive(true);
            PlayerPrefs.SetInt("achievementTen10", 1);
        }
    }*/
}
