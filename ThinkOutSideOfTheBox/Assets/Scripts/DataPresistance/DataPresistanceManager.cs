using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DataPresistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;



    private GameData gameData;
    private List<IDataPersistance> dataPersistancesObjects;
    private FileDataHandler dataHandler;
    public static DataPresistanceManager Instance { get; private set; }


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        

    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
       // LevelLoaded();
       // LoadGame();
    }
    public void LevelLoaded()
    {
        this.dataPersistancesObjects = FindAllDataPersistanceObjects();
        Debug.Log(dataPersistancesObjects.Count);
    }
    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
       
        IEnumerable<IDataPersistance> dataPersistancesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        
        return new List<IDataPersistance>(dataPersistancesObjects);
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public string[] LoadFileNames()
    {
        return dataHandler.FindSaveData();

        
    }


    public void LoadGame()
    {
        this.gameData = dataHandler.Load();


        if(this.gameData == null)
        {
            Debug.Log("No Data was found. Initiazing data to defaults.");
            NewGame();
        }

        foreach(IDataPersistance dataPersistanceObj in dataPersistancesObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }
        Debug.Log("loaded Level = " + gameData.CurrentLevel + "loaded Health = " + gameData.health);
    }

    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistanceObj in dataPersistancesObjects)
        {
            Debug.Log(dataPersistanceObj.ToString());
            Debug.Log("test");
            dataPersistanceObj.SaveData(ref gameData);
           
        }
        Debug.Log("Saved Level = " + gameData.CurrentLevel + "Health = " + gameData.health);
        dataHandler.Save(gameData);

    }


    private void OnApplicationQuit()
    {
        SaveGame();
    }

}
