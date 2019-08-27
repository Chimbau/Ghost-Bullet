using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;
    private float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        

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
