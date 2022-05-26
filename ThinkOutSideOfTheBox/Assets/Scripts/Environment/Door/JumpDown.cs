using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDown : MonoBehaviour
{
    
    [SerializeField] private Door door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            door.DoorOpen();
        }
    }
}
