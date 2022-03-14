using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private GameObject doorModel;
    

    public void DoorClose()
    {
        doorModel.SetActive(true);
    }

    public void DoorOpen()
    {
        doorModel.SetActive(false);
    }
}
