using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothyTerror : MonoBehaviour
{
    [SerializeField] private float _jumpVelocity = 300f;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded = false;

    public Animator animator;

    public float animeSpeed = 5;
    private float _animeTimer = 0;

    void Awake()
    {
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        _animeTimer = animeSpeed;
    }


    private void FixedUpdate()
    {
        if (_isGrounded == true)
        {
            StartCoroutine(JumpEnemy());
            
        }

    }

    IEnumerator JumpEnemy()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("IsJumping");
        _rigidbody2D.AddForce(new Vector2(0, _jumpVelocity));
        
        //Debug.Log("coroutine done");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "TTfloor")
        {
            _isGrounded = true;
           
            //Debug.Log("_isGrounded changed to true");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "TTfloor")
        {
            _isGrounded = false;
            
            //Debug.Log("_isGrounded changed to false");
        }
    }

}







