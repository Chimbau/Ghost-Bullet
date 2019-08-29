using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    private Rigidbody2D rb;
    public float movespeed;
    
    private float xAxis;

    private bool jump;
    public float jumpForce;
    public float fallMultiplier = 2f;
    public float lowJumpMultiplier = 2f;
    public float AirMovementForce = 2f;

    public float checkRadius;
    public Transform groundCheck;
    public Transform respawnPosition;
    public LayerMask whatIsGround;

  
    public float airDragMultiplier = 0.05f;



    private bool virou = true;
    //private int facingDirection = 1;
    private bool Grounded;


    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(9, 10);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerInput();
        HorizontalMovement();
        VerticalMovement();
      
     
    }

    void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
    }


    public void PlayerInput()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButtonDown("Jump");
    }


    public void HorizontalMovement()
    {

      
        if (Grounded)
        {
            rb.velocity = new Vector2(xAxis * movespeed, rb.velocity.y);
        }
        else if (!Grounded && xAxis != 0)
        {
           
            Vector2 forceToAdd = new Vector2(AirMovementForce * xAxis, 0);
            rb.AddForce(forceToAdd);

            if (Mathf.Abs(rb.velocity.x) > movespeed)
            {
                rb.velocity = new Vector2(movespeed * xAxis, rb.velocity.y);
            }
                        
        }
        else{
            if (!Grounded && xAxis == 0)
            {
               
                rb.velocity = new Vector2(rb.velocity.x * airDragMultiplier, rb.velocity.y);
                
                
            }
        }
       

        if (xAxis > 0 && virou == false)
        {
            transform.Rotate(0, 180, 0);
            //facingDirection = 1;
            virou = true;
        }

        if (xAxis < 0 && virou == true)
        {
            transform.Rotate(0, 180, 0);
            //facingDirection = -1;
            virou = false;
        }
        

      
    }

    public void VerticalMovement()
    {


        if (jump && Grounded && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


    }

    public bool isGrounded()
    {
        return Grounded;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerOutOfBounds")
        {
            rb.velocity = Vector3.zero;
            transform.position = respawnPosition.position;
        }

    }

  







}
