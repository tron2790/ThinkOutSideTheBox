using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LoadSaveSelect : MonoBehaviour
{

    [SerializeField] private GameObject SaveLevelButtonPrefab;
    [SerializeField] private GameObject mask;
   
    private void Start()
    {
        LoadSaveLevels();
    }

    public void LoadSaveLevels()
    {
        string[] files = DataPresistanceManager.Instance.LoadFileNames();
        Debug.Log(files.Length);
        for (int i = 0; i < files.Length; i++)
        {
            GameObject newinstance = Instantiate(SaveLevelButtonPrefab, mask.transform.position, Quaternion.identity, mask.transform);
            newinstance.GetComponentInChildren<TMP_Text>().SetText(files[i]);
        }
    }
}

