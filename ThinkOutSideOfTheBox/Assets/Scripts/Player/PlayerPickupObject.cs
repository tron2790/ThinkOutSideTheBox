using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerPickupObject : MonoBehaviour
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
        return playerInput.GetPickup().ToString();
    }
    public bool isPicked()
    {
        return isPickedUp;
    }

    public void PickupObj(GameObject obj)
    {
        if (Input.GetKey(playerInput.GetPickup()))
        {
            
            if (obj.GetComponent<Rigidbody>())
            {
                Rigidbody objRig = obj.GetComponent<Rigidbody>();
                isPickedUp = true;
                //objRig.drag = 10f;
                objRig.velocity = 20 * (objectHolder.position - obj.transform.position);
               

            }
            if (Input.GetKeyUp(playerInput.GetPickup()))
            {
                isPickedUp = false;
            }


        }
        else
        {
            isPickedUp = false;
        }
       
    }

}
