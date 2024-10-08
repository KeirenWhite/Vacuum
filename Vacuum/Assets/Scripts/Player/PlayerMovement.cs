using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 500f;
    private Rigidbody2D rb;
    public float rotationDegrees = 90f;
    public float rotationDegrees2 = 90f;
    public float rotationDegrees3 = 90f;
    public float rotationDegrees4 = 90f;
    public float rotationDegrees5 = 90f;
    public float rotationDegrees6 = 90f;
    public float rotationDegrees7 = 90f;
    public float rotationDegrees8 = 90f;
    private bool bottomSide = true;
    private bool leftSide = false;
    private bool topSide = false;
    private bool rightSide = false;


    // public float rotationSpeed = 2f;

    //PLAYER STATES!!!!!!!!!!!!!!!
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

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
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (!col.gameObject.CompareTag("Rotate1") || leftSide == true)
        {
            return;
        }
        else
        {
            Debug.Log("bruh");
            Pivot1();
            leftSide = true;
            bottomSide = false;
            topSide = false;
            rightSide = false;
            

        }

        if (!col.gameObject.CompareTag("Rotate2") || bottomSide == true)
        {
            return;
        }
        else
        {
            
            Pivot2();
            bottomSide = true;
            leftSide = false;
            topSide = false;
            rightSide = false;
        }
        if (!col.gameObject.CompareTag("Rotate3") || bottomSide == true)
        {
            return;         
        }
        else
        {
            
            Pivot3();
            leftSide = true;
            bottomSide = false;
            topSide = false;
            rightSide = false;
        }
        if (!col.gameObject.CompareTag("Rotate4") || topSide == true)
        {
            return;       
        }
        else
        {
            Debug.Log("34434");
            Pivot4();
            topSide = true;
            leftSide = false;
            bottomSide = false;
            rightSide = false;
        }
        if (!col.gameObject.CompareTag("Rotate5") || rightSide == true)
        {
            return;    
        }
        else
        {
            Debug.Log("collision");
            Pivot5();
            rightSide = true;
            leftSide = false;
            bottomSide = false;
            topSide = false;
        }
        if (!col.gameObject.CompareTag("Rotate6") || bottomSide == true)
        {
            return;
        }
        else
        {
            Debug.Log("collision");
            Pivot6();
            bottomSide = true;
            leftSide = false;
            topSide = false;
            rightSide = false;
        }
        if (!col.gameObject.CompareTag("Rotate7") || topSide == true)
        {
            return;                
        }
        else
        {
            Debug.Log("collision");
            Pivot7();
            topSide = true;
            leftSide = false;
            bottomSide = false;
            rightSide = false;
        }
        if (!col.gameObject.CompareTag("Rotate8") || rightSide == true)
        {
            return;
        }
        else
        {
            Debug.Log("collision");
            Pivot8();
            rightSide = true;
            leftSide = false;
            bottomSide = false;
            topSide = false;
        }
    }
        public void Pivot1()
    {
        transform.Rotate(0, 0, rotationDegrees);
    }
        public void Pivot2()
    {
        transform.Rotate(0, 0, rotationDegrees2);
    }
        public void Pivot3()
    {
        transform.Rotate(0, 0, rotationDegrees3);
    }
        public void Pivot4()
    {
        transform.Rotate(0, 0, rotationDegrees4);
    }
        public void Pivot5()
    {
        transform.Rotate(0, 0, rotationDegrees5);
    }
        public void Pivot6()
    {
        transform.Rotate(0, 0, rotationDegrees6);
    }
        public void Pivot7()
    {
        transform.Rotate(0, 0, rotationDegrees7);
    }
        public void Pivot8()
    {
        transform.Rotate(0, 0, rotationDegrees8);
    }
}
