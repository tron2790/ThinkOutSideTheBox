using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerInteraction : MonoBehaviour
{
    public Transform objectHolder;
    public float speed = 1.0f;
    private PlayerInput playerInput;
    private bool isPickedUp;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public string GetValueKey()
    {
        return playerInput.GetInteraction().ToString();
    }
    public bool isPicked()
    {
        return isPickedUp;
    }

    public void PickupObj(GameObject obj)
    {
        if (Input.GetKey(playerInput.GetInteraction()))
        {
            
            if (obj.GetComponent<Rigidbody>())
            {
                Rigidbody objRig = obj.GetComponent<Rigidbody>();
                isPickedUp = true;
                //objRig.drag = 10f;
                objRig.velocity = speed * (objectHolder.position - obj.transform.position);
               

            }
            if (Input.GetKeyUp(playerInput.GetInteraction()))
            {
                isPickedUp = false;
            }


        }
        else
        {
            isPickedUp = false;
        }
       
    }


    public void InteractWithLever(GameObject _lever)
    {
        Lever lever = _lever.GetComponent<Lever>();
        if (Input.GetKeyDown(playerInput.GetInteraction()))
        {
            if (lever.leverState)
            {
                lever.Off();
            }
            else if (!lever.leverState)
            {
                lever.On();
            }
        }
    }

}
