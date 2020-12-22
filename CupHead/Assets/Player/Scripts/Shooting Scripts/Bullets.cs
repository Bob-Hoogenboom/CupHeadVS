using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D hitbox;
    public Animator animator;


    private void FixedUpdate()
    {
        hitbox.velocity = transform.right * bulletSpeed;
        animator.SetBool("BulletFlying", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
