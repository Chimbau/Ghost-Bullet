using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private ParticleSystem p;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, 20 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            p.Play();
            GameManager.instance.ShowPanel();
            sprite.color = new Color(1f, 1f, 1f, 0f);
            //gameObject.SetActive(false);
            //GameObject.Destroy(gameObject);
        }



    }
}
