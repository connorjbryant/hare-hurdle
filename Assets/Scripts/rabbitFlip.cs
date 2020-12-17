using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbitFlip : MonoBehaviour
{
    public RabbitJump player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<RabbitJump>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void makePlayerJump()
    {
        //    player = FindObjectOfType<playerController> ();
        RabbitJump.instance.doFlip();


    }

    public void makePlayerFloat()
    {
        RabbitJump.instance.doFloat();
    }
}
