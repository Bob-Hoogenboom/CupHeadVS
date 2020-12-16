using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int damage = 1;
    public int currentHealth;
    public int maxHealth;

    public Collider2D col;

    public bool isAlive;


    protected void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    //only used by the enemies, if both use it the player will take twice the damage.
    protected void OnTriggerEnter(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            OnPlayerInteraction(col.gameObject);
        }
    }

    protected virtual void OnPlayerInteraction(GameObject obj)
    {
        //player interact with enemy, what happends?
        TakeDamage();
    }


    protected void TakeDamage()
    {
        if(currentHealth == 0)
        {
            print("dies*");
            Destroy(gameObject);
        }
        else
        {
            currentHealth -= damage;
            print("Thats a lotta damage!");
        }
    }



}
