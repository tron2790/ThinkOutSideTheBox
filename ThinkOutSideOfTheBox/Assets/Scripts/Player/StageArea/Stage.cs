using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private GameObject[] Stages;
    public GameObject currentStage;
    private int _Stage = 0;
    private void Start()
    {
        currentStage = Stages[0];
    }

    public void setCurrentStage()
    {
        

        _Stage++;

        currentStage = Stages[_Stage];
    }

    public CheckPoint getCurrentStageCheckpoint()
    {
        CheckPoint cp = currentStage.GetComponentInChildren<CheckPoint>();
        return cp;
    }

    public CameraModel getCurrentStageCameraModel()
    {
        CameraModel cm = currentStage.GetComponentInChildren<CameraModel>();
        return cm;
    }


}
