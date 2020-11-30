using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BothersomeBlueberry : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rayLength;
    [SerializeField] private bool _moveRight = true;
    [SerializeField] private Transform _floorChecker;


    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }



    private void FixedUpdate()
    {
        RaycastHit2D ContactCheck = Physics2D.Raycast(_floorChecker.position, Vector2.right, _rayLength);

        if(ContactCheck == true)
        {

            //moves to the left while facing left;
            if(_moveRight == true)
            {
                transform.eulerAngles = new Vector2(0, -180);
                _moveRight = false;
            }


            //moves to the right while facing right;
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
                _moveRight = true;
            }
        }

    }
}

