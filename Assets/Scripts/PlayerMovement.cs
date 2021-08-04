using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;

    //public Transform dashText;
    //public Text dash;
    public Text dashText;

    float horizontalMove = 0f;

    public float runSpeed = 0f;

    bool jump = false;
    bool crouch = false;

    public Rigidbody2D rb;
    public Transform firePoint;
    public float dashTime;
    public float nextDashTime;
    public float dashSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //dashTime = startDashTime;

    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //run animation mathf - making allways positive value
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            
            
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            transform.localScale = new Vector2(0.1f, 0.1f);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            transform.localScale = new Vector2(0.21f, 0.21f);
        }



        if (dashTime <= Time.time)
        {
            dashText.color = Color.green;
            if (Input.GetButtonUp("Dash"))
            {


                if (Input.GetKey("d"))
                    //if (timeWhenAllowedNextShoot <= Time.time)

                    rb.velocity = Vector2.right * dashSpeed;
                else dashTime -= Time.deltaTime;
                if (Input.GetKey("a"))

                    rb.velocity = Vector2.left * dashSpeed;
                else dashTime -= Time.deltaTime;
                dashTime = Time.time + nextDashTime;
            }
        }
        else dashText.color = Color.red;

        /*
        if (Input.GetKey("s"))
            if (Input.GetKey("space"))
            {
                rb.velocity = Vector2.down * 30;
                animator.SetBool("IsJumping", false);
            }
        */

    }



    public void OnLanding()
    {
        
        //animator.SetBool("IsJumping", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //when to stop jumping animation

        if(collision.contacts[0].normal.y > -0.5)
            animator.SetBool("IsJumping", false);

        
    }






    private void FixedUpdate()
    {
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch , jump);
        jump = false;
        
    }
}
