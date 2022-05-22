using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour,IDataPersistance
{
    [SerializeField] private GameObject[] Stages;
    public GameObject currentStage;
    [SerializeField] private int _Stage = 0;
    private GameObject player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerInput>().gameObject;
    }

    private void Start()
    {
        currentStage = Stages[_Stage];
        if(_Stage == 0) { return; }
        player.transform.position = getCurrentStageCheckpoint().GetCheckPoint().transform.position;
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

    public void LoadData(GameData data)
    {
        Debug.Log("test");
        this._Stage = data.CurrentLevel;
    }

    public void SaveData(ref GameData data)
    {
        data.CurrentLevel = this._Stage;
        Debug.Log("Saved!!!");
    }
}
