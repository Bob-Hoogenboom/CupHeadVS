using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpawning : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("IsSpawning", true);
            spriteRenderer.enabled = true;
        }
        else
        {
            animator.SetBool("IsSpawning", false);
            spriteRenderer.enabled = false;
        }

        if (Input.GetButtonDown("Vertical"))
        {
            animator.SetBool("IsSpawning", true);
            spriteRenderer.enabled = true;
        }
        else
        {
            animator.SetBool("IsSpawning", false);
            spriteRenderer.enabled = false;
        }
    }
}
