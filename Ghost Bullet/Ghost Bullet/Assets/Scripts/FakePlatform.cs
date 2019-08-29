using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatform : MonoBehaviour
{
    private SpriteRenderer platformSprite;
    public float viewTime;
    private float viewTimeValue;
    private float viewCoef;

    //private bool hit = false;

    public float transparentTime;
    private float transparentTimeValue;


    // Start is called before the first frame update
    void Start()
    {
        platformSprite = GetComponent<SpriteRenderer>();
        platformSprite.color = new Color(1f, 1f, 1f, 1f);
        viewTimeValue = viewTime;
        transparentTimeValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {


        viewCoef = viewTimeValue / viewTime;
        platformSprite.color = new Color(1f, 1f, 1f, viewCoef);
        
        /*if (hit)
        {
            if (viewTimeValue >= viewTime/4)
            {
               viewTimeValue -= Time.deltaTime;
            }
            else
            {
                hit = false;
                transparentTimeValue = transparentTime;
            }
        }*/


        if (transparentTimeValue >= 0)
        {
            transparentTimeValue -= Time.deltaTime;
        }
        else
        {
            if (viewTimeValue <= viewTime)
            {
                viewTimeValue += Time.deltaTime;
            }
       
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //hit = true;
        viewTimeValue = viewTime / 5;
        transparentTimeValue = transparentTime;
    }
   
}
