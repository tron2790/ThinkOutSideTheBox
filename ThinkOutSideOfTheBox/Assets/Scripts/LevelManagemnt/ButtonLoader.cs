using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLoader : MonoBehaviour
{
   public void LoadScene(string sceneName)
   {
        LevelManager.Instance.LoadScene(sceneName);
   }
}
