using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightindicator : MonoBehaviour
{

   
    [SerializeField] private Material green;
    [SerializeField] private Material Red;
    [SerializeField] private GameObject LightObj;

    // Start is called before the first frame update
    


    public void ChangeLight(bool active)
    {
        if (active)
        {
            LightObj.GetComponent<MeshRenderer>().material = green;
        }
        else
        {
            LightObj.GetComponent<MeshRenderer>().material = Red;
        }
    }

    
}
