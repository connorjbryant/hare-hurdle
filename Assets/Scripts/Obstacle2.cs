using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
    //public int damage = 1;
    public float speed;
    private Rigidbody2D rb;
    private Collider2D coll;

    //public GameObject effect;

    //public GameObject explosionSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        StartCoroutine(FloatFunction());
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.gameObject.tag == "Player")
        {
            //Instantiate(explosionSound, transform.position, Quaternion.identity);
            //Instantiate(effect, transform.position, Quaternion.identity);
            //player takes damage
            //other.GetComponent<RabbitJump>().health -= damage;
            //Debug.Log(other.GetComponent<RabbitJump>().health);
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
        GetComponent<Rigidbody2D>().gravityScale = -0.3f;
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody2D>().gravityScale = 0.2f;
    }
}
