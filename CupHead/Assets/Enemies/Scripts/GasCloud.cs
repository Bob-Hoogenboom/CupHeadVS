using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCloud : MonoBehaviour
{
    [SerializeField] private float _cloudSpeed = 5;
    [SerializeField] private Rigidbody2D _rb;
    public Transform player;

    private void Start()
    {
        _rb.velocity = transform.forward * _cloudSpeed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        
        //Destroy(gameObject);
    }



}
