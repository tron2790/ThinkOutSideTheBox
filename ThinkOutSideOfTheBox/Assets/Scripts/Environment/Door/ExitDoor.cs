using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
  
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponentInParent<Door>().setIsDoorClosed(true);
            GetComponentInParent<Door>().DoorClose();
            FindObjectOfType<Stage>().setCurrentStage();
        }
    }
}
