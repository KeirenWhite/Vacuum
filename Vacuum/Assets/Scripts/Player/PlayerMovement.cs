using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 500f;
    public float jumpForce = 300f;
    private Rigidbody2D rb;
    [HideInInspector] public bool isGrounded;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     
    }

    private void Update()
    {
        Jump();
    }
    void FixedUpdate()
    {
        Move();
        
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            Debug.Log("D");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        while (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        while (!collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        if (!isGrounded)
            Debug.Log("Not Grounded!");
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0f, jumpForce));
            }
        }
    }
}
