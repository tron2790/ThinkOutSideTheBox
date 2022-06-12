using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpDown : MonoBehaviour
{
    public UnityEvent onOpen;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            onOpen.Invoke();
        }
    }
}
