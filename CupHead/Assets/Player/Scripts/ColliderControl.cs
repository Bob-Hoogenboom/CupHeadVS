using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControl : MonoBehaviour
{
    public BoxCollider2D stand;
    public BoxCollider2D crouch;
    public CircleCollider2D circle;

    Movement2D playerleftshift;
    // Start is called before the first frame update
    void Start()
    {
        playerleftshift = GetComponent<Movement2D>();
        stand.enabled = true;
        crouch.enabled = false;
        circle.enabled = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerleftshift.isGrounded == false)
        {
            stand.enabled = true;
            crouch.enabled = false;
            circle.enabled = false;
        }
        else
        {
            if (playerleftshift.crouching == true)
            {
                stand.enabled = false;
                crouch.enabled = true;
                circle.enabled = false;
            }
            else
            {
                stand.enabled = true;
                crouch.enabled = false;
                circle.enabled = true;
            }
        }
    }
}
