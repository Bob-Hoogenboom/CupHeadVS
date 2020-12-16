using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement2D : MonoBehaviour
{
    [SerializeField] float jumpForce;
    public Animator animator;
    public float horizontal;
    public float moveSpeed = 5f;
    public float crouchSpeed = 0f;
    float horizontalMove = 0f;
    private float crouch;

    public bool isGrounded = false;
    public bool facingRight = true;
    public bool facingUp = false;
    public bool crouching = false;
    public bool jump = false;
    Rigidbody2D Player2D;

    void Start()
    {
        facingRight = true;
        facingUp = false;
        Player2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        JumpFunction();
        CrouchFunction();
        Move();
        MidAir();
        Crouchmovement();

        crouch = Input.GetAxisRaw("Crouch");
        jump = Input.GetButtonDown("Jump");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Flip(horizontal);
        FlipUp(vertical);
    }

    void JumpFunction()
    {
        if (jump && isGrounded == true)
        {
            Player2D.velocity = new Vector2(Player2D.velocity.x, jumpForce);
        }
        else
        {
            jump = false;
        }
    }
    
    void MidAir()
    {
        if (isGrounded == false)
        {
            animator.SetBool("IsJumping", true);
        }
        if (isGrounded == true)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    void CrouchFunction()
    {
        if((crouch!=0) && isGrounded == true)
        {
            crouching = true;
            animator.SetBool("IsCrouching", true);
        }
        else
        {
            crouching = false;
            animator.SetBool("IsCrouching", false);
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
        if(horizontal > 0 && !facingRight)
        {
            facingRight = true;
        }
        if (horizontal < 0 && facingRight)
        {
            facingRight = true;
        }
    }

    void FlipUp(float vertical)
    {
        if (vertical > 0 && !facingUp || vertical < 0 && facingUp)
        {
            facingUp = !facingUp;
            Vector3 theScaleUp = transform.localScale;
            theScaleUp.x *= 1;
            transform.localScale = theScaleUp;
        }
        if (vertical > 0 && !facingUp)
        {
            facingUp = true;
        }
    }


    void Move()
     {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
     }

    void Crouchmovement()
    {
        if (crouching && isGrounded == true)
        {
            Vector3 crouched = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position -= crouched * Time.deltaTime * moveSpeed;
        }
    }
}
