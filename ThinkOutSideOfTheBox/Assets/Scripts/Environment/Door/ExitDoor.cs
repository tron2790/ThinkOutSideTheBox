using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{

    [SerializeField] private bool isLiftDoor;
    private void OnTriggerExit(Collider other)
    {
       
        if(other.tag == "Player")
        {
            GetComponentInParent<Door>().setIsDoorClosed(true);
            GetComponentInParent<Door>().DoorClose();
            if (isLiftDoor) { return; }
            FindObjectOfType<Stage>().setCurrentStage();
        }
    }
}
