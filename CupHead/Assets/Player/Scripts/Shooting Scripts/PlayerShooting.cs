using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject LeftbulletPrefab;
    public GameObject RightbulletPrefab;
    public GameObject YbulletPrefab;
    public Animator animator;
    public Vector2 bulletPos;
    public Vector2 bulletMin;
    public Vector2 bulletY;

    float timeUntilFire;
    Movement2D pm;
    private void Start()
    {
        pm = gameObject.GetComponent<Movement2D>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > timeUntilFire)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
            animator.SetBool("IsShooting", true);
        }
        else 
        {
            animator.SetBool("IsShooting", false);
        }

        if (Input.GetButtonDown("Vertical") && Time.time > timeUntilFire)
        {
            ShootUp();
            timeUntilFire = Time.time + fireRate;
            animator.SetBool("IsShootingUp", true);
        }
        else
        {
            animator.SetBool("IsShootingUp", false);
        }
    }

    void Shoot()
    {
        bulletPos = transform.position;
        bulletMin = transform.position;
        if (pm.facingRight == true)
        {
            bulletPos += new Vector2(+1f, +0.43f);
            Instantiate(RightbulletPrefab, bulletPos, Quaternion.identity);
        }
        if (pm.facingRight == false)
        {
            bulletMin += new Vector2(-1f, +0.43f);
            Instantiate(LeftbulletPrefab, bulletMin, Quaternion.identity);
        }
    }

    void ShootUp()
    {
        bulletY = transform.position;
        if (pm.facingUp == true)
        {
            bulletY += new Vector2(-0.23f, +1.3759f);
            Instantiate(YbulletPrefab, bulletY, Quaternion.identity);
        }
    }
}
