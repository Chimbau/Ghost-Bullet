using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public Transform gunPosition;
    public Transform PlayerPosition;
    public float bulletSpeed;  
    public float fireRate;

    private float fireRateValue;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Rotate(gunPosition);
        transform.position = PlayerPosition.position;

        if (Input.GetMouseButtonDown(0) && fireRateValue <= 0)
        {
            bullet.GetComponent<Bullet>().SetSpeed(bulletSpeed);
            Instantiate(bullet, gunPosition.position, gunPosition.rotation);
            fireRateValue = fireRate;
            
        }
       

        if (fireRateValue > 0)
        {
            fireRateValue -= Time.deltaTime;
        }
      
    }

    public void Rotate(Transform tr)
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(tr.position);
        Vector3 resultVecotr = Input.mousePosition - pos;
        float angle = -Mathf.Atan2(resultVecotr.x, resultVecotr.y) * Mathf.Rad2Deg;
        tr.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
    }
}
