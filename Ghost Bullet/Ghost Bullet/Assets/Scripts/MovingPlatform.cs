using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float speed;
    public float stopTime;
    private float stopTimeValue;

    private Rigidbody2D rb;
    private Vector3 speedVector;
    private Vector3 position1;
    private Vector3 position2;
    private float distanceBetween1and2;
    private Vector3 velocity = Vector3.zero;

    public Transform goToPostion;

    private bool going = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position1 = transform.position;
        position2 = goToPostion.position;
        distanceBetween1and2 = (position2 - position1).magnitude;
        speedVector = (position2 - position1).normalized * speed;
        rb.velocity = speedVector;
        stopTimeValue = stopTime;
    }

   
    void FixedUpdate()
    {

        if (going)
        {
            float distance = (position1 - transform.position).magnitude;
            if (distance >= distanceBetween1and2)
            {
                rb.velocity = Vector3.zero;
                WaitAndGo();
                            
            }
        }
        else
        {
            float distance = (position2 - transform.position).magnitude;
            if (distance >= distanceBetween1and2)
            {
                rb.velocity = Vector3.zero;
                WaitAndGo();
               
            }
        }
             
      
    }

    public void WaitAndGo()
    {
        if (stopTimeValue >= 0)
        {
            stopTimeValue -= Time.fixedDeltaTime;
        }
        else
        {
           
            if (going)
            {
                speedVector = (position1 - position2).normalized * speed;
            }
            else
            {
                speedVector = (position2 - position1).normalized * speed;
            }
            
            rb.velocity = speedVector;
            going = !going;
            stopTimeValue = stopTime;
        }


    }
}
