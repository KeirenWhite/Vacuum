using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float bounceMultiplier = 1.5f;  // Multiplier for bounce strength
    private Rigidbody2D rb;
    private int launchCounter;
    private Camera mainCamera;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

       
        mainCamera = Camera.main;
        
        
    }

    private void Update()
    {
        Launch();
    }

    private void FixedUpdate()
    {
        CheckBorders();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object tagged as "Wall"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculate the reflection vector based on the collision normal
            Vector2 incomingVelocity = rb.velocity;
            Vector2 reflection = Vector2.Reflect(incomingVelocity, collision.contacts[0].normal);

            // Apply the bounce multiplier
            rb.velocity = reflection * bounceMultiplier;
        }
    }

    private void Launch()
    {
        if (launchCounter == 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = new Vector2(2f, -5f);
                launchCounter++;
            }
        }
    }

    private void CheckBorders()
    {
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        // Check if the ball is outside the camera bounds
        if (transform.position.x < -screenBounds.x || transform.position.x > screenBounds.x ||
            transform.position.y < -screenBounds.y || transform.position.y > screenBounds.y)
        {
            ResetBall();
        }
    }

    private void ResetBall()
    {
        transform.position = Vector2.zero;

        rb.velocity = Vector2.zero;

        launchCounter = 0;
    }

}
    
