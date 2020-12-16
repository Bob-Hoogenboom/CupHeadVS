using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BothersomeBlueberry : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rayLength;
    [SerializeField] private bool _moveRight = true;
    [SerializeField] private Transform _floorChecker;

    public Animator animator;


    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }



    private void FixedUpdate()
    {
        RaycastHit2D ContactCheck = Physics2D.Raycast(_floorChecker.position, Vector2.down, _rayLength);

        Debug.DrawRay(_floorChecker.position, Vector2.down, Color.blue);

        if (ContactCheck == false)
        {

            //moves to the left while facing left;
            if(_moveRight == true)
            {
                animator.SetTrigger("Turn");
                transform.eulerAngles = new Vector2(0, -180);
                
                _moveRight = false;

            }


            //moves to the right while facing right;
            else
            {
                animator.SetTrigger("Turn");
                transform.eulerAngles = new Vector2(0, 0);
                
                _moveRight = true;

            }
        }

    }
}

