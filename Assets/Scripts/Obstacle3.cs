using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Obstacle3 : MonoBehaviour
{
    //public int damage = 1;
    public float speed;
    //private Shake shake;

    public GameObject effect;

    public GameObject explosionSound;

    /*void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();   
    }*/
    void Start()
    {
        StartCoroutine(FloatFunction());
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Obstacle"))
        {
            Instantiate(explosionSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

    private IEnumerator FloatFunction()
    {
        yield return new WaitForSeconds(0);
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().gravityScale = -0.3f;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody2D>().gravityScale = 1f;
    }
}
