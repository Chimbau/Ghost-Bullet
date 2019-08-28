using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;
    private float bulletSpeed = 10f;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }

    
    void FixedUpdate()
    {
        if (rb.velocity.magnitude < (transform.right * bulletSpeed).magnitude || rb.velocity.magnitude > (transform.right * bulletSpeed).magnitude)
        {
            rb.velocity = transform.right * bulletSpeed;
        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 dir = rb.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

      
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Target")
        {
            GameObject.Destroy(gameObject);
        }

    }

    public void SetSpeed(float speed)
    {
        bulletSpeed = speed;
    }


  

}
