using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothyTerror : MonoBehaviour
{
    [SerializeField] private float _jumpVelocity = 300f;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded = false;



    void Awake()
    {
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();

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
        _rigidbody2D.AddForce(new Vector2(0, _jumpVelocity));

        Debug.Log("coroutine done");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "floor")
        {
            _isGrounded = true;
            Debug.Log("_isGrounded changed to true");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "floor")
        {
            _isGrounded = false;
            Debug.Log("_isGrounded changed to false");
        }
    }

}




    /*    //make sure u replace "floor" with your gameobject name.on which player is standing
        function OnCollisionEnter(theCollision : Collision)
        {
            if (theCollision.gameObject.name == "floor")
            {
                isgrounded = true;
            }
        }

        //consider when character is jumping .. it will exit collision.
        function OnCollisionExit(theCollision : Collision)
        {
            if (theCollision.gameObject.name == "floor")
            {
                isgrounded = false;
            }
        }*/


