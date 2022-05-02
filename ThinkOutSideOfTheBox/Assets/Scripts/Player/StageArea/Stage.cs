using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private GameObject[] Stages;
    public GameObject currentStage;

    public void setCurrentStage(int _Stage)
    {
        currentStage = Stages[_Stage];
    }



}
