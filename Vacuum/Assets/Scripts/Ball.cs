using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float bounceMultiplier = 1.5f;  // Multiplier for bounce strength
    private Rigidbody2D rb;
    private int launchCounter;
    private Camera mainCamera;
    private int bounceCounter = 0;
    public float bounceMultiplierMultiplier = 1.05f;
    public int bounceCap = 8;
    public float launchSpeed = 5f;
    public float maxSpeed = 12f;
    private Vector2 lastVelocity;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

       
        mainCamera = Camera.main;

        lastVelocity = rb.velocity;
        
        
    }

    private void Update()
    {
        Launch();

    }

    private void FixedUpdate()
    {
        CheckBorders();

        float currentSpeed = rb.velocity.magnitude;
        float lastSpeed = lastVelocity.magnitude;

        if (currentSpeed > maxSpeed)
        {
            // Cap the velocity to the max speed while keeping the same direction
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        if (currentSpeed < lastSpeed)
        {
            rb.velocity = rb.velocity.normalized * lastSpeed;
        }

        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) //clamp velocity at some point
    {
        // Check if the collision is with an object tagged as "Wall"
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Block"))
        {
           // Calculate the reflection vector based on the collision normal
            Vector2 incomingVelocity = rb.velocity;
            //Vector2 reflection = Vector2.Reflect(incomingVelocity, collision.contacts[0].normal);

<<<<<<< Updated upstream
            // Apply the bounce multiplier
            rb.velocity = incomingVelocity * bounceMultiplier;

            if(Mathf.Abs(rb.velocity.x) < 0.5f)
            {
                rb.velocity = new Vector2(-Mathf.Sign(rb.velocity.x) * 2, rb.velocity.y);
            }
            if (Mathf.Abs(rb.velocity.y) < 0.5f)
            {
                rb.velocity = new Vector2(rb.velocity.x, -Mathf.Sign(rb.velocity.y) * 2);
            }

            bounceCounter++;
            Debug.Log(bounceCounter.ToString());

            Bounces();
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            //ResetBall();
        }
        else
        {
            //ResetBall();
=======
            // Apply the bounce multiplier*/
            rb.velocity = incomingVelocity * bounceMultiplier;
>>>>>>> Stashed changes
        }
    }

   
    private void Launch()
    {
        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        if (launchCounter == 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = direction * launchSpeed;
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

    private void Bounces()
    {
        if(bounceCounter == bounceCap) //1.27628
        {
            bounceMultiplier *= bounceMultiplierMultiplier;
        }
        else if(bounceCounter == 10)
        {
            bounceMultiplier *= 1f;
        }
    }
}
    
