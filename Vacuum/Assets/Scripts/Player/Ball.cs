using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //public GameObject ball;
    public float launchForce = 4f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Launch();
    }

    public void Launch()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            rb.AddForce(new Vector2(0f, launchForce));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = rb.velocity * -2f;
        }
    }
}
    
