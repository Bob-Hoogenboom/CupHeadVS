using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Movement2D controller;

    // Update is called once per frame
    void Update()
    {
        Input.GetAxisRaw("Horizontal");
    }
}
