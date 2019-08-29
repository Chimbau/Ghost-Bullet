using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour
{
    private SpriteRenderer platformSprite;
    public float viewTime;
    private float viewTimeValue;
    private float viewCoef;

    // Start is called before the first frame update
    void Start()
    {
        platformSprite = GetComponent<SpriteRenderer>();
        platformSprite.color = new Color(1f, 1f, 1f, 0f);
        viewTimeValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (viewTimeValue >= 0)
        {
            viewTimeValue -= Time.deltaTime;
        }
        viewCoef = viewTimeValue/viewTime;


        platformSprite.color = new Color(1f, 1f, 1f, viewCoef);


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        viewTimeValue = viewTime;

    }
}
