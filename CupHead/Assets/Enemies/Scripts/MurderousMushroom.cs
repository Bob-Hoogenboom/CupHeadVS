using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurderousMushroom : MonoBehaviour
{
    [SerializeField] private bool _isAttacking;
    public float gap;


    public GameObject player;
    public GameObject bullet;

    public Animator animator;

    [SerializeField] private float shootSpeed = 5;
    private float shootTimer = 0;
    

    private void Start()
    {
        shootTimer = shootSpeed;
    }
    private void Update()
    {
        //player is in of range and the shoot delay is above the shootrate
        if ((transform.position - player.transform.position).magnitude < gap && shootTimer >= shootSpeed) {
            Debug.DrawLine(transform.position, player.transform.position, Color.red);
            ShroomShoot();
            print(shootTimer);
        }

        else {
            _isAttacking = false;
            animator.SetBool("IsAttacking", false);
            
        }
        shootTimer += Time.deltaTime;
   
    }

    //the shooting state is entered
    protected void ShroomShoot()
    {
        _isAttacking = true;
        animator.SetBool("IsAttacking", true);
        print("_isHiding = true");
        StartCoroutine(SporeShoot());
    }

    //SHOTS FIRED! and reset
    IEnumerator SporeShoot()
    {
        
        Vector3 relativePos = player.transform.position - transform.position;
        GameObject myBullet = Instantiate(bullet, transform.position, Quaternion.LookRotation(relativePos, Vector3.up));

        // myBullet.transform.right = transform.position - player.transform.position;

        shootTimer = 0;

        Debug.Log("coroutine done");
        yield return null;
    }

}


//jesse bullet transform

/*Vector3 relativePos = player.transform.position - transform.position;
Vector2 relativePos2D = new Vector2(relativePos.x, relativePos.y);
GameObject myBullet = Instantiate(bullet, transform.position, Quaternion.LookRotation(relativePos2D, Vector3.up));
(myBullet.transform).rotation.eulerAngles = new Vector3(myBullet.transform.rotation.x, 0, 0);*/

