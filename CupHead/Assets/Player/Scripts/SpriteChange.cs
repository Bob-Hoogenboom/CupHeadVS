using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    Movement2D playerleftshift;

    public Sprite idle;
    public Sprite crouched;
    public Sprite running;

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = idle;
        }

        playerleftshift = GetComponent<Movement2D>();

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            SpriteCrouch();
        }
        else
        {
            spriteRenderer.sprite = idle;
        }
        SpriteRun();
    }

    void SpriteCrouch()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (spriteRenderer.sprite == idle)
            {
                spriteRenderer.sprite = crouched;
            }
        }
    }

    void SpriteRun()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (spriteRenderer.sprite == idle)
            {
                spriteRenderer.sprite = running;
            }
        }
    }
}
