using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class objectDetection : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] private float distance;
    [SerializeField] GameObject currentLookAtObj;
    [SerializeField] private Image crosshair;
    // Update is called once per frame
    RaycastHit hit;
    private Highlighter highlighter;
    private PlayerInteraction interaction;
    private void Awake()
    {
        highlighter = GetComponent<Highlighter>();
        interaction = GetComponent<PlayerInteraction>();
    }

    void Update()
    {
        
        if (currentLookAtObj == null || interaction.isPicked())
        {
            highlighter.StopInfo();
        }

        
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Pickup"))
            {
               
                
                Debug.DrawLine(cam.transform.position, hit.transform.position, Color.red);
                crosshair.color = new Color(crosshair.color.r, crosshair.color.g, crosshair.color.b, 1f);
                hit.transform.gameObject.GetComponent<Outline>().enabled = true;
                currentLookAtObj = hit.transform.gameObject;
                interaction.PickupObj(currentLookAtObj);

                if (!interaction.isPicked()){
                    highlighter.StartInfo($"Press: {interaction.GetValueKey()}");
                }

            }
            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Button"))
            {
                crosshair.color = new Color(crosshair.color.r, crosshair.color.g, crosshair.color.b, 1f);
                hit.transform.gameObject.GetComponent<Outline>().enabled = true;
                currentLookAtObj = hit.transform.gameObject;
                Debug.DrawLine(cam.transform.position, hit.transform.position, Color.green);
            }else if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Lever"))
            {
                crosshair.color = new Color(crosshair.color.r, crosshair.color.g, crosshair.color.b, 1f);
                hit.transform.gameObject.GetComponent<Outline>().enabled = true;
                currentLookAtObj = hit.transform.gameObject;
                Debug.DrawLine(cam.transform.position, hit.transform.position, Color.green);
                interaction.InteractWithLever(hit.transform.gameObject);
                highlighter.StartInfo($"Press: {interaction.GetValueKey()}");

            }
            else
            {
                if (currentLookAtObj == null) { return; }
                currentLookAtObj.GetComponent<Outline>().enabled = false;
                highlighter.StopInfo();
                currentLookAtObj = null;
                crosshair.color = new Color(crosshair.color.r, crosshair.color.g, crosshair.color.b, 0.5f);
            }



        }
        else
        {
            if (currentLookAtObj == null) { return; }
            currentLookAtObj.GetComponent<Outline>().enabled = false;
            highlighter.StopInfo();
            currentLookAtObj = null;
            crosshair.color = new Color(crosshair.color.r, crosshair.color.g, crosshair.color.b, 0.5f);
        }


    }
}
