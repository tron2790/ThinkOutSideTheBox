using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
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
            string filename = files[i];
            string shortenFileExtenstion = filename.Replace(".game", "");
            string shortenFileName = shortenFileExtenstion.Replace("Save", "");
            GameObject newinstance = Instantiate(SaveLevelButtonPrefab, mask.transform.position, Quaternion.identity, mask.transform);
            newinstance.GetComponentInChildren<TMP_Text>().SetText($"Save {i}: {shortenFileName}");
            Button btn = newinstance.GetComponent<Button>();
            btn.onClick.AddListener(() => Load(filename));
           
           
        }
    }


    private void Load(string level)
    {
        Debug.Log("here!");
        DataPresistanceManager.Instance.loadNameSave(level);
    }
}

