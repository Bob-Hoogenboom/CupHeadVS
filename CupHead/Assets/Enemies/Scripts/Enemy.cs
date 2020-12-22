using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxhealth = 1;
    public int currenthealth = 0;



    void Start()
    {
        currenthealth = maxhealth;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            print("AAAAUUUUU IK GA MN MAMA BELLEN!");
            currenthealth -= 1;

            if(currenthealth == 0)
            {
                print("HARTSTIKKE DOOD");
                GameObject.Destroy(gameObject);
            }
        }
    }
}
