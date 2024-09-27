using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCoreFeatures : MonoBehaviour
{
    public int requiredHits = 1;
    private int currentHits = 0;
    void Start()
    {

    }


    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Ball")) return;

        if (requiredHits == 1)
        {
            if (col.gameObject.CompareTag("Ball"))
            {
                Destroy(gameObject);
            }
            else return;
        }
        
        if (requiredHits > 1)
        {
            if (col.gameObject.CompareTag("Ball"))
            {
                currentHits++;
                if (currentHits == requiredHits)
                {
                    Destroy(gameObject);
                }  
            }
        }
    }
}