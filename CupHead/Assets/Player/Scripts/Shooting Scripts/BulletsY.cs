using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsY : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D hitbox;
    public Animator animator;


    private void FixedUpdate()
    {
        hitbox.velocity = transform.up * 12;
        animator.SetBool("BulletFlyingUp", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
