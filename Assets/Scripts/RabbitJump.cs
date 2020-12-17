using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using GoogleMobileAds.Api;

public class RabbitJump : MonoBehaviour
{
    public static RabbitJump instance;
    //public GameObject achievementRabbit;

    public Animator animator;
    //private Shake shake;

    public KeyCode jump;

    private float jumpHeight = 325f;
    private Rigidbody2D rigidBody;
    bool isGrounded = true;

    public int health = 1;

    public GameObject GameOverMenu;
    public GameObject JumpSound;

    //public float fullSpeed = 1;
    //public float slowSpeed = 0.3f;

    public float slowdownFactor;
    public float slowdownTime;

    //string App_ID = "ca-app-pub-9500067308309897~4743457652";
    //string Interstitial_AD = "ca-app-pub-3940256099942544/1033173712";
    //private InterstitialAd interstitial;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rigidBody = GetComponent<Rigidbody2D>();
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        //MobileAds.Initialize(App_ID);
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

    public void ShowInterstitialAd()
    {

        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();


        }
    }*/

    public void ScaleToTarget(Vector3 targetScale, float duration)
    {
        StartCoroutine(ScaleToTargetCoroutine(targetScale, duration));
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(jump) && isGrounded)
        {
            Instantiate(JumpSound, transform.position, Quaternion.identity);
            animator.SetTrigger("rabbitJump");
            rigidBody.AddForce(new Vector2(0, jumpHeight));
            //transform.Translate(Vector3.forward * Time.deltaTime);
        }

       if(health <= 0)
        {
            //shake.CamShake();
            Destroy(this.gameObject);
            //ScoreManager.instance.score = 
            GameOverMenu.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //ShowInterstitialAd();
        }
       /*if(ScoreManager.instance.score == 1)
        {
            //Instantiate(achievementRabbit, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
            achievementRabbit.SetActive(true);
        }*/
    }

    


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
        /*if (collision.gameObject.CompareTag("powerup4"))
        {
            Destroy(collision.gameObject);
            health = health + 1;
            //StartCoroutine(FloatFunction());
            GetComponent<SpriteRenderer>().color = Color.red;
            //StartCoroutine(ResetPower());
        }*/
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "powerup")
        {
            Destroy(collision.gameObject);
            jumpHeight = 450f;
            GetComponent<SpriteRenderer>().color = Color.cyan;
            StartCoroutine(ResetPower());
        }

        if (collision.tag == "powerup2")
        {
            Destroy(collision.gameObject);
            jumpHeight = 400f;
            ScaleToTarget(new Vector3(0.3f, 0.3f, 0.3f), 1f);
            GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(ResetPower());
        }
        if (collision.tag == "powerup3")
        {
            Destroy(collision.gameObject);
            jumpHeight = 350f;
            ScaleToTarget(new Vector3(0.1f, 0.1f, 0.1f), 1f);
            GetComponent<SpriteRenderer>().color = Color.magenta;
            StartCoroutine(ResetPower());
        }
        if (collision.tag == "powerup4")
        {
            Destroy(collision.gameObject);
            health = health + 1;
            //StartCoroutine(FloatFunction());
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(ResetPower2());
        }
        if (collision.tag == "powerup5")
        {
            Destroy(collision.gameObject);
            //health = health + 1;
            StartCoroutine(SlowMo());
            GetComponent<SpriteRenderer>().color = Color.yellow;
            //StartCoroutine(ResetPower());
        }
    }

    public void doFlip()
    {
        StartCoroutine(FrontFlip());
        StartCoroutine(ResetPower());
    }

    public void doFloat()
    {
        StartCoroutine(FloatFunction());
        StartCoroutine(ResetPower());
    }

    public IEnumerator FrontFlip()
    {
        transform.eulerAngles = new Vector3(0, 0, 20);
        yield return new WaitForSeconds(0.01f);
        transform.eulerAngles = new Vector3(0, 0, 45);
        yield return new WaitForSeconds(0.01f);
        transform.eulerAngles = new Vector3(0, 0, 70);
        yield return new WaitForSeconds(0.01f);
        transform.eulerAngles = new Vector3(0, 0, 90);
        yield return new WaitForSeconds(0.1f);
        transform.eulerAngles = new Vector3(0, 0, 130);
        yield return new WaitForSeconds(0.01f);
        transform.eulerAngles = new Vector3(0, 0, 180);
        yield return new WaitForSeconds(0.01f);
        transform.eulerAngles = new Vector3(0, 0, 270);
        yield return new WaitForSeconds(0.1f);
        transform.eulerAngles = new Vector3(0, 0, 310);
        yield return new WaitForSeconds(0.1f);
        transform.eulerAngles = new Vector3(0, 0, 360);
        yield return new WaitForSeconds(0.01f);
    }

    private IEnumerator FloatFunction()
    {
        yield return new WaitForSeconds(0);
        //GetComponent<Rigidbody2D>().position = new Vector2(Random.Range(-5,5), Random.Range(0, 1));
        //GetComponent<SpriteRenderer>().color = Color.black;
        //GetComponent<Rigidbody2D>().drag = 100f;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().gravityScale = 1f;
        yield return new WaitForSeconds(1f);
    }


    private IEnumerator ScaleToTargetCoroutine(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float timer = 0.0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            //smoother step algorithm
            t = t * t * t * (t * (10f * t - 15f) + 20f);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        yield return null;
    }

    public IEnumerator SlowMo()
    {
        Time.timeScale = slowdownFactor;
        yield return new WaitForSecondsRealtime(slowdownTime);
        Time.timeScale = 1f;
        GetComponent<SpriteRenderer>().color = Color.white;

    }

    

    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(10);
        ScaleToTarget(new Vector3(0.15f, 0.15f, 0.15f), 1f);
        jumpHeight = 325f;
        Time.timeScale = 1f;
        //Time.timeScale = fullSpeed;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    private IEnumerator ResetPower2()
    {
        yield return new WaitForSeconds(5);
        ScaleToTarget(new Vector3(0.15f, 0.15f, 0.15f), 1f);
        jumpHeight = 325f;
        Time.timeScale = 1f;
        //Time.timeScale = fullSpeed;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
