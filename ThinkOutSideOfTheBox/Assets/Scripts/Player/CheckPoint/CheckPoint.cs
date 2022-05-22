using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private string id;
    [ContextMenu("Generate guid for ID")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public string GetID()
    {
        return id;
    }


   [SerializeField] private GameObject CurrentCheckPoint;

    public GameObject GetCheckPoint()
    {
        return CurrentCheckPoint;
    }


   
}
