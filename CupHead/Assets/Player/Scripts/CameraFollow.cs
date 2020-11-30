using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 newCameraPos = transform.position;
        newCameraPos.x = playerTransform.position.x;
        transform.position = newCameraPos;
    }
}
