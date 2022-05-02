using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
   [SerializeField] private GameObject CurrentCheckPoint;

    public GameObject GetCheckPoint()
    {
        return CurrentCheckPoint;
    }


   
}
