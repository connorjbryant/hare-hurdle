using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float begin;
    public float dist = 5;
    public float speed = 5;
    public int dir;
    void Start()
    {
        begin = transform.position.x;
        dir = -1;
        //StartCoroutine(FloatFunction());
    }
    void Update()
    {
        // you should'nt need a non-kinetic rigidbody attached for this simple movement!!!
        if (transform.position.x > begin + dist) { dir = -1; transform.localScale = new Vector3(1, 1, 1); }
        else { if (transform.position.x < begin - dist) { dir = 1; transform.localScale = new Vector3(-1, 1, 1); } }

        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed * dir,
                                          transform.position.y,
                                          transform.position.z);
    }

    /*private IEnumerator FloatFunction()
    {
        yield return new WaitForSeconds(0);
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody2D>().gravityScale = 0f;
    }*/
}
