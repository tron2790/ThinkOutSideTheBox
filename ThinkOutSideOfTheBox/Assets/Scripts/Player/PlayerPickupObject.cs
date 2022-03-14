using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickupObject : MonoBehaviour
{

    [SerializeField] Transform cam;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask canPickup;
    [SerializeField] private KeyCode Pickup = KeyCode.E;
    GameObject obj;
    public Vector3 offset;
    public Transform objectHolder;
    public float speed = 1.0f;
    [SerializeField] private Image crosshair;
    // Update is called once per frame
    RaycastHit hit;
    void Update()
    {
        

        if(Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, distance ,canPickup))
        {
            Debug.DrawLine(cam.transform.position, hit.transform.position, Color.red);
            crosshair.color = new Color(crosshair.color.r, crosshair.color.g, crosshair.color.b, 1f);
            hit.transform.gameObject.GetComponent<Outline>().enabled = true;
            obj = hit.transform.gameObject;
            if (Input.GetKeyDown(Pickup))
            {

                 
                
            }

        }
        else
        {
            if(obj == null) { return; }
            obj.GetComponent<Outline>().enabled = false;
        }



        if(Input.GetKey(Pickup) && obj != null)
        {
            if (obj.GetComponent<Rigidbody>())
            {
                Rigidbody objRig = obj.GetComponent<Rigidbody>();
               
                //objRig.drag = 10f;
                objRig.velocity = 10 * (objectHolder.position - obj.transform.position);
                
            }
            if (Input.GetKeyUp(Pickup))
            {
                obj = null;
                crosshair.color = new Color(crosshair.color.r, crosshair.color.g, crosshair.color.b, 0.6f);
            }

        }


    }
}
