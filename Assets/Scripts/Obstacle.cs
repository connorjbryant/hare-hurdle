using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    //private Shake shake;

    public GameObject effect;

    public GameObject explosionSound;

    /*void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();   
    }*/

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //shake.CamShake();
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            Instantiate(explosionSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            //player takes damage
            other.GetComponent<RabbitJump>().health -= damage;
            Debug.Log(other.GetComponent<RabbitJump>().health);
            Destroy(gameObject);
        }
        if(other.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
        
    }
}
