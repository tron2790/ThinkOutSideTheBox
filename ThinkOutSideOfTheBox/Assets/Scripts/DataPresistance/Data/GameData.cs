using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData 
{
    public float health;
    public int CurrentLevel;
    public string CurrentSceneName;
    public GameData()
    {
        this.health = 100f;
        this.CurrentLevel = 0;
        this.CurrentSceneName = "";
    }
}
