using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnDeath : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
