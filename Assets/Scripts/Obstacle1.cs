using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    //public int damage = 1;
    public float speed;

    //public GameObject effect;

    //public GameObject explosionSound;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //Instantiate(explosionSound, transform.position, Quaternion.identity);
            //Instantiate(effect, transform.position, Quaternion.identity);
            //player takes damage
            //other.GetComponent<RabbitJump>().health -= damage;
            Debug.Log(other.GetComponent<RabbitJump>().health);
            Destroy(gameObject);
        }
        
    }
}
