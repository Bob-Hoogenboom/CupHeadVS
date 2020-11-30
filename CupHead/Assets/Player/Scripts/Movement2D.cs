using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement2D : MonoBehaviour
{
    public float horizontal;


    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public bool facingRight = true;

    private float crouch;
    public bool crouching = false;
    public bool jump = false;

    void Start()
    {
        facingRight = true;
    }

    void Update()
    {
        JumpFunction();
        CrouchFunction();
        Move();
        crouch = Input.GetAxisRaw("Crouch");

        jump = Input.GetButtonDown("Jump");

    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Flip(horizontal);
    }

    void JumpFunction()
    {
        if (jump && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7.2f), ForceMode2D.Impulse);
        }
        else
        {
            jump = false;
        }
    }

    void CrouchFunction()
    {
        if((crouch!=0) && isGrounded == true)
        {
            crouching = true;
        }
        else
        {
            crouching = false;
        }
    }

    void Flip(float horizontal)
    {
        if(horizontal>0 && !facingRight || horizontal<0 && facingRight){
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

     void Move()
     {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
     }

}
