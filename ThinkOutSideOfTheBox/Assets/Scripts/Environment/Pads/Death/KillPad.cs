using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPad : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            collision.gameObject.GetComponent<PlayerHealth>().instantKill();
        }
    }
}
