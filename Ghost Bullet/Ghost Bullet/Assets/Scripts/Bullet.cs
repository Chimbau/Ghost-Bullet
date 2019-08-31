using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;
    private float bulletSpeed = 10f;

    public float lifeTime;
    private float lifeTimeValue;

    private int bounceCount = 0;
    public int maxBounceCount;

    public GameObject PlayerExplosion;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
        lifeTimeValue = lifeTime;

    }


    void Update()
    {
        if (lifeTimeValue >= 0)
        {
            lifeTimeValue -= Time.deltaTime;
        }
        else
        {
            DestroyBullet();
        }


        if (bounceCount >= maxBounceCount)
        {
            DestroyBullet();
        }


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
        bounceCount++;
        Vector2 dir = rb.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        FindObjectOfType<AudioManager>().Play("Collision");
      
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Target")
        {
            DestroyBullet();
        }

        if (col.tag == "OutOfBounds")
        {
            DestroyBullet();
        }

        if (col.tag == "Player")
        {

        }

    }

    public void SetSpeed(float speed)
    {
        bulletSpeed = speed;
    }

    public void DestroyBullet()
    {
        GameObject.Destroy(gameObject);


    }


  

}
